using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    public bool State { get { return this._state; } }

    private int _widthPos = 0;
    private int _heightPos = 0;
    private bool _state = false;
    private Action<int, int> _onClickAction;

    public void SetData(int width, int height, bool state, Action<int, int> onClickAction)
    {
        this._widthPos = width;
        this._heightPos = height;
        this._state = state;
        this._onClickAction = onClickAction;

        SetSprite();
    }

    public void SetState(bool state)
    {
        this._state = state;
        SetSprite();
    }

    public void FlipState()
    {
        this._state = !this._state;
        SetSprite();
    }
    
    public void OnClick()
    {
        this._onClickAction.Invoke(this._widthPos, this._heightPos);
    }

    private void SetSprite()
    {
        this._sprite.color = (this._state) ? Color.yellow : Color.white;
    }
}
