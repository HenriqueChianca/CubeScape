using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeController : MonoBehaviour
{
    public GameObject direita, esquerda, todoAberto, puzzleDireita, puzzleEsquerda, todoFechado;
    public bool direitaAberto = false, esquerdaAberto = false;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public BoxCollider LeftCollider, RightCollider;

    void Start()
    {

    }

    void Update()
    {
        if (direitaAberto && esquerdaAberto)
        {
            todoAberto.SetActive(true);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //audioSource.PlayOneShot(audioClip);

            if (Physics.Raycast(ray, out hit))
            {
                Collider colliderClicado = hit.collider; // Pegando o Collider do objeto clicado

                // Verificando se o Collider clicado � igual ao LeftCollider
                if (colliderClicado == LeftCollider)
                {
                    print("Esquerda Clicada");
                    if (puzzleEsquerda == null)
                    {
                        todoFechado.SetActive(false);
                        esquerda.SetActive(true);
                        esquerdaAberto = true;
                        LeftCollider.enabled = false;
                    }
                    else 
                    {
                        audioSource.PlayOneShot(audioClip);
                    }
                }

                // Verificando se o Collider clicado � igual ao RightCollider
                if (colliderClicado == RightCollider)
                {
                    print("Direita Clicada");
                    
                    todoFechado.SetActive(false);
                    direita.SetActive(true);
                    direitaAberto = true;
                    RightCollider.enabled = false;
                }
            }
        }
    }
}
