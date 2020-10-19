//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly LifetimeCompletedComponent lifetimeCompletedComponent = new LifetimeCompletedComponent();

    public bool isLifetimeCompleted {
        get { return HasComponent(GameComponentsLookup.LifetimeCompleted); }
        set {
            if (value != isLifetimeCompleted) {
                var index = GameComponentsLookup.LifetimeCompleted;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : lifetimeCompletedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLifetimeCompleted;

    public static Entitas.IMatcher<GameEntity> LifetimeCompleted {
        get {
            if (_matcherLifetimeCompleted == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LifetimeCompleted);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLifetimeCompleted = matcher;
            }

            return _matcherLifetimeCompleted;
        }
    }
}