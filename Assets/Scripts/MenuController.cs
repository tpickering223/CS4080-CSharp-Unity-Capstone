using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _size;
    [SerializeField] private GameObject _startPanel;

    public void OnClickMap()
    {
        int value = int.Parse(this._size.text);
        GameManager.Instance.BuildMap();
        this._startPanel.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
