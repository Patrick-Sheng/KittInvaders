using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    [Header("Cleanse")]
    [SerializeField] private int fishRequired = 5;
    [SerializeField] private float cleanseRadius = 3f;
    [SerializeField] private LayerMask enemyLayer;
    private int fishCount = 0;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fishCount >= fishRequired)
        {
            Debug.Log("Activating Cleanse!");
            ActivateCleanse();
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            // TODO: trigger game over
        }
    }

    public void CollectFish()
    {
        fishCount++;
        Debug.Log($"Fish: {fishCount}/{fishRequired}");
    }

    private void ActivateCleanse()
    {
        fishCount -= fishRequired;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, cleanseRadius, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            hit.GetComponent<Cat>()?.Cleanse();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, cleanseRadius);
    }
}