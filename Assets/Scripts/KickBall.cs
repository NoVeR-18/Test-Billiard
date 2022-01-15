using System;
using UnityEngine;

public class KickBall : MonoBehaviour
{


    private float Power = 300;
    private Rigidbody2D _mainBall;
    private Camera mainCamera;
    private Cue _cue;
    [SerializeField]
    TrajectoryRenderer _trajectory;

    void Start()
    {
        _cue = GetComponentInChildren<Cue>();
        _mainBall = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        _trajectory.enabled = false;
        _cue.enabled = false;
    }

    void Update()
    {
        if (!BallActivity.isActive) {

            if (Input.GetMouseButton(0)) {
                _trajectory.enabled = true;
                _cue.enabled = true;
                _trajectory.ShowTrajectory();

                try {
                    _cue.CuePossition();
                } catch(Exception e) { 
                    Console.WriteLine("{0} Exception caught.", e); 
                }
            }
            if (Input.GetMouseButtonUp(0)) {
                _trajectory.enabled = false;
                _cue.enabled = false;
                Attack();
            }
        }
        else
            BallActivity.isActive = false;
    }


    private void Attack()
    {
        float enter;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.forward, transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);
        Vector3 speed = -(mouseInWorld - transform.position) * Power;


        _mainBall.AddForce(speed, ForceMode2D.Force);

    }




}
