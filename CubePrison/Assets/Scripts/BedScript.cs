using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnMouseDown()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
