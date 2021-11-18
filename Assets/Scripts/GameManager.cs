using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private MapController _mapController;

    private float _updateInterval = .5f;
    private GameOfLifeController _gameOfLifeController;
    //temp variables
    [Header("Temp Variables")]
    [SerializeField] private int _width = 10;
    [SerializeField] private int _height = 10;

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

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        StartCoroutine(UpdateLoop());
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
        }
    }
    #endregion
}
