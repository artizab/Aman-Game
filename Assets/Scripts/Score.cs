using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public int _score;
    [SerializeField] public int _topScore;
    [SerializeField] private Text _topScoreText;
    [SerializeField] private Text _scoreText;

    private void Awake()
    {
        _score = PlayerPrefs.GetInt("score");
        _scoreText.text = _score.ToString();
        _topScore = PlayerPrefs.GetInt("topScore");
        _topScoreText.text = _topScore.ToString();
    }

    private void Update()
    {
        PlayerPrefs.SetInt("score", _score);
        PlayerPrefs.SetInt("topScore", _topScore);
    }

    public void IncreaseTopScore()
    {
        if (_score > _topScore)
        {
            _topScore = _score;
        }
        _topScoreText.text = _topScore.ToString();
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}










