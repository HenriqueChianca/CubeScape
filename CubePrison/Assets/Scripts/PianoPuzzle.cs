using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzle : MonoBehaviour
{
    private static PianoPuzzle instance;

    public List<int> PianoKeysRequirement = new List<int>();

    public List<int> PianoKeysPlayed = new List<int>();
    public int PianoCount = 0;
    
    // Start is called before the first frame update
    private void Awake()
    {
        // Garantir que apenas uma instância da classe exista
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static PianoPuzzle GetInstance()
    {
        return instance;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddIntToArray(int newInt)
    {
        PianoKeysPlayed.Add(newInt);
        CompareArraysAndExecuteFunction();
    }

    private void CompareArraysAndExecuteFunction()
    {
        // Verificar se os dois arrays têm o mesmo número de elementos
        /*if (PianoKeysRequirement.Count != PianoKeysPlayed.Count)
        {
            // Se os arrays tiverem números diferentes de elementos, limpar o array PianoKeysPlayed
            PianoKeysPlayed.Clear();
            return;
        }*/

        // Verificar se os elementos dos dois arrays são iguais
        for (int i = 0; i < PianoKeysPlayed.Count; i++)
        {
            if (PianoKeysRequirement[i] != PianoKeysPlayed[i])
            {
                // Se algum elemento for diferente, limpar o array PianoKeysPlayed
                PianoKeysPlayed.Clear();
                return;
            }
        }
        if (PianoKeysPlayed[8] != null && PianoKeysRequirement[8] != PianoKeysPlayed[8])
        {
            ExecuteFunction();
        }
    }

    private void ExecuteFunction()
    {
        // Coloque aqui a lógica que você deseja executar quando os arrays forem iguais
        Debug.Log("Arrays iguais! Executando função...");
    }
}
