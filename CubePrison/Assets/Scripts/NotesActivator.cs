using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesActivator : MonoBehaviour
{
    public GameObject Notes;
    public AudioSource audioSource;
    public AudioClip AudioClip;
    public PianoPuzzle PianoPuzzle;

    private void OnEnable()
    {
        if(Notes != null)
        {
            Notes.SetActive(true);
            PianoPuzzle.NotesSeen();
        }

        if(AudioClip != null)
        {
            audioSource.PlayOneShot(AudioClip);
        }        
    }
}
