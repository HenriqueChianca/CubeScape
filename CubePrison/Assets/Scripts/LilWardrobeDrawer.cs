using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LilWardrobeDrawer : MonoBehaviour
{
    public GameObject LilUIDrawers;
    public Button LilUpDrawer, LilMiddleDrawer;
    public Collider LilUIOpenButton, PianoCollider;
    public Animator LilUpDrawerAnim, LilMiddleDrawerAnim;
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
            if (hit.collider != null && hit.collider.gameObject.name == "LilUIOpenButton")
            {
                ActivateUIDrawers();
            }
        }
    }

    public void OnButtonClick()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "LilUpDrawerButton":
            print("UpDrawer foi clicado!");

            if(LilUpDrawerAnim.GetBool("isOpen"))
            {
                LilMiddleDrawer.interactable = true;
                LilUpDrawerAnim.SetBool("isOpen", false);
                audioSource.PlayOneShot(audioClip);
                break;
            }

            if(!LilUpDrawerAnim.GetBool("isOpen"))
            {
                LilMiddleDrawer.interactable = false;
                LilUpDrawerAnim.SetBool("isOpen", true);
                audioSource.PlayOneShot(audioClip);
                break;
            }
            break;


            case "LilMiddleDrawerButton":
                print("MiddleDrawer foi clicado!");

            if(LilMiddleDrawerAnim.GetBool("isOpen"))
            {
                LilUpDrawer.interactable = true;
                LilMiddleDrawerAnim.SetBool("isOpen", false);
                audioSource.PlayOneShot(audioClip);
                break;
            }

            if(!LilMiddleDrawerAnim.GetBool("isOpen"))
            {
                LilUpDrawer.interactable = false;
                LilMiddleDrawerAnim.SetBool("isOpen", true);
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

        if(!LilUIDrawers.activeSelf)
        {
            LilUIDrawers.SetActive(true);
            LilUIOpenButton.enabled = false;
            PianoCollider.enabled = false;
        }
    }
}