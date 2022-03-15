using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TileSound : MonoBehaviour
{
    private AudioSource audio;

    void Awake() 
    {
        audio = GetComponent<AudioSource>();
        audio.enabled = false;
    }

    public void Play()
    {
        audio.enabled = true;
        audio.Play();
    }

    public void Stop()
    {
        audio.enabled = false;
    }
}
