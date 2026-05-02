using Unity.Mathematics;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    float currentTime = 0;
    [SerializeField] float maxTime = 3;
    [SerializeField] GameObject fishPrefab;
    [SerializeField] Collider2D mapBounds; // Drag your MapBounds object here

    void Update()
    {
        if (currentTime > maxTime)
        {
            currentTime = 0;

            Vector2 spawnPosition = GetSpawnPoint();
            Instantiate(fishPrefab, spawnPosition, quaternion.identity);
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    private Vector2 GetSpawnPoint()
    {
        Bounds b = mapBounds.bounds;
        float x = UnityEngine.Random.Range(b.min.x, b.max.x);
        float y = UnityEngine.Random.Range(b.min.y, b.max.y);
        return new Vector2(x, y);
    }
}