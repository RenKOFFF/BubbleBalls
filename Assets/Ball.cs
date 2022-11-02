using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static BallCell;

public class Ball : MonoBehaviour
{
    public BallType Type;
    private Material _ballCellMaterial;

    public static UnityEvent<Ball, BallCell> OnBallTuchedBallCellEvent = new UnityEvent<Ball, BallCell>();
    void Start()
    {
        Type = (BallType)Random.Range(0, BallGun.instanse._ballsTypesQueue.Length);
        SetColors();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        var ballCell = collision.gameObject.GetComponent<BallCell>();
        if (ballCell != null)
        {
            OnBallTuchedBallCellEvent.Invoke(this, ballCell);
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
}
