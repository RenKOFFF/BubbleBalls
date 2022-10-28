using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PausePopup : MonoBehaviour
{
    public static UnityEvent OnPauseEnterEvent = new UnityEvent();
    public static UnityEvent OnPauseExitEvent = new UnityEvent();
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        OnPauseEnterEvent.Invoke();
    }

    private void OnDisable()
    {
        OnPauseExitEvent.Invoke();
    }
}
