using UnityEngine;
using System.Collections;

public class ResultMenuArguments
{
    public bool Win;
}

public class ResultMenu : BaseMenu
{
    public override MenuType Type => MenuType.Result;
    
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _lostPanel;

    protected override void OnShowed(object data)
    {
        var args = (ResultMenuArguments)data;

        _winPanel.SetActive(args.Win);
        _lostPanel.SetActive(!args.Win);
    }
}
