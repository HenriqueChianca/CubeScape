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
        
        if (PianoKeysPlayed.Count >= 9 && PianoKeysRequirement.Count >= 9)
            {
                if (PianoKeysRequirement[8] == PianoKeysPlayed[8])
                {

                    ExecuteFunction();
                }
            }
    }

    private void ExecuteFunction()
    {
        Debug.Log("Arrays iguais! Executando função...");
        print("doidera");
        CrawlSpaceController.GetInstance().OpenCrawlSpace();
    }
}
