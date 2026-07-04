using TMPro;
using UnityEngine;

public class scoremanager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    public void AddScore(int additionalscore)
    {
        score += additionalscore;
        scoreText.text ="Score:"+ score;
    }

    



}
