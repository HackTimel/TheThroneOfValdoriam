using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public struct MusicTrack //correspond a la musique, son nom et son audio de type AudioClip
{
    public string trackName;
    public AudioClip clip;
}
 
public class MusicLibrary : MonoBehaviour
{
    public MusicTrack[] tracks;
 
    public AudioClip GetClipFromName(string trackName)
    {
        foreach (var track in tracks)
        {
            if (track.trackName == trackName)
            {
                return track.clip;
            }
        }
        return null;
    }
}
