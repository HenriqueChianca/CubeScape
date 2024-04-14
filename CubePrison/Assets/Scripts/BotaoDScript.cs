using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoDScript : MonoBehaviour
{
    public GameObject objectToDisable;

    void Start()
    {
        // Encontra o botão dentro do mesmo Canvas
        Button button = GetComponent<Button>();

        // Adiciona um listener para o evento de clique do botão
        button.onClick.AddListener(DisableObject);
    }

    void DisableObject()
    {
        // Desativa o objeto do Canvas
        objectToDisable.SetActive(false);
    }
}
