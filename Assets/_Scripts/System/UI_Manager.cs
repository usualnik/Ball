using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _looseScreen;
    [SerializeField] private GameObject _winGameScreen;   
    
    //Tutorial
    [SerializeField] private GameObject _mobileTutorial;
    [SerializeField] private GameObject _pcTutorial;


    private void Start()
    {
        if (GameManager.Instance.IsMobilePlatform && _mobileTutorial != null)
        {
            _mobileTutorial.SetActive(true);
        }
        else if (!GameManager.Instance.IsMobilePlatform && _pcTutorial != null)
        {
            _pcTutorial.SetActive(true);
        }
        else
        {

        }

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
        BackgroundMusic.Instance.SetBackGroundMusic(null);
        _winGameScreen.SetActive(true);
        AudioManager.Instance.Play("Win");

    }
}
