using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesActivator : MonoBehaviour
{
    public GameObject Notes;
    public AudioSource audioSource;
    public AudioClip AudioClip;

    private void OnEnable()
    {
        if(Notes != null)
        {
            Notes.SetActive(true);
        }

        if(AudioClip != null)
        {
            audioSource.PlayOneShot(AudioClip);
        }        
    }
}
