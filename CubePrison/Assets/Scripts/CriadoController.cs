using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadoController : MonoBehaviour
{
    public GameObject DireitaAberta, EsquerdaAberta, todoAberto, puzzleDireita, puzzleEsquerda, todoFechado, EsquerdaAbertaDireitaFechada, EsquerdaAbertaDireitaMetalFechado;
    public bool direitaAberto = false, esquerdaAberto = false, LivrosCompleto = false;
    public AudioSource audioSource;
    public AudioClip PortaDireitaTrancadaSom, PortaEsquerdaTrancadaSom, PortaEsquerdaAbriu;
    public BoxCollider LeftCollider, RightCollider, RightMetalCollider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Se não existir, adiciona um novo componente AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Collider colliderClicado = hit.collider; // Pegando o Collider do objeto clicado

                // Verificando se o Collider clicado � igual ao LeftCollider
                if (colliderClicado == LeftCollider)
                {
                    print("Esquerda Clicada");
                    if(puzzleEsquerda)
                    {
                        audioSource.PlayOneShot(PortaEsquerdaTrancadaSom);
                    }
                    if (puzzleEsquerda == null && !DireitaAberta.activeSelf)
                    {
                        todoFechado.SetActive(false);
                        EsquerdaAberta.SetActive(true);
                        esquerdaAberto = true;
                        LeftCollider.enabled = false;
                    }
                    if(puzzleEsquerda == null && DireitaAberta.activeSelf)
                    {
                        todoFechado.SetActive(false);

                    }
                }

                // Verificando se o Collider clicado � igual ao RightCollider
                if (colliderClicado == RightCollider)
                {
                    print("Direita Clicada");
                    if(!LivrosCompleto)
                    {
                        audioSource.PlayOneShot(PortaDireitaTrancadaSom);
                    }
                    if(LivrosCompleto && !esquerdaAberto)
                    {
                        todoFechado.SetActive(false);
                        EsquerdaAbertaDireitaMetalFechado.SetActive(true);
                        RightCollider.enabled = false;
                    }
                    if(LivrosCompleto && esquerdaAberto)
                    {
                        EsquerdaAberta.SetActive(false);
                        EsquerdaAbertaDireitaMetalFechado.SetActive(true);
                        RightCollider.enabled = false;
                    }
                    if (puzzleDireita == null && esquerdaAberto)
                    {
                        EsquerdaAbertaDireitaFechada.SetActive(false);
                        DireitaAberta.SetActive(true);
                        direitaAberto = true;
                        RightCollider.enabled = false;
                    }
                }
            }
        }
    }

    public void PuzzleLivroCompleto()
    {
        audioSource.PlayOneShot(PortaEsquerdaAbriu);
        LivrosCompleto = true;
    }
}
