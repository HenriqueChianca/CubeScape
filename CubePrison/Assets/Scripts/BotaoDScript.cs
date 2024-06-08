using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoDScript : MonoBehaviour
{
    public GameObject PianoToDisable, SafeToDisable, MusicToDisable, NumbersToDisable, DrawerToDisable, LilDrawerToDisable, BooksToDisable, LetterToDisable;
    public Collider UIOpenButton, LilUIOpenButton, LilDrobeButton, PianoCollider, SafeCollider, DrawerCollider;
    public Button LetterButton;
    //aaaaaaaaaa

    public void OnButtonClick()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "PianoBackButton":
                PianoToDisable.SetActive(false);
                LilUIOpenButton.enabled = true;
                break;
            case "SafeBackButton":
                SafeToDisable.SetActive(false);
                SafeCollider.enabled = true;
                DrawerCollider.enabled = true;
                break;
            case "MusicBackButton":
                MusicToDisable.SetActive(false);
                break;
            case "NumbersBackButton":
                NumbersToDisable.SetActive(false);
                break;
            case "DrawerBackButton":
                DrawerToDisable.SetActive(false);
                UIOpenButton.enabled = true;
                break;
            case "LilDrawerBackButton":
                LilDrawerToDisable.SetActive(false);
                LilUIOpenButton.enabled = true;
                PianoCollider.enabled = true;
                break;
            case "LilDrobeBackButton":
                BooksToDisable.SetActive(false);
                LilDrobeButton.enabled = true;
                break;
            case "LetterBackButton":
                LetterToDisable.SetActive(false);
                LetterButton.interactable = true;
                break;
            default:
                print("por incrivel q pareça vc conseguiu apertar em um bglh q n existe");
                break;
        }
    }
}
