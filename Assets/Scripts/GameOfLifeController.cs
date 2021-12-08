using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLifeController
{
    int _width = 10;
    int _height = 10;

    // Intiliazing the grid.
    int[,] grid = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

    public void Init(MapTile[,] map, int width, int height)
    {
        this.grid = new int[width, height];
        //this._map = map;
        this._width = width;
        this._height = height;

        for(int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (map[i,j].State)
                {
                    this.grid[i, j] = 1;
                }
                else
                {
                    this.grid[i, j] = 0;
                }
            }
        }
    }

    public void flipState(int i, int j)
    {
        this.grid[i, j] = this.grid[i, j] == 1 ? 0 : 1;
    }

    public int[,] GameTick()
    {
        int[,] future = new int[_width, _height];
        
        // Loop through every cell
        for (int l = 1; l < _width - 1; l++)
        {
            for (int m = 1; m < _height - 1; m++)
            {

                // finding no Of Neighbours
                // that are alive
                int aliveNeighbours = 0;
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        aliveNeighbours += grid[l + i, m + j];
                    }
                }

                // The cell needs to be subtracted
                // from its neighbours as it was
                // counted before
                aliveNeighbours -= grid[l, m];

                // Implementing the Rules of Life

                // Cell is lonely and dies
                if ((grid[l, m] == 1) && (aliveNeighbours < 2))
                {
                    future[l, m] = 0;
                }
                else if ((grid[l, m] == 1) && (aliveNeighbours > 3)) // Cell dies due to over population
                {
                    future[l, m] = 0;
                }
                else if ((grid[l, m] == 0) && (aliveNeighbours == 3)) // A new cell is born
                {
                    future[l, m] = 1;
                }
                else // Remains the same
                {
                    future[l, m] = grid[l, m];
                }
            }
        }
        this.grid = future;

        return this.grid;
    }
}
