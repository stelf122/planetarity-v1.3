//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SourceComponent source { get { return (SourceComponent)GetComponent(GameComponentsLookup.Source); } }
    public bool hasSource { get { return HasComponent(GameComponentsLookup.Source); } }

    public void AddSource(GameEntity newEntity) {
        var index = GameComponentsLookup.Source;
        var component = (SourceComponent)CreateComponent(index, typeof(SourceComponent));
        component.Entity = newEntity;
        AddComponent(index, component);
    }

    public void ReplaceSource(GameEntity newEntity) {
        var index = GameComponentsLookup.Source;
        var component = (SourceComponent)CreateComponent(index, typeof(SourceComponent));
        component.Entity = newEntity;
        ReplaceComponent(index, component);
    }

    public void RemoveSource() {
        RemoveComponent(GameComponentsLookup.Source);
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

    static Entitas.IMatcher<GameEntity> _matcherSource;

    public static Entitas.IMatcher<GameEntity> Source {
        get {
            if (_matcherSource == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Source);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSource = matcher;
            }

            return _matcherSource;
        }
    }
}
