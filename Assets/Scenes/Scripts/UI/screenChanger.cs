using UnityEngine;
using UnityEngine.SceneManagement;

public class screenChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void screenchange (string name)
    {
        SceneManager.LoadScene(name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
