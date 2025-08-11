using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    

    void Start()
    {
        Invoke("Load", 0.1f); // load with delay, so player data will be set
    }

   private void Load()
   {
        SceneManager.LoadScene(PlayerData.Instance.GetCurrentLevelIndex());
   }
}
