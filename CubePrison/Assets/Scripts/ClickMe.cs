using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMe : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public GameObject Desativar, Ativar;

    public float WaitForSeconds;
    // Start is called before the first frame update

    void OnMouseDown()
    {
        audioSource.PlayOneShot(audioClip);
        Ativar.SetActive(true);
        Desativar.SetActive(false);
        
    }
}
