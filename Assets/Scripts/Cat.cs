using UnityEngine;

public class Cat : MonoBehaviour
{
    public enum CatState { Evil, Friendly }

    [Header("State")]
    public CatState currentState = CatState.Evil;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 2f;

    [Header("Visuals")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite evilSprite;
    [SerializeField] Sprite friendlySprite;

    Transform player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>().transform;
        ApplyState();
    }

    void Update()
    {
        if (currentState == CatState.Evil)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        // Friendly cats just idle for now
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentState == CatState.Evil && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().ChangeHealth(-1);
        }
    }

    public void Cleanse()
    {
        currentState = CatState.Friendly;
        ApplyState();
        // TODO: trigger cleanse animation/sound here
    }

    private void ApplyState()
    {
        switch (currentState)
        {
            case CatState.Evil:
                spriteRenderer.sprite = evilSprite;
                gameObject.layer = LayerMask.NameToLayer("Enemy");
                break;
            case CatState.Friendly:
                spriteRenderer.sprite = friendlySprite;
                gameObject.layer = LayerMask.NameToLayer("Friendly");
                break;
        }
    }
}