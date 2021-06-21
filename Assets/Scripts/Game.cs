using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        public static Game Instance;

        public GameObject Player1WonText;
        public GameObject Player2WonText;

        public Text LevelText;
        public Button BackToMainMenuBtn;
        
        public GameState GameState { get; private set; }
        
        public Score Score;
        
        public void Awake()
        {
            Instance = this;
        }

        public void Start()
        {
            Time.timeScale = 1f;
            if (SceneManager.GetActiveScene().name == "Game1")
            {
                LevelText.GetComponent<Text>().text = "Level 1";
                GameObject.Find("ScoreManager").GetComponent<Score>().score = 0;
            }

            else if (SceneManager.GetActiveScene().name == "Game2")
            {
                LevelText.GetComponent<Text>().text = "Level 2";
            }

            else if (SceneManager.GetActiveScene().name == "Game3")
            {
                LevelText.GetComponent<Text>().text = "Level 3";
            }
        }

        public void Finish(PlayerId winner)
        {
            Score.SaveScore();
            StartCoroutine(EndGameRoutine(winner));
        }

        private IEnumerator EndGameRoutine(PlayerId winner)
        {
            yield return new WaitForSeconds(0.4f);
            Time.timeScale = 0f;
            if (winner == PlayerId.Player1)
            {
                if (SceneManager.GetActiveScene().name == "Game1")
                {
                    SceneManager.LoadScene("Game2");
                }

                else if (SceneManager.GetActiveScene().name == "Game2")
                {
                    SceneManager.LoadScene("Game3");
                }

                else if (SceneManager.GetActiveScene().name == "Game3")
                {
                    Player1WonText.SetActive(true);
                    BackToMainMenuBtn.gameObject.SetActive(true);
                }
            }
            else
            {
                SceneManager.LoadScene("Game1");
                //Player2WonText.SetActive(true);
                //BackToMainMenuBtn.gameObject.SetActive(true);
            }
        }
    }
}
