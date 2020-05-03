using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoContrl : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    private void Awake()
    {
        _videoPlayer.Play();
    }

    private void Update()
    {
        if (!_videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("_introMenu");
        }
    }
}
