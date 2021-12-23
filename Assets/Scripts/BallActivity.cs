using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivity : MonoBehaviour
{
    public static bool activity;


    protected Rigidbody2D _rg;

    private void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (_rg.velocity.x != 0 || _rg.velocity.y != 0)
        {
            activity = true;
        }
    }

}
