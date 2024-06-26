using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeDrawer : MonoBehaviour
{
    public GameObject LeftOpenWardrobe, OpenWardrobe, UIDrawers;
    public Button UpDrawer, MiddleDrawer, BottomDrawer;
    public Collider UIOpenButton;
    public Animator UpDrawerAnim, MiddleDrawerAnim, BottomDrawerAnim;
    public Button Screwdriver;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void OnMouseDown()
    {
        // Lança um raio a partir da posição do mouse na cena
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Verifica se o raio colidiu com um objeto na cena
        if (Physics.Raycast(ray, out hit))
        {
            // Verifica se o objeto colidido tem o nome desejado
            if (hit.collider != null && hit.collider.gameObject.name == "UIOpenButton")
            {
                if(LeftOpenWardrobe.activeSelf || OpenWardrobe.activeSelf)
                {
                    ActivateUIDrawers();
                }
            }
        }
    }

    public void OnButtonClick()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "UpDrawerButton":
            print("UpDrawer foi clicado!");

            if(UpDrawerAnim.GetBool("isOpen1"))
            {
                MiddleDrawer.interactable = true;
                BottomDrawer.interactable = true;
                
                UpDrawerAnim.SetBool("isOpen1", false);
                audioSource.PlayOneShot(audioClip);
                break;
            }

            if(!UpDrawerAnim.GetBool("isOpen1"))
            {
                MiddleDrawer.interactable = false;
                BottomDrawer.interactable = false;
                UpDrawerAnim.SetBool("isOpen1", true);
                audioSource.PlayOneShot(audioClip);
                break;
            }
            break;


            case "MiddleDrawerButton":
                print("MiddleDrawer foi clicado!");

            if(MiddleDrawerAnim.GetBool("isOpen2"))
            {
                UpDrawer.interactable = true;
                BottomDrawer.interactable = true;
                
                MiddleDrawerAnim.SetBool("isOpen2", false);
                Screwdriver.interactable = false;
                audioSource.PlayOneShot(audioClip);
                break;
            }

            if(!MiddleDrawerAnim.GetBool("isOpen2"))
            {
                UpDrawer.interactable = false;
                BottomDrawer.interactable = false;
                MiddleDrawerAnim.SetBool("isOpen2", true);
                Screwdriver.interactable = true;
                audioSource.PlayOneShot(audioClip);
                break;
            }
            break;


            case "BottomDrawerButton":
                print("BottomDrawer foi clicado!");

            if(BottomDrawerAnim.GetBool("isOpen3"))
            {
                MiddleDrawer.interactable = true;
                UpDrawer.interactable = true;
                
                BottomDrawerAnim.SetBool("isOpen3", false);
                audioSource.PlayOneShot(audioClip);
                break;
            }

            if(!BottomDrawerAnim.GetBool("isOpen3"))
            {
                MiddleDrawer.interactable = false;
                UpDrawer.interactable = false;
                BottomDrawerAnim.SetBool("isOpen3", true);
                audioSource.PlayOneShot(audioClip);
                break;
            }
            break;


            default:
                print("Outro collider foi clicado!");
                break;
        } 
    }

    public void ActivateUIDrawers()
    {
        

        if(!UIDrawers.activeSelf)
        {
            UIDrawers.SetActive(true);
            UIOpenButton.enabled = false;
        }
    }
}