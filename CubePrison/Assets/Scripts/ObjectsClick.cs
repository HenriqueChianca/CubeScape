using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsClick : MonoBehaviour
{
    public GameObject objectToToggle;
    public GameObject objectToActivate;

    // Update is called once per frame
    void Update()
    {
        // Detecta o clique do mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Cria um raio a partir da posição do mouse na tela
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verifica se o raio atingiu algum objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o objeto clicado é o objeto que queremos alternar
                if (hit.collider.gameObject == objectToToggle)
                {
                    // Alterna o estado ativo/inativo do objeto
                    objectToToggle.SetActive(!objectToToggle.activeSelf);

                    // Verifica se o objeto foi desativado e o outro objeto está definido
                    if (!objectToToggle.activeSelf && objectToActivate != null)
                    {
                        objectToActivate.SetActive(true);
                    }
                    // Verifica se o objeto foi ativado e o outro objeto está definido
                    else if (objectToToggle.activeSelf && objectToActivate != null)
                    {
                        objectToActivate.SetActive(false);
                    }
                }
            }
        }
    }
}
