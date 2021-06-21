using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreStore : MonoBehaviour
{
    public Dictionary<string, int> Scores = new Dictionary<string, int>();
    
    public string UserName;
    
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void SaveScore(int score)
    {
        Debug.Log($"Score saved {UserName} - {score}");
        if (Scores.ContainsKey(UserName))
        {
            Scores[UserName] = score;
        } else {
        
            Scores.Add(UserName, score);
        }
    }
    
    public IEnumerable<KeyValuePair<string,int>> GetTopScores()
    {
        return Scores
            .OrderByDescending(x => x.Value)
            .Take(5);
    }
}
