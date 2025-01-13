using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1MusicManager : MonoBehaviour
{
    
    private MusicManager musicManager;
    
    // Start is called before the first frame update
    void Start()
    {
        musicManager = MusicManager.Instance;
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        musicManager.SetMusicVolume(musicVolume);
        musicManager.PlayMusic("Level1 Theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
