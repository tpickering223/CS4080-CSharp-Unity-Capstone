using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using System;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private MapController _mapController;

    private float _updateInterval = .5f;
    private GameOfLifeController _gameOfLifeController;
    private InformationHandler _infoDisplay;

    private Coroutine _gameLoop = null;

    //temp variables
    [Header("Temp Variables")]
    [SerializeField] private int _width = 10;
    [SerializeField] private int _height = 10;

    public void Start()
    {
        _infoDisplay = GameObject.Find("GenerationDisplay").GetComponent<InformationHandler>(); // Placed here because Unity doesn't like GetComponenet in field initialization.
    }

    [ContextMenu("BuildMap")]
    public void BuildMap()
    {
        //send settings to GOL layer
        this._mapController.GenerateVisualMap(_width, _height);
        if(this._gameOfLifeController == null)
        {
            this._gameOfLifeController = new GameOfLifeController();
        }
        this._gameOfLifeController.Init(this._mapController.Map, _width, _height);

    }

    public void BuildMap(int width, int height)
    {
        this._width = width;
        this._height = height;
        this._mapController.GenerateVisualMap(_width, _height);
        if (this._gameOfLifeController == null)
        {
            this._gameOfLifeController = new GameOfLifeController();
        }
        this._gameOfLifeController.Init(this._mapController.Map, _width, _height);
    }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        this._gameLoop = StartCoroutine(UpdateLoop());
    }

    [ContextMenu("Pause Game")]
    public void PauseGame()
    {
        if(this._gameLoop != null)
        {
            StopCoroutine(this._gameLoop);
        }
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        if (this._gameLoop != null)
        {
            StopCoroutine(this._gameLoop);
        }

        this._mapController.ClearMap(this._width, this._height);
        BuildMap();

        this._infoDisplay.Generations = 0;
    }

    public void FlipGameOfLifeMapTile(int i, int j)
    {
        this._gameOfLifeController.flipState(i, j);
    }

    #region Game Loop
    public void ChangeGameTickInterval(float num)
    {
        this._updateInterval = num;
    }

    private IEnumerator UpdateLoop()
    {
        while (true)
        {

            yield return new WaitForSeconds(this._updateInterval);

            this._mapController.UpdateMap(this._gameOfLifeController.GameTick(), _width, _height);
            //call game tick

            //Update UI readout
            _infoDisplay.UpdateFreq = _updateInterval;
            _infoDisplay.Generations++;
        }
    }
    #endregion
}
