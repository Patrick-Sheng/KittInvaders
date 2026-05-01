using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

  private int currentHealth;
  [SerializeField] private int maxHealth = 3;

  void Start()
  {
    currentHealth = maxHealth;
  }

  // Update is called once per frame
  void Update()
  {
    if (currentHealth <= 0)
    {
      Debug.Log("Game Over");
    }
  }

  public void ChangeHealth(int changeBy)
  {
    currentHealth += changeBy;
  }
}
