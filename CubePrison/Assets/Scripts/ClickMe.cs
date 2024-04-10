using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMe : MonoBehaviour
{
    public GameObject Desativar, Ativar;
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
            Ativar.SetActive(true);
            Desativar.SetActive(false);
        }
    }
}
