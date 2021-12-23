using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
	[SerializeField]
	private AudioClip din;
	private new AudioSource audio;

    private void Start()
    {
		audio = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		audio.PlayOneShot(din);
		if (collision.tag == "Player")
		{
			SceneManager.LoadScene(0);
		}
		else
		{

			if (GameObject.FindGameObjectsWithTag("Ball").Length == 1)
			{
				SceneManager.LoadScene(0);
			}
			// If we have more, then 1 ball(not main), then just destroy it
			GameObject.Destroy(collision.gameObject);
		}
	}
}
