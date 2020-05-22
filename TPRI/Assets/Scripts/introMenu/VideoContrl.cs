using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoContrl : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private AudioSource music;

    private void Awake()
    {
        SceneManager.LoadScene("_introMenu");
        //music.Play();
        //_videoPlayer.Play();
    }

    /*private void Update()
    {
        if (!_videoPlayer.isPlaying)
        {
            music.Stop();
            SceneManager.LoadScene("_introMenu");
        }
    }*/
}
