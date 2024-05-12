using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooksPuzzleUIManager : MonoBehaviour
{
    public GameObject LilUIDrawers, Inventory;
    public Collider LilUIOpenButton;
    
    public void OnMouseDown()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            
            if (hit.collider != null && hit.collider.gameObject.name == "LilDrobeButton")
            {
                ActivateUIDrawers();
            }
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
