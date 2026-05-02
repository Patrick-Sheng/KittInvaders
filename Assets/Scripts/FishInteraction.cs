using UnityEngine;

public class FishInteraction : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      collision.gameObject.GetComponent<PlayerController>().CollectFish();
      Debug.Log("Fish collected");
      Destroy(gameObject);
    }
  }
}
