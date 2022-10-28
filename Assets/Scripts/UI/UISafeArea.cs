using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISafeArea : MonoBehaviour
{ 
    void Awake()
    {
        UpdateSafeArea();
    }

    void UpdateSafeArea()
    {
        var safeArea = Screen.safeArea;
        var rectTransform = GetComponent<RectTransform>();

        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;

        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }
}
