using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasController : MonoBehaviour
{
    private static CanvasController instance;

    public int SelectedInInventory = 0, j;

    public GameObject mainObject; // Objeto principal a ser controlado

    public bool mainObjectVisible = false, SavingInInventory; // Flag para controlar a visibilidade do objeto principal

    public UIItem[] uiItems;

    private void Awake()
    {
        // Garantir que apenas uma instância da classe exista
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método estático para acessar a instância do singleton
    public static CanvasController GetInstance()
    {
        return instance;
    }

    void Update()
    {
        // Verificar se a tecla I foi pressionada
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Inverter a visibilidade do objeto principal ao pressionar a tecla I
            mainObjectVisible = !mainObjectVisible;
            mainObject.SetActive(mainObjectVisible);
        }
        List<int> itensUsados = new();

        // Verificar se uma nova string foi salva no PlayerPrefs
        for (int i = 0; i < ItemSaver.GetInstance().stringList.Count; i++)
        {
            for (j = 0; j < uiItems.Length; j++)
            {
                if (ItemSaver.GetInstance().stringList[i] == uiItems[j].key)
                {
                    //InventoryScript.onDIE?.Invoke(coloque o int que vai passar pelo evento);
                    uiItems[j].image.SetActive(true);
                    itensUsados.Add(j);
                    uiItems[j].slot = j;
                }
            }
        }

        for (int i = 0; i < uiItems.Length; i++)
        {
            if (!itensUsados.Contains(i))
            {
                uiItems[i].image.SetActive(false);
            }
        }
    }
}

[System.Serializable]
public class UIItem
{
    public GameObject image;
    public string key;
    public int slot;
}
