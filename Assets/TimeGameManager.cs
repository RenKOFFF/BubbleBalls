using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGameManager : MonoBehaviour
{
    public static TimeGameManager instanse;

    public bool IsGameOnPause { get; private set; }
    public const float TIME_ON_EXIT_PAUSE = 0.1f;

    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this; 
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        PausePopup.OnPauseEnterEvent.AddListener(EnterPause);
        PausePopup.OnPauseExitEvent.AddListener(ExitPause);
    }

    public void EnterPause()
    {
        Time.timeScale = 0;
        IsGameOnPause = true;
    }

    public void ExitPause()
    {
        Time.timeScale = 1;
        Invoke(nameof(ChangeIsGameOnPauseValue), TIME_ON_EXIT_PAUSE);
    }

    public void ChangeIsGameOnPauseValue()
    {
        IsGameOnPause = false;
    }
}
