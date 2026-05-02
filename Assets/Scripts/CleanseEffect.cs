using UnityEngine;

public class CleanseEffect : MonoBehaviour
{
    [SerializeField] float duration = 0.6f;
    float targetRadius = 3f;

    float elapsed = 0f;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0f, 1f, 1f, 0.4f);
        transform.localScale = Vector3.zero;
    }

    public void SetRadius(float radius)
    {
        targetRadius = radius;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        float t = elapsed / duration;

        // Currently targetRadius * 2f — increase if visual is too small
        float scale = Mathf.Lerp(0f, targetRadius * 10f, t);
        transform.localScale = new Vector3(scale, scale, 1f);

        Color c = sr.color;
        c.a = Mathf.Lerp(0.4f, 0f, t);
        sr.color = c;

        if (elapsed >= duration)
            Destroy(gameObject);
    }
}