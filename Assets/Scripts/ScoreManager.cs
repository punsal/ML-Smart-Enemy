using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TrainedEnemyAgent[] enemies = new TrainedEnemyAgent[3]; 
    public Text[] currentScores = new Text[3];
    public Text[] bestScores = new Text[3];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].EnemyScore = 0;
            currentScores[i].text = System.Convert.ToString(0);
            bestScores[i].text = 0.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            currentScores[i].text = enemies[i].EnemyScore.ToString();

            int bestScore = System.Convert.ToInt32(bestScores[i].text),
                currentScore = System.Convert.ToInt32(currentScores[i].text);

            if(bestScore < currentScore)
            {
                bestScores[i].text = currentScore.ToString();
            }
        }
    }
}
