using UnityEngine;

public class Cue : MonoBehaviour
{
    private Rigidbody2D _mainBall;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        _mainBall = GetComponentInParent<Rigidbody2D>();
        mainCamera = Camera.main;

    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        gameObject.SetActive(true);
    }

    public void CuePossition()
    {
        gameObject.SetActive(true);
        float enter;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.forward, transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);
        float angle = Mathf.Atan2(mouseInWorld.x - _mainBall.transform.position.x, mouseInWorld.y - _mainBall.transform.position.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle - 135));
        transform.position = (mouseInWorld);
    }
}
