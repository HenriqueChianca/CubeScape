using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public string Requirement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // Verifique se o botão pressionado é o botão esquerdo (botão 0)
        if (Input.GetMouseButtonDown(0))
        {
            foreach (string savedString in ItemSaver.GetInstance().stringList)
            {
                if (savedString == Requirement)
                {
                    print("String encontrada");

                    ItemSaver itemSaver = ItemSaver.GetInstance();

                     // Procurar o índice da string correspondente à variável Requirement na lista de strings do ItemSaver
                    int indexToRemove = itemSaver.stringList.IndexOf(Requirement);

                    // Se o índice for encontrado, remova a string correspondente do PlayerPrefs
                    if (indexToRemove != -1)
                    {
                        itemSaver.RemoveString(indexToRemove);
                        print("String removida com sucesso do PlayerPrefs.");
                        break;
                    }
                    else
                    {
                        print("String correspondente não encontrada na lista de strings.");
                        break;
                    }
                }
            }
        }
    }
}