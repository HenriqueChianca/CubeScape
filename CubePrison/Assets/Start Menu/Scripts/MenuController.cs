using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MenuController : MonoBehaviour
{
    public string nomeDaCena;
    public string link;
    public bool blur = false; // Variável booleana para controlar o efeito de blur

    // Referência para o Global Volume
    private Volume globalVolume;

    // Referência para o componente Depth of Field
    private DepthOfField depthOfField;

    private void Start()
    {
        // Obtém o Global Volume presente na cena
        globalVolume = FindObjectOfType<Volume>();

        // Obtém o componente Depth of Field do Global Volume
        globalVolume.profile.TryGet(out depthOfField);
    }

    // Função para carregar a cena do jogo
    public void CarregarCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    // Função para fechar o jogo
    public void FecharJogo()
    {
        Application.Quit();
    }

    // Função para abrir um link externo
    public void LinkExterno(string link)
    {
        Application.OpenURL(link);
    }
    public void MudarBlur()
    {
        blur = !blur;
    }
    // Função para ativar o efeito Depth of Field se a variável blur for verdadeira
    private void Update()
    {
        if (blur == true)
        {
            depthOfField.active = true;
        }
        else
        {
            depthOfField.active = false;
        }
    }
}
