using System;
using Unity.Cinemachine;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance {  get; private set; }
    public event Action OnDestroyBall;
    public event Action OnWinGame;

    private Animator _animator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _animator = GetComponent<Animator>();      
    }

    public void DestoySelf()
    {
        OnDestroyBall?.Invoke();       
        Destroy(gameObject);
    }

    public void WinGame()
    {
        OnWinGame?.Invoke();
        Destroy(gameObject);
    }
    

}
