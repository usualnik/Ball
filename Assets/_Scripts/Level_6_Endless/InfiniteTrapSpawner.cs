using UnityEngine;

public class InfiniteTrapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private float spawnHeightAbovePlayer = 10f;
    [SerializeField] private float minDistanceBetweenGroups = 3f; 
    [SerializeField] private float maxDistanceBetweenGroups = 7f; 
    [SerializeField] private int trapsPerGroup = 3; 
    [SerializeField] private float spreadRangeX = 3f; 
    [SerializeField] private float spreadRangeY = 1f; 
    [Range(0, 1)] public float edgeTrapChance = 0.3f; 

    private Transform player;
    private float nextSpawnY;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextSpawnY = player.position.y + spawnHeightAbovePlayer;
    }

    void Update()
    {
        if (player == null)
            return;

        if (player.position.y > nextSpawnY - spawnHeightAbovePlayer)
        {
            SpawnTrapGroup();
            nextSpawnY += Random.Range(minDistanceBetweenGroups, maxDistanceBetweenGroups);
        }
    }

    void SpawnTrapGroup()
    { 
        // Спавн ловушки на краю (если выпал шанс)
        if (Random.value < edgeTrapChance)
        {
            float edgeX = (Random.Range(0, 2) == 0) ? -spreadRangeX : spreadRangeX;
            float randomYOffset = Random.Range(-spreadRangeY, spreadRangeY); 
            Vector3 edgePosition = new Vector3(edgeX, nextSpawnY + randomYOffset, 0);
            Instantiate(trapPrefab, edgePosition, Quaternion.identity);
        }

        
        for (int i = 0; i < trapsPerGroup - 1; i++)
        {
            float randomX = Random.Range(-spreadRangeX, spreadRangeX);
            float randomYOffset = Random.Range(-spreadRangeY, spreadRangeY); 
            Vector3 spawnPosition = new Vector3(randomX, nextSpawnY + randomYOffset, 0);
            Instantiate(trapPrefab, spawnPosition, Quaternion.identity);
        }
    }
}