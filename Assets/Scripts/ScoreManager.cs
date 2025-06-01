using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private TMP_Text tMP_TotalScore;
    [SerializeField] private TMP_Text tMP_DailyScore;
    private int _totalScoreValue;
    private int _dailyScoreValue;

    public int _totalScore
    {
        get => _totalScoreValue;

        set => _totalScoreValue = value;
    }

    public int _dailyScore
    {
        get => _dailyScoreValue;

        set => _dailyScoreValue = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndOfTheDayScore()
    {
        _totalScore += _dailyScore;
        _dailyScore = 0;
    }

    public void AddScore(Fruit _fruit)
    {
        _dailyScore += _fruit._Score;
    }

    void Update()
    {
        tMP_TotalScore.text = $"{_totalScore}";
        tMP_DailyScore.text = $"{_dailyScore}";
    }
}
