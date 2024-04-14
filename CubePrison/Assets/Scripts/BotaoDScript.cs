using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoDScript : MonoBehaviour
{
    public GameObject objectToDisable;

    void Start()
    {
        // Encontra o bot�o dentro do mesmo Canvas
        Button button = GetComponent<Button>();

        // Adiciona um listener para o evento de clique do bot�o
        button.onClick.AddListener(DisableObject);
    }

    void DisableObject()
    {
        // Desativa o objeto do Canvas
        objectToDisable.SetActive(false);
    }
}
