using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoDScript : MonoBehaviour
{
    public GameObject PianoToDisable, SafeToDisable, MusicToDisable, LetterToDisable;

    public void OnButtonClick()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "PianoBackButton":
                PianoToDisable.SetActive(false); 
                break;
            case "SafeBackButton":
                SafeToDisable.SetActive(false);
                break;
            case "MusicBackButton":
                MusicToDisable.SetActive(false);
                break;
            case "LetterBackButton":
                LetterToDisable.SetActive(false);
                break;
        }
    }
}
