using System;
using UnityEngine;
using YG;

[System.Serializable]
public class Data
{
    public int currentLevelIndex = 1, highScore = 0;  
}

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }

    public event Action OnCurrentLevelChanged;
    public event Action OnHighScoreChanged;  

    [SerializeField] private Data data;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameObject.transform.SetParent(null, false);
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        if (YG2.saves.YandexServerData != null && YG2.saves.YandexServerData != data 
            && YG2.saves.YandexServerData.currentLevelIndex > 0) 
        {
            SetPlayerData(YG2.saves.YandexServerData);
        }
    }

    private void SetPlayerData(Data yandexServerData)
    {
        this.data = yandexServerData;
    }
    private void SavePlayerDataToYandex()
    {
        YG2.saves.YandexServerData = this.data;
        YG2.SaveProgress();
    }

    #region Get
    public int GetCurrentLevelIndex() => data.currentLevelIndex;
    public int GetHighScore() => data.highScore;
   
    #endregion       

    #region Set
    public void SetCurrentLevel(int level)
    {
        data.currentLevelIndex = level;
        OnCurrentLevelChanged?.Invoke();
        SavePlayerDataToYandex();

    }
    public void SetHighScore(int highScore) 
    {
        data.highScore = highScore;
        OnHighScoreChanged?.Invoke();
        SavePlayerDataToYandex();       
    }
    #endregion

}
