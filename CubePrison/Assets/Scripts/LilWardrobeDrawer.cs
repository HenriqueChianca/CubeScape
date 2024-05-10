using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LilWardrobeDrawer : MonoBehaviour
{
    public GameObject LilUIDrawers, Inventory;
    public Button LilUpDrawer, LilMiddleDrawer;
    public Collider LilUIOpenButton;
    public Animator LilUpDrawerAnim, LilMiddleDrawerAnim;
    public Button Screwdriver;

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
                Inventory.SetActive(false);
                LilUpDrawerAnim.SetBool("isOpen", false);
                break;
            }

            if(!LilUpDrawerAnim.GetBool("isOpen"))
            {
                LilMiddleDrawer.interactable = false;
                LilUpDrawerAnim.SetBool("isOpen", true);
                break;
            }
            break;


            case "LilMiddleDrawerButton":
                print("MiddleDrawer foi clicado!");

            if(LilMiddleDrawerAnim.GetBool("isOpen"))
            {
                LilUpDrawer.interactable = true;
                Inventory.SetActive(false);
                LilMiddleDrawerAnim.SetBool("isOpen", false);
                break;
            }

            if(!LilMiddleDrawerAnim.GetBool("isOpen"))
            {
                LilUpDrawer.interactable = false;
                LilMiddleDrawerAnim.SetBool("isOpen", true);
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
        Inventory.SetActive(false);

        if(!LilUIDrawers.activeSelf)
        {
            LilUIDrawers.SetActive(true);
            LilUIOpenButton.enabled = false;
        }
    }
}