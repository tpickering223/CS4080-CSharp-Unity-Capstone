using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] GameObject _mapTemplate;

    public MapTile[,] Map {get { return this._map; }}
    private MapTile[,] _map;

    public void GenerateVisualMap(int width, int height)
    {
        this._map = new MapTile[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject temp = GameObject.Instantiate(this._mapTemplate);
                temp.transform.position = new Vector3(i, -j, 0);
                temp.SetActive(true);
                this._map[i, j] = temp.GetComponent<MapTile>();
                this._map[i, j].SetData(i,j, false, (_i, _j) =>
                {
                    this._map[_i, _j].FlipState();
                    GameManager.Instance.FlipGameOfLifeMapTile(_i, _j);
                });
            }
        }
    }

    public void UpdateMap(int[,] newMap, int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                this._map[i, j].SetState(Convert.ToBoolean(newMap[i, j]));
            }
        }
    }

    public void ClearMap(int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject.Destroy(this._map[i, j]);
            }
        }
    }
}
