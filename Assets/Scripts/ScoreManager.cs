using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int combo;

    private static int highScore;

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textHighScore;
    [SerializeField] private TextMeshProUGUI textCombo;

    private void Start()
    {
        textScore.text = "Score: " + score.ToString();
        textHighScore.text = "High Score: " + highScore.ToString();
        textCombo.text = "Combo: " + combo.ToString();
    }

    public void Score()
    {
        combo++;
        if (combo >= 50)
        {
            score += 300;
        }
        else if (combo >= 40)
        {
            score += 250;
        }
        else if (combo >= 30)
        {
            score += 200;
        }
        else if (combo >= 20)
        {
            score += 150;
        }
        else if (combo >= 10)
        {
            score += 120;
        }
        else
        {
            score += 100;
        }

        if (score > highScore)
        {
            highScore = score;
        }

        textScore.text = "Score: " + score.ToString();
        textHighScore.text = "High Score: " + highScore.ToString();
        textCombo.text = "Combo: " + combo.ToString();
    }

    public void LoseCombo()
    {
        combo = 0;
        textCombo.text = "Combo: " + combo.ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public int ScoreLose()
    {
        return score;
    }
}
