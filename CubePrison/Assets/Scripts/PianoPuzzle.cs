using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzle : MonoBehaviour
{
    private static PianoPuzzle instance;

    public List<int> PianoKeysRequirement = new List<int>();

    public List<int> PianoKeysPlayed = new List<int>();

    // Start is called before the first frame update
    private void Awake()
    {
        // Garantir que apenas uma instância da classe existaaaaaa
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
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

    public void AddIntToArray(int newInt)
    {
        PianoKeysPlayed.Add(newInt);
        CompareArraysAndExecuteFunction();
    }

    private void CompareArraysAndExecuteFunction()
    {
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
        
        if (PianoKeysPlayed.Count >= 6 && PianoKeysRequirement.Count >= 6)
            {
                if (PianoKeysRequirement[5] == PianoKeysPlayed[5])
                {

                    ExecuteFunction();
                }
            }
    }

    private void ExecuteFunction()
    {
        Debug.Log("Arrays iguais! Executando função...");
        CrawlSpaceController.GetInstance().OpenCrawlSpace();
    }
}
