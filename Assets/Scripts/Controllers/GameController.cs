﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GlobalConfig _globalConfig;
    [SerializeField] private HudController _hudController;

    private RootSystems _rootSystems;
    private ViewSystems _viewSystems;

    private void Awake()
    {
        var contexts = Contexts.sharedInstance;

        var menuManager = new MenuManager(contexts);

        _globalConfig.Initialize(contexts);
        _hudController.Initialize(contexts);

        _rootSystems = new RootSystems(contexts);
        _viewSystems = new ViewSystems(contexts);

        _rootSystems.Initialize();
        _viewSystems.Initialize();
    }

    private void Update()
    {
        _rootSystems.Execute();
        _viewSystems.Execute();
    }
}
