using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance {  get; private set; }
    public bool IsMobilePlatform { get; private set; }


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

        IsMobilePlatform = Application.isMobilePlatform;
    }   


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        
        var nextLevelBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;


        if(nextLevelBuildIndex <= SceneManager.sceneCountInBuildSettings)
        {
            YG2.InterstitialAdvShow();

            PlayerData.Instance.SetCurrentLevel(nextLevelBuildIndex);
          
            SceneManager.LoadScene(nextLevelBuildIndex);
        }       
       
    }
}
