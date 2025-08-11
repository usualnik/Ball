using TMPro;
using UnityEngine;
using YG;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _highScoreText.text = PlayerData.Instance.GetHighScore().ToString();
    }

    public void UpdateHighScoreText()
    {
        _score++;
        
        PlayerData.Instance.SetHighScore(_score);

        _highScoreText.text = _score.ToString();
    }
}
