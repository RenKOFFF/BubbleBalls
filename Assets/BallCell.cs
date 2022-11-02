using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCell : MonoBehaviour
{
    public List<BallCell> NeighboringCells { get; private set; }
    public BallType Type;
    private Material _ballCellMaterial;
    private bool isDestroyed;

    void Start()
    {
        NeighboringCells = new List<BallCell>();
        InitializeNeighbourBalls();

        SetColors();

        Ball.OnBallTuchedBallCellEvent.AddListener(CheckBall);
    }

    private void CheckBall(Ball ball, BallCell ballCell)
    {
        if (this != ballCell) return;

        if (ballCell.Type == ball.Type)
        {
            MarkDestroyAllNeighbourCells(ballCell);
            DestroyAllMarkedCells(ballCell);
            Destroy(ball.gameObject);
            Destroy(ballCell);
        }
    }

    private void DestroyAllMarkedCells(BallCell ballCell)
    {
        foreach (var cell in ballCell.NeighboringCells)
        {
            if (cell.isDestroyed)
            {
                DestroyAllMarkedCells(cell);
                Destroy(cell.gameObject);
            }
        }
    }

    private void MarkDestroyAllNeighbourCells(BallCell ballCell)
    {
        if (isDestroyed) return;

        foreach (var cell in ballCell.NeighboringCells)
        {
            if (cell.Type == ballCell.Type)
            {
                cell.isDestroyed = true;
                MarkDestroyAllNeighbourCells(cell);
                //Destroy(cell.gameObject);
            }
        }
    }

    private void InitializeNeighbourBalls()
    {
        var colliders = Physics.OverlapSphere(transform.position, transform.localScale.x);
        for (int i = 0; i < colliders.Length; i++)
        {
            var ball = colliders[i].GetComponent<BallCell>();

            if (ball)
            {
                if (ball == this)
                {
                    continue;
                }
                else
                {
                    NeighboringCells.Add(ball);
                }
            }
        }
    }

    private void SetColors()
    {
        _ballCellMaterial = GetComponent<Renderer>().material;
        switch (Type)
        {
            case BallType.Blue:
                {
                    _ballCellMaterial.color = Color.blue;
                    break;
                }
            case BallType.Green:
                {
                    _ballCellMaterial.color = Color.green;
                    break;
                }
            case BallType.Red:
                {
                    _ballCellMaterial.color = Color.red;
                    break;
                }
            default:
                {
                    _ballCellMaterial.color = Color.blue;
                    break;
                }
        }
    }

    public enum BallType
    {
        Blue,
        Green,
        Red
    }
}
