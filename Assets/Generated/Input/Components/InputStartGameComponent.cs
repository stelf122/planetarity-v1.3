//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly StartGameComponent startGameComponent = new StartGameComponent();

    public bool isStartGame {
        get { return HasComponent(InputComponentsLookup.StartGame); }
        set {
            if (value != isStartGame) {
                var index = InputComponentsLookup.StartGame;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : startGameComponent;

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

    static Entitas.IMatcher<InputEntity> _matcherStartGame;

    public static Entitas.IMatcher<InputEntity> StartGame {
        get {
            if (_matcherStartGame == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.StartGame);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherStartGame = matcher;
            }

            return _matcherStartGame;
        }
    }
}
