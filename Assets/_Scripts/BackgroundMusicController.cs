using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public new AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        audio.Play();
    }
}
