using UnityEngine;

public class HighScoreTrigger : MonoBehaviour
{

    private bool _canAddScore = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _canAddScore)
        {
            HighScoreManager.Instance.UpdateHighScoreText();

            _canAddScore = false;
        }
    }
}
