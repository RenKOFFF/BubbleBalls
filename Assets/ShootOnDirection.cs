using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShootOnDirection : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private float _force = 1f;
    private Rigidbody _ballRigidbody;

    private Vector2 _mousePositionOnScreen;
    private Camera _camera;

    [SerializeField] private TrajectoryBallRenderer _trajectoryRenderer;

    void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            var _mousePosition = Input.mousePosition;
            _mousePositionOnScreen = _camera.ScreenToWorldPoint(_mousePosition);
            if (_mousePositionOnScreen.y > _ball.transform.position.y)
                _trajectoryRenderer.ShowTrajectory(_mousePositionOnScreen);
            else 
                _trajectoryRenderer.HideTrajectory();
        }

        if (Input.GetButtonUp("Fire1") && _mousePositionOnScreen.y > _ball.transform.position.y && !TimeGameManager.instanse.IsGameOnPause)
        {
            BallGun.instanse.ShootOnDirection(_mousePositionOnScreen);
            _trajectoryRenderer.HideTrajectory();
        }
    }
}
