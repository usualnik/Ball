using UnityEngine;

public class ResetMusicToDefault : MonoBehaviour
{
    [SerializeField] private AudioClip m_Clip;
    void Start()
    {
        BackgroundMusic.Instance.SetBackGroundMusic(m_Clip);
    }

   
}
