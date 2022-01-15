using UnityEngine;

public class MainBallActivity : BallActivity
{

    [SerializeField]
    private AudioClip din;
    private new AudioSource audio;
    private string _objectTag = "Ball";
    private void Start()
    {

        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _objectTag)
            audio.PlayOneShot(din);
    }
}
