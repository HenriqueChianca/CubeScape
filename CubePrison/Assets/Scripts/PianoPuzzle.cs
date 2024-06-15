using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoPuzzle : MonoBehaviour
{
    private static PianoPuzzle instance;

    public List<int> PianoKeysRequirement = new List<int>();

    public List<int> PianoKeysPlayed = new List<int>();

    public Image image;

    private string revealProperty = "_Reveal";

    public float PreviousRevealValue = 0f, _time = 1f;
    public bool Notes = false;

    // Start is called before the first frame update
    private void Awake()
    {
        // Garantir que apenas uma instância da classe existaaaaaa
        if (instance == null)
        {
            instance = this;
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
        image.material.SetFloat("_Reveal", 0f);
    }

    public void AddIntToArray(int newInt)
    {
        PianoKeysPlayed.Add(newInt);

        if (PianoKeysPlayed.Count == 1)
        {
            if (PianoKeysRequirement[0] == PianoKeysPlayed[0])
            {
                PreviousRevealValue = 0.32f;
                StartCoroutine(ChangeRevealValueOverTime(0f, 0.32f, _time));
            }
        }

        if (PianoKeysPlayed.Count == 2)
        {
            if (PianoKeysRequirement[1] == PianoKeysPlayed[1])
            {
                PreviousRevealValue = 0.44f;
                StartCoroutine(ChangeRevealValueOverTime(0.32f, 0.44f, _time));
            }
        }

        if (PianoKeysPlayed.Count == 3)
        {
            if (PianoKeysRequirement[2] == PianoKeysPlayed[2])
            {
                PreviousRevealValue = 0.59f;
                StartCoroutine(ChangeRevealValueOverTime(0.44f, 0.59f, _time));
            }
        }

        if (PianoKeysPlayed.Count == 4)
        {
            if (PianoKeysRequirement[3] == PianoKeysPlayed[3])
            {
                PreviousRevealValue = 0.72f;
                StartCoroutine(ChangeRevealValueOverTime(0.59f, 0.72f, _time));
            }
        }

        if (PianoKeysPlayed.Count == 5)
        {
            if (PianoKeysRequirement[4] == PianoKeysPlayed[4])
            {
                PreviousRevealValue = 0.84f;
                StartCoroutine(ChangeRevealValueOverTime(0.72f, 0.84f, _time));
            }
        }
        
        CompareArraysAndExecuteFunction();
    }

    public void NotesSeen()
    {
        Notes = true;
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
                StartCoroutine(ChangeRevealValueOverTime(PreviousRevealValue, 0f, _time));
                PreviousRevealValue = 0f;
                return;
            }
        }
        
        if (PianoKeysPlayed.Count >= 6 && PianoKeysRequirement.Count >= 6)
        {  
            if (PianoKeysRequirement[5] == PianoKeysPlayed[5])
            {
                StartCoroutine(ChangeRevealValueOverTime(PreviousRevealValue, 1f, _time));
                PreviousRevealValue = 1f;
                ExecuteFunction();
            }
        }
    }

    private void ExecuteFunction()
    {
        if (Notes)
        {
            Debug.Log("Arrays iguais! Executando função...");
            CrawlSpaceController.GetInstance().OpenCrawlSpace();
        }
        else
        {
            Debug.Log("Falta ver a  partitura");
            PianoKeysPlayed.Clear();
        }
        
    }


    IEnumerator ChangeRevealValueOverTime(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0f;

        
        Material mat = image.material;

        if (mat != null)
        {
            while (elapsedTime < duration)
            {        
                float currentValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
                mat.SetFloat(revealProperty, currentValue);
            
                elapsedTime += Time.deltaTime;

                yield return null;
            }
            mat.SetFloat(revealProperty, endValue);
        }
    }
}