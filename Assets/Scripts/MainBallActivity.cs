using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBallActivity : BallActivity
{

    [SerializeField]
    private AudioClip din;
    private new AudioSource audio;
    private void Start()
    {

        _rg = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
            audio.PlayOneShot(din);
    }
}
