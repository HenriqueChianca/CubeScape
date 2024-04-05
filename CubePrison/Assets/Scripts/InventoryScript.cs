using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryScript : CanvasController
{
    public int InventoryPosition;
    public bool Full = false;
    public static event Action <int> onDIE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SavingInInventory)
        {
            onDIE += EventReact;
        }
    }

    public void EventReact(int slot)
    {
        //fazer a função aqui, lembrar de desinscrever do evento
        onDIE -= EventReact;
    }

    public void OnButtonClick()
    {
        //pinto
    }
}