using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchSizeByScreenWidth : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
        _camera.orthographicSize /= 1080f / Screen.width * 1920f / Screen.height;
    }
}
