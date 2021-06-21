using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Button thisBtn;
    public InputField inputName;
    
    void Start()
    {
        
    }

    public void ChangeSceneOnClick()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (thisBtn.name == "StartBtn" && inputName.text != "")
            {
                SceneManager.LoadScene("Game1");
                GameObject.Find("ScoreStore").GetComponent<ScoreStore>().UserName = inputName.text;
            }

            else if (thisBtn.name == "SettingsBtn")
            {
                SceneManager.LoadScene("Settings");
            }

            else if (thisBtn.name == "DirectionsBtn")
            {
                SceneManager.LoadScene("Directions");
            }

            else if (thisBtn.name == "HighScoreBtn")
            {
                SceneManager.LoadScene("Scores");
            }
        }

        else if (SceneManager.GetActiveScene().name == "Settings" || SceneManager.GetActiveScene().name == "Scores" || SceneManager.GetActiveScene().name == "Directions")
        {
            if (thisBtn.name == "GoBackBtn")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        else if (SceneManager.GetActiveScene().name == "Game1" || SceneManager.GetActiveScene().name == "Game2" || SceneManager.GetActiveScene().name == "Game3")
        {
            if (thisBtn.name == "MainMenuBtn" || thisBtn.name == "MainMenuEndBtn")
            {
                GameObject.Find("ScoreManager").GetComponent<Score>().SaveScore();
                SceneManager.LoadScene("MainMenu");
            }
        }


    }
    
    
}
