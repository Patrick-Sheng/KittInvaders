using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI fishText;
    [SerializeField] private Image[] heartImages; // drag Heart1, Heart2, Heart3 in here
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    public GameOverScreen GameOverScreen;

    private void GameOver()
    {
        GameOverScreen.Setup(ScoreManager.Instance.GetScore());
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateFishUI();
        UpdateHealthUI();
    }

    public void PressCleanse()
    {
        if (fishCount > 0)
        {
            Debug.Log("Activating Cleanse!");
            ActivateCleanse();
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // prevent going below 0 or above max
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            // TODO: trigger game over
            Time.timeScale = 0f;
            GameOver();
        }
    }

    public void CollectFish()
    {
        if (fishCount < fishRequired)
        {
            fishCount++;
            UpdateFishUI();
            Debug.Log($"Fish: {fishCount}/{fishRequired}");
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
            fishText.text = "Fish: " + fishCount + "/" + fishRequired;
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].sprite = i < currentHealth ? fullHeart : emptyHeart;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, cleanseRadius);
    }
}