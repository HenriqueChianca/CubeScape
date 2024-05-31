using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public AudioClip audioClip, BadAudioClip;
    public AudioSource audioSource;
    public string Requirement, ItemPP;
    
    // Referência para o CanvasController
    public CanvasController canvasController;

    void Start()
    {
        // Obtenha a referência do CanvasController
        canvasController = CanvasController.GetInstance();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("clicou");
            // Verifique se o item necessário para a interação está no inventário
            foreach (string savedString in ItemSaver.GetInstance().stringList)
            {
                if (savedString == Requirement)
                {
                    // Verifique se o item necessário está selecionado no inventário
                    for (int i = 0; i < canvasController.uiItems.Length; i++)
                    {
                        if (canvasController.uiItems[i].key == Requirement && canvasController.uiItems[i].selected)
                        {
                            // Realize a interação apenas se o item estiver selecionado
                            print("Item necessário encontrado e selecionado.");

                            // Remova o item do inventário após a interação
                            int indexToRemove = ItemSaver.GetInstance().stringList.IndexOf(Requirement);
                            if (indexToRemove != -1)
                            {
                                ItemSaver.GetInstance().RemoveString(indexToRemove);
                                print("Item removido do inventário após interação.");
                            }

                            // Tocar o áudio
                            if (!audioSource.isPlaying)
                            {
                                audioSource.clip = audioClip;
                                audioSource.Play();
                            }
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
                }
                
                if(savedString != Requirement || savedString == null)
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.clip = BadAudioClip;
                        audioSource.Play();
                    }
                }
            }
        }
    }
}
