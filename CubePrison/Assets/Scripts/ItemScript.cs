using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string ItemName;
    public AudioClip audioClip;
    public AudioSource audioSource;
    
    void Start()
    {
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        // Verifique se o botão pressionado é o botão esquerdo (botão 0)
        if (Input.GetMouseButtonDown(0))
        {
            // Faça algo quando o botão esquerdo do mouse for pressionado
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            ItemSaver.GetInstance().AddString(ItemName);
            gameObject.SetActive(false);
        }
    }
    
    public void OnButtonClick()
    {
        if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        ItemSaver.GetInstance().AddString(ItemName);
        gameObject.SetActive(false);
    }
}