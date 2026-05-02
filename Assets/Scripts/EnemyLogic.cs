using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
  [SerializeField] float moveSpeed;
  Transform target;

  void Start()
  {
    target = FindFirstObjectByType<PlayerMovement>().gameObject.transform;
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      collision.gameObject.GetComponent<PlayerController>().ChangeHealth(-1);
      Debug.Log("Player took damage");
    }
  }
}
