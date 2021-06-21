using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ScoresMenu : MonoBehaviour
{
    private ScoreStore ScoreStore;

    public Transform ItemsRoot;
    public ScoresMenuItem Item;
    
    public void Awake()
    {
        ScoreStore = GameObject.Find("ScoreStore").GetComponent<ScoreStore>();
    
        
        Initialize();
    }
    
    
    private void Initialize()
    {
        var highScores = ScoreStore.GetTopScores();

        foreach (var highScore in highScores)
        {
            var item = GameObject.Instantiate(Item.gameObject, ItemsRoot)
                .GetComponent<ScoresMenuItem>();
            
            item.Initialize(highScore.Key, highScore.Value);
        }
    }
}
