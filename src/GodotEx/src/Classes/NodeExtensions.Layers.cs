using DotEx.Reflections;
using Godot;
using System.Reflection;

namespace GodotEx;

public partial class NodeExtensions {
    private const BindingFlags PUBLIC_FLAGS = BindingFlags.Instance | BindingFlags.Public;
    private const BindingFlags ALL_FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    private const StringComparison COMPARISON = StringComparison.OrdinalIgnoreCase;

    private const string LAYER = "layer";
    private const string MASK = "mask";

    private static readonly Dictionary<Type, IEnumerable<PropertyInfo>> UINT_PROPERTIES = new();
    private static readonly Dictionary<Type, LayerInfo?> LAYER_INFOS = new();

    /// <summary>
    /// Set layer and mask properties by referencing the <see cref="LayerAttribute"/>s and
    /// <see cref="MaskAttribute"/>s labeled on this <paramref name="node"/> and its
    /// internal fields and properties.
    /// </summary>
    /// <param name="node">Node to set.</param>
    public static void SetLayers(this Node node) {
        var type = node.GetType();
        if (!LAYER_INFOS.TryGetValue(type, out var info)) {
            info = GetLayerInfo(type);
            LAYER_INFOS.Add(type, info);
        }
        info?.Apply(node);
    }

    private static LayerInfo? GetLayerInfo(Type type) {
        var layerAttr = type.GetCustomAttribute<LayerAttribute>();
        var maskAttr = type.GetCustomAttribute<MaskAttribute>();
        var memberAndFlags = GetMemberAndFlags(type);
        if (layerAttr == null && maskAttr == null && memberAndFlags == null) {
            return null;
        }

        if (!UINT_PROPERTIES.TryGetValue(type, out var uintProperties)) {
            uintProperties = type.GetProperties(PUBLIC_FLAGS).Where(pi => pi.PropertyType == typeof(uint));
            UINT_PROPERTIES.Add(type, uintProperties);
        }

        List<(PropertyInfo PropertyInfo, uint Flags)>? propertyAndFlags = null;
        if (layerAttr != null) {
            var layer = uintProperties.SingleOrDefault(pi => pi.Name.Contains(LAYER, COMPARISON))
                ?? throw new InvalidOperationException($"Layer attribute is defined but no layer property is found in {type.Name}.");
            propertyAndFlags = new() { (layer, layerAttr.Flags) };
        }
        if (maskAttr != null) {
            var mask = uintProperties.SingleOrDefault(pi => pi.Name.Contains(MASK, COMPARISON))
                ?? throw new InvalidOperationException($"Mask attribute is defined but no mask property is found in {type.Name}.");
            propertyAndFlags ??= new();
            propertyAndFlags.Add((mask, maskAttr.Flags));
        }

        return new LayerInfo(propertyAndFlags, memberAndFlags);
    }

    private static IEnumerable<(MemberInfo MemberInfo, MemberInfo SubMemberInfo, uint Flags)>? GetMemberAndFlags(Type type) {
        var memberAndFlags = new List<(MemberInfo MemberInfo, MemberInfo SubMemberInfo, uint Flags)>();
        var members = type.GetProperties(ALL_FLAGS).Cast<MemberInfo>().Concat(type.GetFields(ALL_FLAGS));
        foreach (var member in members) {
            AddMemberAndFlags(member);
        }
        return memberAndFlags.Any() ? memberAndFlags : null;

        void AddMemberAndFlags(MemberInfo member) {
            var memberLayerAttr = member.GetCustomAttribute<LayerAttribute>();
            var memberMaskAttr = member.GetCustomAttribute<MaskAttribute>();
            if (memberLayerAttr == null && memberMaskAttr == null) {
                return;
            }

            var memberType = member.GetMemberType();
            if (!UINT_PROPERTIES.TryGetValue(memberType, out var memberUintProperties)) {
                memberUintProperties = memberType.GetProperties(PUBLIC_FLAGS).Where(pi => pi.PropertyType == typeof(uint));
                UINT_PROPERTIES.Add(memberType, memberUintProperties);
            }

            if (memberLayerAttr != null) {
                var layer = memberUintProperties.SingleOrDefault(pi => pi.Name.Contains(LAYER, COMPARISON))
                    ?? throw new InvalidOperationException($"Layer attribute is defined but no layer property is found in {memberType.Name}.");
                memberAndFlags.Add((member, layer, memberLayerAttr.Flags));
            }

            if (memberMaskAttr != null) {
                var mask = memberUintProperties.SingleOrDefault(pi => pi.Name.Contains(MASK, COMPARISON))
                    ?? throw new InvalidOperationException($"Mask attribute is defined but no mask property is found in {memberType.Name}.");
                memberAndFlags.Add((member, mask, memberMaskAttr.Flags));
            }
        }
    }

    private class LayerInfo {
        public LayerInfo(IEnumerable<(PropertyInfo PropertyInfo, uint Flags)>? propertyAndFlags,
                         IEnumerable<(MemberInfo MemberInfo, MemberInfo SubMemberInfo, uint Flags)>? memberAndFlags) {
            PropertyAndFlags = propertyAndFlags;
            MemberAndFlags = memberAndFlags;
        }

        public IEnumerable<(PropertyInfo PropertyInfo, uint Flags)>? PropertyAndFlags { get; }
        public IEnumerable<(MemberInfo MemberInfo, MemberInfo SubMemberInfo, uint Flags)>? MemberAndFlags { get; }

        public void Apply(Node node) {
            if (PropertyAndFlags != null) {
                foreach (var (property, flags) in PropertyAndFlags) {
                    property.SetValue(node, flags);
                }
            }

            if (MemberAndFlags != null) {
                foreach (var (member, subMember, flags) in MemberAndFlags) {
                    var target = member.GetValue(node)
                        ?? throw new InvalidOperationException($"Failed to get {member.Name} in {node.Name}.");
                    subMember.SetValue(target, flags);
                }
            }
        }
    }
}
