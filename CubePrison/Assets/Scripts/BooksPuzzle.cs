using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksPuzzle : MonoBehaviour
{
    // Arrays que armazenam os game objects, seus índices e suas transformadas
    public GameObject[] gameObjects = new GameObject[10];
    public CriadoController CriadoController;
    public int[] ints = new int[10];
    public List<Transform> transforms = new List<Transform>(10);

    public AudioSource audioSource;
    public AudioClip LivroMexendo, GoodAudioClip;

    // Índices dos últimos botões clicados
    private int lastClickedButtonIndex = -1, lastClickedButtonIndex2 = -1;

    // Strings que representam as ordens inicial e atual dos livros e o requisito do quebra-cabeça
    public string Requirement = "0123456789";
    public string BooksOrder = "";
    public string PuzzleRequirement = "1023456789";

    void Start()
    {
        // Preenche os arrays transforms[] e ints[] com os valores iniciais
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                transforms[i] = gameObjects[i].transform;
                ints[i] = i;
            }
            else
            {
                transforms[i] = null;
                ints[i] = -1;
            }
        }

        // Preenche a string BooksOrder com base nos índices originais dos game objects
        FillBooksOrder();
    }

    private void FillBooksOrder()
    {
        // Reinicia a string BooksOrder
        BooksOrder = "";
        // Preenche a string com a ordem dos livros ativos
        for (int i = 0; i < ints.Length; i++)
        {
            if (gameObjects[ints[i]] != null)
            {
                BooksOrder += Requirement[ints[i]];
            }
        }
    }

    public void OnButtonClick()
    {
        // Obtém o nome do botão clicado
        //string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        // Obtém o índice do botão clicado
        int buttonIndex = transforms.IndexOf(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform); //GetButtonIndex(buttonName);

        // Verifica se o botão clicado é válido e se não é o mesmo que os últimos dois clicados
        if (buttonIndex != -1 && buttonIndex != lastClickedButtonIndex && buttonIndex != lastClickedButtonIndex2)
        {
            // Se for o primeiro clique
            if (lastClickedButtonIndex == -1)
            {
                // Atualiza a transformada do botão clicado
                transforms[buttonIndex] = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform;
                lastClickedButtonIndex = buttonIndex;
            }
            else // Se for o segundo clique
            {
                // Verifica se as transformadas dos botões são válidas
                if (transforms[lastClickedButtonIndex] != null && transforms[buttonIndex] != null)
                {
                    // Troca as posições dos dois botões
                    Vector3 tempPosition = transforms[lastClickedButtonIndex].position;
                    transforms[lastClickedButtonIndex].position = transforms[buttonIndex].position;
                    transforms[buttonIndex].position = tempPosition;

                    // Atualiza os índices e as transformadas
                    int tempIndex = ints[lastClickedButtonIndex];
                    ints[lastClickedButtonIndex] = ints[buttonIndex];
                    ints[buttonIndex] = tempIndex;

                    Transform tempTransform = transforms[lastClickedButtonIndex];
                    transforms[lastClickedButtonIndex] = transforms[buttonIndex];
                    transforms[buttonIndex] = tempTransform;

                    audioSource.PlayOneShot(LivroMexendo);
                }
                // Reinicia os índices dos últimos dois botões clicados
                lastClickedButtonIndex2 = -1;
                lastClickedButtonIndex = -1;

                // Atualiza a string BooksOrder com base na ordem dos game objects
                UpdateBooksOrder();
            }
        }
    }

   private int GetButtonIndex(string buttonName)
    {
        // Obtém o índice do botão com base no seu nome
        switch (buttonName)
        {
            case "PesadeloButton":
                return 0;
            case "CulpaButton":
                return 1;
            case "InfernoButton":
                return 2;
            case "ObscuridadeButton":
                return 3;
            case "AngustiaButton":
                return 4;
            case "PerdaoButton":
                return 0;
            case "EscuridaoButton":
                return 6;
            case "SolidaoButton":
                return 7;
            case "LamentacoesButton":
                return 8;
            case "AbismoButton":
                return 4;
            default:
                return -1;
        }
    }

    private void UpdateBooksOrder()
    {
        // Atualiza a string BooksOrder com base nos índices originais dos game objects
        BooksOrder = "";
        for (int i = 0; i < ints.Length; i++)
        {
            BooksOrder += Requirement[ints[i]];
        }

        // Verifica se a string BooksOrder é igual à string PuzzleRequirement
        if (BooksOrder == PuzzleRequirement)
        {
            // Se forem iguais, chama a função PuzzleSolved
            PuzzleSolved();
        }
    }

    private void PuzzleSolved()
    {
        Debug.Log("puzzle dos livros resolvido");
        audioSource.PlayOneShot(GoodAudioClip);
        CriadoController.PuzzleLivroCompleto();
    }
}