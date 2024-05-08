using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LilWardrobeDrawer : MonoBehaviour
{
    public GameObject UIDrawers, Inventory;
    public Button UpDrawer, MiddleDrawer, BottomDrawer, MostBottomDrawer;
    public Collider UIOpenButton;

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
                ActivateUIDrawers();
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

            /*if(!MiddleDrawer.interactable && !BottomDrawer.interactable)
                {
                    MiddleDrawer.interactable = true;
                    BottomDrawer.interactable = true;
                    Inventory.SetActive(false);
                }

            MiddleDrawer.interactable = false;
            BottomDrawer.interactable = false;

            Inventory.SetActive(false);*/

                break;

            case "MiddleDrawerButton":
                print("MiddleDrawer foi clicado!");

                /*UpDrawer.interactable = false;
                BottomDrawer.interactable = false;

                Inventory.SetActive(false);*/

                break;

            case "BottomDrawerButton":
                print("BottomDrawer foi clicado!");

                /*if(!UpDrawer.interactable && !MiddleDrawer.interactable)
                {
                    UpDrawer.interactable = true;
                    MiddleDrawer.interactable = true;
                    Inventory.SetActive(false);
                }

                MiddleDrawer.interactable = false;
                BottomDrawer.interactable = false;

                Inventory.SetActive(false);*/

                break;

            case "MostBottomDrawerButton":
                print("MostBottomDrawerButton foi clicado!");

                break;

            default:
                print("Outro collider foi clicado!");
                break;
        } 
    }

    public void ActivateUIDrawers()
    {
        Inventory.SetActive(false);

        if(!UIDrawers.activeSelf)
        {
            UIDrawers.SetActive(true);
            UIOpenButton.enabled = false;
        }
    }
}