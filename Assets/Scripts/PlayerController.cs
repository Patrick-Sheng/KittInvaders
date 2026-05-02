using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    [Header("Cleanse")]
    [SerializeField] private int maxFish = 3;
    [SerializeField] private float cleanseRadius = 3f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject cleanseEffectPrefab;
    private int fishCount = 0;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI fishText;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateFishUI();
    }

    public void PressCleanse()
    {
        if (fishCount > 0)
        {
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
        if (fishCount < maxFish)
        {
          fishCount++;
          UpdateFishUI();
        }
    }

    private void ActivateCleanse()
    {
        fishCount--;
        UpdateFishUI();

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

    private void UpdateFishUI()
    {
        if (fishText != null)
            fishText.text = $"{fishCount}/{maxFish}";
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, cleanseRadius);
    }
}