

using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;
using UnityEngine.SceneManagement;

/// <summary>
/// Updated balloon script that works with both Touch and NatML gesture control
/// </summary>
public class SimpleBalloon : MonoBehaviour
{
    [Header("Balloon Settings")]
    public float floatSpeed = 100f;
    public int pointValue = 10;

    [Header("Visual Settings")]
    public Color balloonColor = Color.blue;
    public float popAnimationDuration = 0.3f;

    private Image balloonImage;
    private bool isPopped = false;
    private bool isPopping = false;

    void Awake()
    {
        balloonImage = GetComponent<Image>();
        if (balloonImage == null)
        {
            balloonImage = gameObject.AddComponent<Image>();
        }

        // Set random color if not specified
        if (balloonColor == Color.blue)
        {
            Color[] colors = { Color.red, Color.blue, Color.green,
                             Color.yellow, Color.magenta, Color.cyan };
            balloonColor = colors[Random.Range(0, colors.Length)];
        }

        balloonImage.color = balloonColor;
    }

    void Update()
    {
        if (isPopped || isPopping) return;

        // Float upward
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // Add slight side-to-side wobble
        float wobble = Mathf.Sin(Time.time * 2f) * 20f;
        transform.position += Vector3.right * wobble * Time.deltaTime;

        // Destroy if off screen
        if (transform.position.y > Screen.height + 200)
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Called when balloon should pop (from touch or gesture)
    /// </summary>
    public void Pop()
    {
        if (isPopped || isPopping) return;

        isPopping = true;
        StartCoroutine(PopAnimation());

        // Notify game manager for score
        NotifyGameManager();
    }

    /// <summary>
    /// Pop animation with scale and fade
    /// </summary>
    System.Collections.IEnumerator PopAnimation()
    {
        Vector3 originalScale = transform.localScale;
        Color originalColor = balloonImage.color;

        float elapsed = 0f;

        while (elapsed < popAnimationDuration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / popAnimationDuration;

            // Scale up
            float scale = Mathf.Lerp(1f, 2.5f, progress);
            transform.localScale = originalScale * scale;

            // Fade out
            Color color = originalColor;
            color.a = Mathf.Lerp(1f, 0f, progress);
            balloonImage.color = color;

            yield return null;
        }

        isPopped = true;
        Destroy(gameObject);
    }

    /// <summary>
    /// Notify game manager about pop for scoring
    /// </summary>
    void NotifyGameManager()
    {
        // Find game manager and update score
      
    }

    /// <summary>
    /// Check if balloon is already popped (prevent double-pop)
    /// </summary>
    public bool IsPopped()
    {
        return isPopped || isPopping;
    }

    /// <summary>
    /// For touch mode - called by Button component
    /// </summary>
    public void OnClick()
    {
        Pop();
    }
}