using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooksPuzzleUIManager : MonoBehaviour
{
    public GameObject LilUIDrawers, PianoUI, SafeUI;
    public Collider LilUIOpenButton, PianoCollider, LilDrawerCollider, SafeCollider, DrawersCollider;
    
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
            if (hit.collider != null && hit.collider.gameObject.name == "DetectionBoxPiano")
            {
                print("Piano collider clicked");
                ActivateUIPiano();
            }
            if (hit.collider != null && hit.collider.gameObject.name == "SafeCollider")
            {
                print("Safe collider clicked");
                ActivateUISafe();
            }
        }
    }

    public void ActivateUIDrawers()
    {
        if(LilUIDrawers != null)
        {
            if(!LilUIDrawers.activeSelf)
            {
                LilUIDrawers.SetActive(true);
                LilUIOpenButton.enabled = false;
            }
        }
        
    }
    public void ActivateUIPiano()
    {
        if(PianoUI != null)
        {
            if(!PianoUI.activeSelf)
            {
                PianoUI.SetActive(true);
                PianoCollider.enabled = false;
                LilDrawerCollider.enabled = false;
            }
        }
        
    }

    public void ActivateUISafe()
    {
        if(SafeUI != null)
        {
            if(!SafeUI.activeSelf)
            {
                SafeUI.SetActive(true);
                SafeCollider.enabled = false;
                DrawersCollider.enabled = false;
            }
        }
        
    }
}
