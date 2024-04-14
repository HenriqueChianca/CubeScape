using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoDScript : MonoBehaviour
{
    public GameObject PianoToDisable, SafeToDisable;

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
        }
    }
}
