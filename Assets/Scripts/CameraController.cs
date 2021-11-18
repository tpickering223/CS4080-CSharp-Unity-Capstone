using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] int _scrollSpeed = 5;
    void Update()
    {
        float hor = Input.GetAxis("Horizontal") * Time.deltaTime * this._scrollSpeed;
        float vert = Input.GetAxis("Vertical") * Time.deltaTime * this._scrollSpeed;
        float zoom = Input.GetAxis("Zoom") * Time.deltaTime * this._scrollSpeed;

        this.transform.position += new Vector3(hor, vert, 0);

        if (this.GetComponent<Camera>().orthographicSize + zoom > 5)
        {
            this.GetComponent<Camera>().orthographicSize += zoom;
        }
    }
}
