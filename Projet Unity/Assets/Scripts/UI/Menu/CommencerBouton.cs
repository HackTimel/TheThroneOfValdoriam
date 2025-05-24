using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommencerBouton : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/Romario/map 1"); //on lance une nouvelle game dans cette game
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
