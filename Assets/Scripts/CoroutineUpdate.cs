using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineUpdate : MonoBehaviour
{
    [SerializeField] private List<SerializableList<SpriteRenderer>> _sprites = new List<SerializableList<SpriteRenderer>>();
    private float _updateInterval = .5f;
    private GameOfLifeController _controller;

    // Start is called before the first frame update
    void Start()
    {
        //_controller = new GameOfLifeController();
        //this._controller.Init(_sprites);

        StartCoroutine(UpdateLoop());
    }

    public void ChangeInterval(float num)
    {
        this._updateInterval = num;
    }


    private IEnumerator UpdateLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(this._updateInterval);
            this._controller.GameTick();
            Debug.LogError($"waiting {this._updateInterval} seconds");
        }
    }
}

[System.Serializable]
public class SerializableList<T>
{
    public List<T> list = new List<T>();
}
