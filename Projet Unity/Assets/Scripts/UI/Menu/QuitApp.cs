using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitApp : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit(); // Quitte le jeu dans un build
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}

