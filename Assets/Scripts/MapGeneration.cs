using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    [SerializeField] GameObject _template;
    [SerializeField] private int _width = 10;
    [SerializeField] private int _height = 10;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this._width; i++)
        {
            for(int j = 0; j < this._height; j++)
            {
                GameObject temp = GameObject.Instantiate(this._template);
                temp.transform.position = new Vector3(i, -j, 0);
                temp.SetActive(true);
            }
        }
    }
}
