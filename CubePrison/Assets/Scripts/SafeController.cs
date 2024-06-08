using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeController : MonoBehaviour
{
    public Text textObject;
    private int[] code = new int[4]; // Array para armazenar o código
    public string correctCode = "1234"; // Código correto
    public AudioSource audioSource;
    public AudioClip audioClip, BadAudioClip, GoodAudioClip;

    public GameObject ClosedSafe, OpenedSafe, Keys;


    public void OnEnable()
    {
        ClosedSafe.SetActive(true);
        OpenedSafe.SetActive(false);
        Keys.SetActive(true);
    }
    public void OnButtonClick()
    {

        // Obtém o nome do GameObject do botão que foi clicado
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        audioSource.PlayOneShot(audioClip);

        // Verifica o nome do botão e atualiza o texto conforme necessário
        switch (buttonName)
        {
            case "Button0":
            case "Button1":
            case "Button2":
            case "Button3":
            case "Button4":
            case "Button5":
            case "Button6":
            case "Button7":
            case "Button8":
            case "Button9":
                // Converte o último caractere do nome do botão em um número
                int value = int.Parse(buttonName.Substring(buttonName.Length - 1));
                UpdateCode(value);
                UpdateText();
                break;
            default:
                Debug.LogWarning("Botão não reconhecido: " + buttonName);
                break;
        }

        // Verifica o código somente quando todos os dígitos foram inseridos
        if (IsCodeComplete())
        {
            CheckCode();
        }
    }

    // Função para atualizar o código com o valor especificado
    private void UpdateCode(int value)
    {
        // Desloca todos os números do código para a esquerda
        for (int i = 0; i < code.Length - 1; i++)
        {
            code[i] = code[i + 1];
        }

        // Atualiza o último número do código com o valor especificado
        code[code.Length - 1] = value;
    }

    // Função para atualizar o texto com o código atual
    private void UpdateText()
    {
        if (textObject != null)
        {
            // Atualiza o texto com o código atual
            textObject.text = string.Join(" ", code);
        }
        else
        {
            Debug.LogWarning("O objeto de texto não está atribuído.");
        }
    }

    // Função para verificar se o código está completo
    private bool IsCodeComplete()
    {
        // Verifica se todos os elementos do código são diferentes de zero
        foreach (int digit in code)
        {
            if (digit == 0)
            {
                return false;
            }
        }
        return true;
    }

    // Função para verificar se o código digitado está correto
    private void CheckCode()
    {
        // Verifica se a string do código atual é igual ao código correto
        if (string.Join("", code) == correctCode)
        {
            Debug.Log("Código correto!");
            ClosedSafe.SetActive(false);
            Keys.SetActive(false);
            OpenedSafe.SetActive(true);
            audioSource.PlayOneShot(GoodAudioClip);
        }
        else
        {
            ClearText();
        }
    }

    // Função para limpar o texto
    private void ClearText()
    {
        // Limpa o array do código
        for (int i = 0; i < code.Length; i++)
        {
            code[i] = 0;
        }
        
        audioSource.PlayOneShot(BadAudioClip);
        // Atualiza o texto para mostrar os caracteres vazios
        UpdateText();
    }
}