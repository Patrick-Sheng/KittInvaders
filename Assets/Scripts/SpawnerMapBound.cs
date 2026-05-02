using UnityEngine;

public class SpawnerMapBound : MonoBehaviour
{
    [SerializeField] private Collider2D mapBounds;
    
    Vector2 GetSpawnPoint()
    {
        Bounds bounds = mapBounds.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(x, y);
    }
}
