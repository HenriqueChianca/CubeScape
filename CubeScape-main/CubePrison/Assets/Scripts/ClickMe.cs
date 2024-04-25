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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        StartCoroutine(Interaction());
    }

    IEnumerator Interaction()
    {
        if (!audioSource.isPlaying)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        yield return new WaitForSeconds(WaitForSeconds);

        Ativar.SetActive(true);
        Desativar.SetActive(false);
    }
}
