using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BallCell;

public class BallGun : MonoBehaviour
{
    [HideInInspector] public static BallGun instanse;

    [SerializeField] private Ball _ball;
    //[HideInInspector] public Ball CurrentBall { get; private set; }
    public BallType[] _ballsTypesQueue { get; private set; }

    [SerializeField] private float _force = 400f;
    private Rigidbody _ballRigidbody;

    void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
            return;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        _ballRigidbody = _ball.GetComponent<Rigidbody>();

        _ballsTypesQueue = new[] { BallType.Red, BallType.Blue, BallType.Green };
    }

    public void ShootOnDirection(Vector2 mousePositionOnScreen)
    {
        var CurrentBall = Instantiate(_ball, transform.position, Quaternion.identity);
        var rb = CurrentBall.GetComponent<Rigidbody>();
        
        rb.AddForce((mousePositionOnScreen - (Vector2)_ball.transform.position).normalized * _force);
    }
}
