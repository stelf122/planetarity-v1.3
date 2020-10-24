using UnityEngine;
using System.Collections;

public abstract class BaseMenu : MonoBehaviour, IMenu
{
    [SerializeField] private GameObject _panel;

    public abstract MenuType Type { get; }

    protected Contexts Contexts => Contexts.sharedInstance;

    protected GameContext GameContext => Contexts.game;

    protected InputContext InputContext => Contexts.input;

    protected IMenuManager MenuManager => GameContext.menuManager.Value;

    private void Start()
    {
        OnStart();
    }

    public void Hide()
    {
        Close();
    }

    public void Show()
    {
        Open();
        OnShowed();
    }

    public void Show(object data)
    {
        Open();
        OnShowed(data);
    }

    private void Open()
    {
        _panel.SetActive(true);
    }

    private void Close()
    {
        _panel.SetActive(false);
    }

    protected virtual void OnStart() { }

    protected virtual void OnShowed() { }

    protected virtual void OnShowed(object data) { }
}
