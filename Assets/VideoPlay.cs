using System;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Collision with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Finish"))
        {
            videoPlayer.Play();
        }
    }
}
