//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CollisionComponent collision { get { return (CollisionComponent)GetComponent(GameComponentsLookup.Collision); } }
    public bool hasCollision { get { return HasComponent(GameComponentsLookup.Collision); } }

    public void AddCollision(UnityEngine.GameObject newObject) {
        var index = GameComponentsLookup.Collision;
        var component = (CollisionComponent)CreateComponent(index, typeof(CollisionComponent));
        component.Object = newObject;
        AddComponent(index, component);
    }

    public void ReplaceCollision(UnityEngine.GameObject newObject) {
        var index = GameComponentsLookup.Collision;
        var component = (CollisionComponent)CreateComponent(index, typeof(CollisionComponent));
        component.Object = newObject;
        ReplaceComponent(index, component);
    }

    public void RemoveCollision() {
        RemoveComponent(GameComponentsLookup.Collision);
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

    static Entitas.IMatcher<GameEntity> _matcherCollision;

    public static Entitas.IMatcher<GameEntity> Collision {
        get {
            if (_matcherCollision == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Collision);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollision = matcher;
            }

            return _matcherCollision;
        }
    }
}
