# Resolving Node Dependencies

## Introduction

It is very common to reference other nodes within a node class.

Let's say you have a custom node with the following structure:

![](~/images/NodePathStructure.png)

The official way requires a lot of redundant code:

```csharp
private Container _container;
private Label _label;

public Button Button { get; set; }

public partial class CustomNode : Node {
    public override void _Ready() {
        _container = GetNode<Container>("Container");

        _label = GetNode<Label>("Container/Button/Label");
        _label = GetNode<Label>("%Label");

        Button = GetNode<Button>("Container/Button");
    }
}
```

Note that `GetNode<Label>("Container/Button/Label")` and `GetNode<Label>("%Label")` both point to the same label node since it is set as a [scene unique node](https://docs.godotengine.org/en/stable/tutorials/scripting/scene_unique_nodes.html).

With the `[NodePath]` attribute, you can reduce a lot of these codes:

```csharp
[NodePath] private Container _container;
[NodePath] private Label _label;

[NodePath("Container/Button")] public Button Button { get; set; }

public override void _Ready() {
    this.Resolve();
}
```

All fields and properties, regardless or their access modifiers, can be resolved using the `Resolve()` method. Node that fields cannot be `readonly` or `const`, and properties must define a `set` method.

If no path is provided, the attribute resolves the dependency by looking for a node at the root with the same name to the variable in **Pascal** case and **no leading underscores**. If this node is not found, it proceeds to looking for a [scene unique node](https://docs.godotengine.org/en/stable/tutorials/scripting/scene_unique_nodes.html) again with the same name in Pascal case and no leading underscores. Otherwise, if a path is provided, the dependency is resolved by searching for a node at the path **relative** to the current node.

In either case, if a node dependency is not found, an exception would be thrown.

You can call `node.Resolve()` any time you desire, but the common place to resolve node dependencies is either `_EnterTree()` or `_Ready()` where these dependencies would normally come into action.
You can check whether the node is resolved by calling `node.IsResolved()`, calling `node.Resolve()` more than once has no effect.

## Usage with `GDx.New()`

Nodes instantiated with `GDx.New()` and its other overloads are automatically resolved as soon as the node is instantiated, so you do not need to call `node.Resolve()` on them.

## Usage with `GodotEx.Hosting.Host`

It is **highly recommended** to use the `[NodePath]` resolving functionality together with `GodotEx.Hosting.Host` since it provides a hosted service for resolving nodes as they enter the scene tree, hence you don't need to call `this.Resolve()` on all nodes that require resolving. Learn how to set up an application scoped [autoload host](~/docs/GodotEx.Hosting/Hosting.md#setting-up-an-autoload-host) here.
