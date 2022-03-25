using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TileSound : MonoBehaviour
{
    private AudioSource audio;
    private Animator animator;
    public string colorName;

    void Awake() 
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = true;
            animator.speed = 0;
        }
        audio.enabled = false;
    }

    public void Play()
    {
        audio.enabled = true;
        if (animator != null)
        {
            animator.Play(0, -1, 0);
            animator.speed = 1;
        }
        audio.Play();
    }

    public void Stop()
    {
        audio.Stop();
        if (animator != null)
        {
            animator.Play(0, -1, 0);
            animator.speed = 0;
        }
        audio.enabled = false;
    }
}
