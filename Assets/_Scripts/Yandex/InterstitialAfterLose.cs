using UnityEngine;
using YG;

public class InterstitialAfterLose : MonoBehaviour
{
    private const string LOSE_COUNT_KEY = "LoseCount";

    private int _loseCount = 0;

    private void Start()
    {
        Ball.Instance.OnDestroyBall += OnPlayerLose;
        
        _loseCount = PlayerPrefs.GetInt(LOSE_COUNT_KEY, 0);
    }

    private void OnDestroy()
    {
        Ball.Instance.OnDestroyBall -= OnPlayerLose;
    }

    private void OnPlayerLose()
    {
        _loseCount++;
        PlayerPrefs.SetInt(LOSE_COUNT_KEY, _loseCount); 

        if (_loseCount % 2 == 0)
        {
            YG2.InterstitialAdvShow();
        }
    }
}


