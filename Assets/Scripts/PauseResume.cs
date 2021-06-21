using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResume : MonoBehaviour
{
    public GameObject pauseScreen;
    public Button pauseBtn;
    
    public void PauseOnClick()
    {
        pauseScreen.SetActive(true);
        this.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeOnClick()
    {
        pauseScreen.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }    
}
