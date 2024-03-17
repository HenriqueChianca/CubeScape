using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string ItemName;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // Verifique se o botão pressionado é o botão esquerdo (botão 0)
        if (Input.GetMouseButtonDown(0))
        {
            // Faça algo quando o botão esquerdo do mouse for pressionado
            ItemSaver.GetInstance().AddString(ItemName);
            Destroy(gameObject);
        }
    }
}