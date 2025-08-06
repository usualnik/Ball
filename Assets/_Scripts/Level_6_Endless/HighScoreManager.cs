using TMPro;
using UnityEngine;

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
        _highScoreText.text = _score.ToString();
    }

    public void UpdateHighScoreText()
    {
        _score++;

        _highScoreText.text = _score.ToString();
    }
}
