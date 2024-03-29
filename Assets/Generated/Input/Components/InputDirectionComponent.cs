//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public DirectionComponent direction { get { return (DirectionComponent)GetComponent(InputComponentsLookup.Direction); } }
    public bool hasDirection { get { return HasComponent(InputComponentsLookup.Direction); } }

    public void AddDirection(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.Direction;
        var component = (DirectionComponent)CreateComponent(index, typeof(DirectionComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDirection(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.Direction;
        var component = (DirectionComponent)CreateComponent(index, typeof(DirectionComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDirection() {
        RemoveComponent(InputComponentsLookup.Direction);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherDirection;

    public static Entitas.IMatcher<InputEntity> Direction {
        get {
            if (_matcherDirection == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Direction);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherDirection = matcher;
            }

            return _matcherDirection;
        }
    }
}
