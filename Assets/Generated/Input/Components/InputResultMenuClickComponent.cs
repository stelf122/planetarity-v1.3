//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly ResultMenuClickComponent resultMenuClickComponent = new ResultMenuClickComponent();

    public bool isResultMenuClick {
        get { return HasComponent(InputComponentsLookup.ResultMenuClick); }
        set {
            if (value != isResultMenuClick) {
                var index = InputComponentsLookup.ResultMenuClick;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : resultMenuClickComponent;

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

    static Entitas.IMatcher<InputEntity> _matcherResultMenuClick;

    public static Entitas.IMatcher<InputEntity> ResultMenuClick {
        get {
            if (_matcherResultMenuClick == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ResultMenuClick);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherResultMenuClick = matcher;
            }

            return _matcherResultMenuClick;
        }
    }
}