using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.PlayOneShot(clip);
        }
    }
}
