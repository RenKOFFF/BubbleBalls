using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorders : MonoBehaviour
{
    public GameObject LeftDownCornerBorder;
    public GameObject RightTopCornerBorder;

    private void Start()
    {
        SetupBorders();
    }
    public void SetupBorders()
    {
        var camera = Camera.main;

        var leftDownCornerBorderPosition = camera.ScreenToWorldPoint(new Vector2(0, 0));
        leftDownCornerBorderPosition.z = 0;
        LeftDownCornerBorder.transform.position = leftDownCornerBorderPosition;

        var rigthTopCornerBorderPosition = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        rigthTopCornerBorderPosition.z = 0;
        RightTopCornerBorder.transform.position = rigthTopCornerBorderPosition;

    }
}
