using Unity.Cinemachine;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    [SerializeField] private float _targetAspect = 9f / 16f; // 9:16
    private CinemachineCamera _virtualCamera;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineCamera>();
        AdjustCamera();
    }

    private void AdjustCamera()
    {
        float currentAspect = (float)Screen.width / Screen.height;

        if (currentAspect > _targetAspect || currentAspect < _targetAspect)
        {
            float difference = currentAspect / _targetAspect;
            _virtualCamera.Lens.OrthographicSize /= difference;
        }
       
       
    }
}

