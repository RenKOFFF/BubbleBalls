using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGun : MonoBehaviour
{
    [HideInInspector] public static BallGun instanse;

    [SerializeField] private GameObject _ball;
    [SerializeField] private float _force = 1f;
    private Rigidbody _ballRigidbody;

    void Awake()
    {
        instanse = this;
    }

    private void Start()
    {
        _ballRigidbody = _ball.GetComponent<Rigidbody>();
    }

    public void ShootOnDirection(Vector2 mousePositionOnScreen)
    {
        var ball = Instantiate(_ball, transform.position, Quaternion.identity);
        var rg = ball.GetComponent<Rigidbody>();

        rg.velocity = (mousePositionOnScreen - (Vector2)_ball.transform.position).normalized * _force;
    }
}
