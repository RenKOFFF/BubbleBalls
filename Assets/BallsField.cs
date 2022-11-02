using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsField : MonoBehaviour
{
    [SerializeField] private BallCell _ballCell;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        //throw new NotImplementedException();
    }
}
