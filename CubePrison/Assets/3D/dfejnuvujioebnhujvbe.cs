using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dfejnuvujioebnhujvbe : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se a tecla Q foi pressionada
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Ativa o GameObject1 e desativa o GameObject2
            gameObject1.SetActive(true);
            gameObject2.SetActive(false);
        }

        // Verifica se a tecla W foi pressionada
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Ativa o GameObject2 e desativa o GameObject1
            gameObject1.SetActive(false);
            gameObject2.SetActive(true);
        }
    }
}

