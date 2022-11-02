using UnityEngine;

public class TrajectoryBallRenderer : MonoBehaviour
{
    [SerializeField] private Transform _ballGun;

    private LineRenderer line;
    private float _width = .3f;

    private Ray _ray;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.startWidth = line.endWidth = _width;
        line.SetPosition(0, _ballGun.position);
        HideTrajectory();

        _ray = new Ray();
        _ray.origin = _ballGun.position;
    }

    public void ShowTrajectory(Vector2 mousePositionOnScreen)
    {
        RaycastHit hitInfo;

        _ray.direction = mousePositionOnScreen - (Vector2)_ray.origin;

        if (Physics.Raycast(_ray, out hitInfo))
        {
            line.SetPosition(1, (Vector2)hitInfo.point);
        }
        else
        {
            line.SetPosition(1, mousePositionOnScreen);
        }
    }

    public void HideTrajectory()
    {
        line.SetPosition(1, _ballGun.position);
    }
}
