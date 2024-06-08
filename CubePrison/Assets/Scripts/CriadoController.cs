using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadoController : MonoBehaviour
{
    public GameObject direita, direitaMetal, esquerda, todoAberto, abertoMetal, puzzleEsquerda, puzzleDireita, todoFechado;
    public bool direitaAberto = false, esquerdaAberto = false;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public BoxCollider LeftCollider, RightCollider;
    public bool BooksPuzzleComplete = false;

    void Start()
    {

    }

    void Update()
    {
        if (direitaAberto && esquerdaAberto && BooksPuzzleComplete && puzzleDireita != null)
        {
            abertoMetal.SetActive(true);
        }

        if (direitaAberto && esquerdaAberto && BooksPuzzleComplete && puzzleDireita == null)
        {
            abertoMetal.SetActive(false);
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

                    if(puzzleEsquerda == null)
                    {
                        todoFechado.SetActive(false);
                        esquerda.SetActive(true);
                        esquerdaAberto = true;
                        LeftCollider.enabled = false;
                    }
                    else
                    {
                        //tocar som aqui tb
                        print("falta a chave prateada");
                    }
                    
                }

                // Verificando se o Collider clicado � igual ao RightCollider
                if (colliderClicado == RightCollider)
                {
                    print("Direita Clicada");
                    
                    if (BooksPuzzleComplete)
                    {
                        todoFechado.SetActive(false);
                        direitaMetal.SetActive(true);
                        direitaAberto = true;
                        RightCollider.enabled = false;
                    }
                    else
                    {
                        //botar som aqui depois...
                        print("falta o puzzle dos livros ser completo");
                    }
                    
                }
            }
        }
        if(puzzleDireita == null)
        {
            direitaMetal.SetActive(false);
            direita.SetActive(true);
        }
    }

    public void PuzzleLivroCompleto()
    {
        BooksPuzzleComplete = true;
        //tocar um audio aq tb da porta destrancando
    }
}
