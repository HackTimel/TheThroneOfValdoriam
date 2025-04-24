using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [SerializeField]public AudioSource footstepSource; // Drag & Drop un AudioSource dans l'Inspector

    void OnFootstep()
    {
        if (footstepSource != null)
        {
            footstepSource.Play(); // Joue un son de pas
        }
        else
        {
            Debug.LogWarning("Aucun AudioSource assigné pour les bruits de pas !");
        }
    }
}