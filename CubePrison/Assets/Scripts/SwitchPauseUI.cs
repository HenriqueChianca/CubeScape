using UnityEngine;

public class SwitchPauseUI : MonoBehaviour
{
    public bool pause = true;
    public GameObject pauseBtn, activeItem, upBtn;
    public void MudarPauseBtn()
    {
        pause = !pause;
        pauseBtn.SetActive(pause);
        activeItem.SetActive(pause);
        upBtn.SetActive(pause);
    }
}
