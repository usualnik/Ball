using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BallInHoleTrigger : MonoBehaviour
{
    [Header("Настройки")]
    [Tooltip("Тег дырки")]
    public string GoodHoleTag = "GoodHole";
    public string BadHoleTag = "BadHole";


    [Tooltip("Время для удаления шарика (секунды)")]
    public float timeToDestroy = 1.0f;

    [Tooltip("Насколько шарик должен закрывать дырку (0-1)")]
    [Range(0.5f, 1f)]
    public float minOverlap = 0.9f;

    private float overlapTime;
    private CircleCollider2D holeCollider;
    private CircleCollider2D ballCollider;

    private void Awake()
    {
        ballCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(BadHoleTag) && other is CircleCollider2D)
        {
            holeCollider = other as CircleCollider2D;
        }else if (other.CompareTag(GoodHoleTag) && other is CircleCollider2D)
        {
            holeCollider = other as CircleCollider2D;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (holeCollider != null && other == holeCollider)
        {
            if (CheckOverlap())
            {
                overlapTime += Time.deltaTime;

                if (overlapTime >= timeToDestroy)
                {
                    if (holeCollider.CompareTag(BadHoleTag))
                    {
                        GetComponentInParent<Ball>().DestoySelf();
                        GetComponentInParent<Ball>().transform.position = holeCollider.transform.position;
                    }
                    else if (holeCollider.CompareTag(GoodHoleTag))
                    {
                        GetComponentInParent<Ball>().WinGame();
                        GetComponentInParent<Ball>().transform.position = holeCollider.transform.position;
                    }                  

                }
            }
            else
            {
                overlapTime = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == holeCollider)
        {
            holeCollider = null;
            overlapTime = 0f;
        }
    }

    private bool CheckOverlap()
    {
        float ballRadius = ballCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y);
        float holeRadius = holeCollider.radius * Mathf.Max(holeCollider.transform.lossyScale.x, holeCollider.transform.lossyScale.y);

        return ballRadius >= holeRadius * minOverlap;
    }
}