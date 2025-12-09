
using UnityEngine;
using UnityEngine.SceneManagement;
public class balloon_pop : MonoBehaviour
{
    //
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    public float upSpeed;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 6f)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
    private void FixedUpdate()
    {
        transform.Translate(0, upSpeed, 0);
    }
    private void OnMouseDown()
    {
        ResetPosition();
        audioSource.Play();
        
    }
    private void ResetPosition()
    {
        float randomX = Random.Range(-1.86f, 1.96f);
        transform.position = new Vector2(randomX, -7f);
    }
}
