using UnityEngine;

public class TrajectoryBallRenderer : MonoBehaviour
{
    [SerializeField] private Transform _ballGun;

    private LineRenderer line;
    private float _width = .3f;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.startWidth = line.endWidth = _width;
        line.SetPosition(0, _ballGun.position);
        HideTrajectory();
    }

    public void ShowTrajectory(Vector2 mousePositionOnScreen)
    {
        line.SetPosition(1, mousePositionOnScreen);
    }

    public void HideTrajectory()
    {
        line.SetPosition(1, _ballGun.position);
    }
}
