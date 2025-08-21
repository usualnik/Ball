using UnityEngine;
using YG;

public class InterstitialAfterLose : MonoBehaviour
{
    private void Start()
    {
        Ball.Instance.OnDestroyBall += OnPlayerLose;       
      
    }

    private void OnDestroy()
    {
        Ball.Instance.OnDestroyBall -= OnPlayerLose;
    }

    private void OnPlayerLose()
    {
        YG2.InterstitialAdvShow();       
    }
}


