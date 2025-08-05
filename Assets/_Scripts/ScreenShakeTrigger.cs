using Unity.Cinemachine;
using UnityEngine;

public class ScreenShakeTrigger : MonoBehaviour
{
    private CinemachineImpulseSource _impulseSource;
    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in");
            _impulseSource.GenerateImpulse();
        }
    }
}
