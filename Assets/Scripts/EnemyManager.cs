using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  float currentTime = 0;
  [SerializeField] float maxTime = 3;
  [SerializeField] GameObject ghostPrefab;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (currentTime > maxTime)
    {
      currentTime = 0;

      UnityEngine.Vector2 spawnPosition;

      if (UnityEngine.Random.value > 0.5f)
      {
        float x = UnityEngine.Random.value < 0.5f ? 0 : Screen.width;
        float y = UnityEngine.Random.Range(0, Screen.height);
        spawnPosition = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector2(x, y));

      }
      else
      {
        float x = UnityEngine.Random.Range(0, Screen.width);
        float y = UnityEngine.Random.value < 0.5f ? 0 : Screen.height;
        spawnPosition = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector2(x, y));
      }

      GameObject ghost = Instantiate(ghostPrefab, spawnPosition, quaternion.identity);
    }
    else
    {
      currentTime += Time.deltaTime;
    }
  }
}
