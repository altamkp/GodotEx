// namespace GodotEx;

// public static class RayCastExtensions {
//     private static readonly float RAY_LENGTH = 1000f;

//     public static RayCastHit ToRayCastHit(this Godot.Collections.Dictionary rayCastDictionary) {
//         if (rayCastDictionary.Count == 0) {
//             return new RayCastHit();
//         }

//         if (!rayCastDictionary.TryGetValue(RayCastKeys.Position, out var position)) {
//             throw new InvalidOperationException($"RayCastDictionary should contain the key {RayCastKeys.Position}");
//         }
//         if (!rayCastDictionary.TryGetValue(RayCastKeys.Normal, out var normal)) {
//             throw new InvalidOperationException($"RayCastDictionary should contain the key {RayCastKeys.Normal}");
//         }
//         if (!rayCastDictionary.TryGetValue(RayCastKeys.Collider, out var collider)) {
//             throw new InvalidOperationException($"RayCastDictionary should contain the key {RayCastKeys.Collider}");
//         }
//         if (!rayCastDictionary.TryGetValue(RayCastKeys.ColliderId, out var colliderId)) {
//             throw new InvalidOperationException($"RayCastDictionary should contain the key {RayCastKeys.ColliderId}");
//         }
//         if (!rayCastDictionary.TryGetValue(RayCastKeys.Rid, out var rid)) {
//             throw new InvalidOperationException($"RayCastDictionary should contain the key {RayCastKeys.Rid}");
//         }
//         if (!rayCastDictionary.TryGetValue(RayCastKeys.Shape, out var shape)) {
//             throw new InvalidOperationException($"RayCastDictionary should contain the key {RayCastKeys.Shape}");
//         }
//         return new RayCastHit(position.AsVector3(),
//                               normal.AsVector3(),
//                               (Node3D)collider.AsGodotObject(),
//                               colliderId.AsString(),
//                               rid.AsRID(),
//                               shape.AsInt32());
//     }

//     public static RayCastHit GetMouseRayCast(this Node node, PhysicsLayers layer) {
//         var camera = node.GetViewport().GetCamera3d();
//         var mousePosition = node.GetViewport().GetMousePosition();
//         var from = camera.ProjectRayOrigin(mousePosition);
//         var to = from + camera.ProjectRayNormal(mousePosition) * RAY_LENGTH;
//         var query = new PhysicsRayQueryParameters3D() {
//             From = from,
//             To = to,
//             CollisionMask = (uint)layer
//         };
//         var rayCastDict = camera.GetWorld3d().DirectSpaceState.IntersectRay(query);
//         return rayCastDict.ToRayCastHit();
//     }

//     public static RayCastHit GetMouseRayCast(this Node node, params PhysicsLayers[] layers) {
//         var camera = node.GetTree().Root.GetCamera3d();
//         var mousePosition = node.GetViewport().GetMousePosition();
//         var from = camera.ProjectRayOrigin(mousePosition);
//         var to = from + camera.ProjectRayNormal(mousePosition) * RAY_LENGTH;
//         var layerFlags = PhysicsLayers.None;
//         foreach (var layer in layers) {
//             layerFlags = layerFlags | layer;
//         }
//         var query = new PhysicsRayQueryParameters3D() {
//             From = from,
//             To = to,
//             CollisionMask = (uint)layerFlags
//         };
//         return camera.GetWorld3d().DirectSpaceState.IntersectRay(query).ToRayCastHit();
//     }

//     public static RayCastHit GetScreenCenterRayCast(this Node node, PhysicsLayers layer) {
//         var camera = node.GetTree().Root.GetCamera3d();
//         var screenCenter = node.GetViewport().GetVisibleRect().Size / 2;
//         var from = camera.ProjectRayOrigin(screenCenter);
//         var to = from + camera.ProjectRayNormal(screenCenter) * RAY_LENGTH;
//         var query = new PhysicsRayQueryParameters3D() {
//             From = from,
//             To = to,
//             CollisionMask = (uint)layer
//         };
//         return camera.GetWorld3d().DirectSpaceState.IntersectRay(query).ToRayCastHit();
//     }

//     public static bool IsEmpty(this RayCastHit rayCastHit) {
//         return rayCastHit.Position == null;
//     }
// }
