using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class QuitGame : MonoBehaviour
{
    public void ExitApplication()
    {
        UnityEngine.Application.Quit();

        //Debug.Log("Application Quit!"); // Optional: for debugging in the editor
    }
}