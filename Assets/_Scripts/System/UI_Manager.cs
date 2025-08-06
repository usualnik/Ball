using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _looseScreen;
    [SerializeField] private GameObject _winGameScreen;

    private void Start()
    {
        Ball.Instance.OnDestroyBall += Ball_OnDestroyBall;
        Ball.Instance.OnWinGame += Ball_OnWinGame;
    }

    private void OnDestroy()
    {
        Ball.Instance.OnDestroyBall -= Ball_OnDestroyBall;
        Ball.Instance.OnWinGame -= Ball_OnWinGame;
    }

    private void Ball_OnDestroyBall()
    {
        _looseScreen.SetActive(true);
        AudioManager.Instance.Play("Loose");
    }


    private void Ball_OnWinGame()
    {
        _winGameScreen.SetActive(true);
        AudioManager.Instance.Play("Win");

    }
}
