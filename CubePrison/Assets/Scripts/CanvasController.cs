using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject mainObject; // Objeto principal a ser controlado
    public GameObject[] additionalObjects; // Array de objetos adicionais a serem controlados

    private bool mainObjectVisible = false; // Flag para controlar a visibilidade do objeto principal

    void Update()
    {
        // Verificar se a tecla I foi pressionada
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Inverter a visibilidade do objeto principal ao pressionar a tecla I
            mainObjectVisible = !mainObjectVisible;
            mainObject.SetActive(mainObjectVisible);
        }

        // Verificar se uma nova string foi salva no PlayerPrefs
        for (int i = 0; i < ItemSaver.GetInstance().stringList.Count; i++)
        {
            // Verificar se a string salva corresponde a um dos objetos adicionais
            if (i < additionalObjects.Length)
            {
                // Ativar o objeto adicional correspondente
                additionalObjects[i].SetActive(true);
            }
        }

        // Desativar os objetos adicionais extras que não têm uma string correspondente salva
        for (int i = ItemSaver.GetInstance().stringList.Count; i < additionalObjects.Length; i++)
        {
            additionalObjects[i].SetActive(false);
        }
    }
}