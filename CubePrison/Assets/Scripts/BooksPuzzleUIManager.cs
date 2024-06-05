using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooksPuzzleUIManager : MonoBehaviour
{
    public GameObject LilUIDrawers, PianoUI;
    public Collider LilUIOpenButton, PianoCollider, LilDrawerCollider;
    
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
}
