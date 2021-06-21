using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoresMenuItem: MonoBehaviour
    {
        public TMP_Text NameText;
        public TMP_Text ScoreText;

        public void Initialize(string name, int score)
        {
            NameText.text = name;
            ScoreText.text = score.ToString();
        }
    }
}