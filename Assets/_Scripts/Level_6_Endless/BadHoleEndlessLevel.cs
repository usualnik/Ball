using UnityEngine;

public class BadHoleEndlessLevel : MonoBehaviour
{
    private HighScoreTrigger _trigger;
    
    void Start()
    {
        _trigger = GetComponentInChildren<HighScoreTrigger>();

        _trigger.OnPlayerPassHole += Trigger_OnPlayerPassHole;

    }
    private void OnDestroy()
    {
        _trigger.OnPlayerPassHole -= Trigger_OnPlayerPassHole;
    }

    private void Trigger_OnPlayerPassHole()
    {
       Destroy(gameObject, 3f);
    }
}
