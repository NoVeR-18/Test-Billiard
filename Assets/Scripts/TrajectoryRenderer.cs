using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{

    [SerializeField]
    private GameObject DirectionalLine;     //линия главного мяча
    [SerializeField]
    private GameObject TrajectoryLine;      //линия после
    [SerializeField]
    private GameObject HitCircle;           //круг столкновения

    //Initializing our point position and direction to push
    private Vector2 mouseInWorld = new Vector2();
    private Vector2 Direction = new Vector2();


    private void OnDisable()
    {
        DirectionalLine.SetActive(false);
        TrajectoryLine.SetActive(false);
        HitCircle.SetActive(false);
    }
    private void OnEnable()
    {
        DirectionalLine.SetActive(true);
        TrajectoryLine.SetActive(true);
        HitCircle.SetActive(true);
    }

    public void ShowTrajectory()
    {
        mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Direction = -mouseInWorld + new Vector2(transform.position.x, transform.position.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction.normalized);

        Vector2 HitTrajectory = (new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y) - hit.point).normalized;
        Vector2 BounceTrajectory = Vector2.Perpendicular(HitTrajectory);

        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y, -1);
        Vector3 endPosition = new Vector3(hit.point.x, hit.point.y, -1);
        Vector3 trajectoryPosition = new Vector3(hit.collider.transform.position.x + HitTrajectory.x * 0.5f, hit.collider.transform.position.y + HitTrajectory.y * 0.5f, -1);

        if ((-HitTrajectory.x > 0 && -HitTrajectory.y > 0) || (-HitTrajectory.x < 0 && -HitTrajectory.y < 0))
        {
            BounceTrajectory = -BounceTrajectory;
        }

        DirectionalLine.GetComponent<LineRenderer>().enabled = true;
        HitCircle.GetComponent<SpriteRenderer>().enabled = true;
        DirectionalLine.GetComponent<LineRenderer>().SetPosition(0, startPosition);
        DirectionalLine.GetComponent<LineRenderer>().SetPosition(1, endPosition);

        if (hit.collider.tag == "Ball")
        {
            TrajectoryLine.GetComponent<LineRenderer>().enabled = true;
            TrajectoryLine.GetComponent<LineRenderer>().SetPosition(0, new Vector3(hit.point.x, hit.point.y, -1));
            TrajectoryLine.GetComponent<LineRenderer>().SetPosition(1, trajectoryPosition);
        }
        else if (hit.collider.tag != "Ball")
        {
            TrajectoryLine.GetComponent<LineRenderer>().enabled = false;
        }
        else if (hit.collider.tag == "Wall")
        {

            Vector2.Reflect(endPosition.normalized, hit.collider.transform.position);


        }
        Vector3 bouncePosition = new Vector3(endPosition.x + BounceTrajectory.x * 0.5f, endPosition.y + BounceTrajectory.y * 0.5f, -1);
        DirectionalLine.GetComponent<LineRenderer>().SetPosition(2, bouncePosition);
        HitCircle.transform.position = endPosition - new Vector3(Direction.normalized.x, Direction.normalized.y) * 0.1f;

    }
}
