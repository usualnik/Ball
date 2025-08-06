using System.Collections;
using UnityEngine;

public class GoodHoleMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _goodHoleMusic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BackgroundMusic.Instance.SetBackGroundMusic(_goodHoleMusic);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           StartCoroutine(WaitUntilPlayBackground());
        }
    }

    private IEnumerator WaitUntilPlayBackground()
    {
        yield return new WaitForSeconds(1f);
        BackgroundMusic.Instance.SetBackGroundMusic(_backgroundMusic);
    }


}
