using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameMenu;

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _lostPanel;

    [SerializeField] private Button _startButton;

    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;

        _contexts.game.SetMenuController(this);

        _mainMenu.SetActive(true);
        _gameMenu.SetActive(false);

        _winPanel.SetActive(false);
        _lostPanel.SetActive(false);

        _startButton.onClick.AddListener(StartClick);
    }

    private void StartClick()
    {
        _contexts.input.CreateEntity().isStartGame = true;

        ShowGame();
    }

    public void ShowGame()
    {
        _mainMenu.SetActive(false);
        _gameMenu.SetActive(true);
    }

    public void ShowMainMenu(bool win)
    {
        _mainMenu.SetActive(true);
        _gameMenu.SetActive(false);

        _winPanel.SetActive(win);
        _lostPanel.SetActive(!win);
    }
}
