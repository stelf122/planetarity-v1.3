//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly PauseClickComponent pauseClickComponent = new PauseClickComponent();

    public bool isPauseClick {
        get { return HasComponent(InputComponentsLookup.PauseClick); }
        set {
            if (value != isPauseClick) {
                var index = InputComponentsLookup.PauseClick;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : pauseClickComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherPauseClick;

    public static Entitas.IMatcher<InputEntity> PauseClick {
        get {
            if (_matcherPauseClick == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.PauseClick);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherPauseClick = matcher;
            }

            return _matcherPauseClick;
        }
    }
}
