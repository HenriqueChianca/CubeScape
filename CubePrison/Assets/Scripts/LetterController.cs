using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    public GameObject SafeUI, LetterUI;
    public Button ButtonToOpenLetter;

    public void OnButtonClick()
    {
        print("clicou na carta");
        SafeUI.SetActive(false);
        LetterUI.SetActive(true);
        ButtonToOpenLetter.interactable = false;
    }
}
