using UnityEngine;
using System.Collections;

public interface IMenu
{
    MenuType Type { get; }

    void Show();

    void Show(object data);

    void Hide();
}
