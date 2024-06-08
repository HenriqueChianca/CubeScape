using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlSpaceController : MonoBehaviour
{
    private static CrawlSpaceController instance;
    private Renderer CrawlSpace; // Declaração da variável de membro

    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool Opened = false;

    private void Awake()
    {
        // Garantir que apenas uma instância da classe exista
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static CrawlSpaceController GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Atribuir a referência do Renderer
        CrawlSpace = GameObject.Find("Teto_CrawlSpace").GetComponent<Renderer>();
    }

    public void OpenCrawlSpace()
    {
        if (CrawlSpace != null)
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetFloat("_isOpen", 1f); // Definindo como 1, que representa verdadeiro
            CrawlSpace.SetPropertyBlock(mpb); // Usando a variável de membro para acessar o Renderer
            audioSource.PlayOneShot(audioClip);
            Opened = true;
        }
    }

    public void OnMouseDown()
    {
        if(Opened)
        {
            print("vc zerou o jogo tlg");
            //fazer a lógica de endgame aqui...
        }
        else
        {
            print("ainda não zerou o game");
        }
    }   
}