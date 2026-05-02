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
    [SerializeField] private GameObject cleanseEffectPrefab;
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
        currentHealth += amount;
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

        if (cleanseEffectPrefab != null)
        {
            GameObject effect = Instantiate(cleanseEffectPrefab, transform.position, Quaternion.identity);
            effect.GetComponent<CleanseEffect>().SetRadius(cleanseRadius);
        }

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