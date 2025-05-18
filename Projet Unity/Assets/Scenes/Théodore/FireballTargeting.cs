using UnityEngine;

public class FireballTargeting : MonoBehaviour
{
    public GameObject fireballPrefab; // À assigner dans l'inspecteur
    public LayerMask terrainLayer;    // Le layer de ton terrain (ex. "Terrain")
    private bool isTargeting = false;

    void Start()
    {
        // Verrouille la souris au début
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Active le mode ciblage avec T
        if (Input.GetKeyDown(KeyCode.T))
        {
            EnterTargetingMode();
        }

        if (isTargeting)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f, terrainLayer))
                {
                    Debug.Log("Terrain cliqué à : " + hit.point);

                    Vector3 spawnPos = hit.point + Vector3.up * 0.5f;
                    Instantiate(fireballPrefab, spawnPos, Quaternion.identity);

                    ExitTargetingMode();
                }
            }

            // Permet d’annuler avec clic droit (optionnel)
            if (Input.GetMouseButtonDown(1))
            {
                ExitTargetingMode();
            }
        }
    }

    void EnterTargetingMode()
    {
        isTargeting = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ExitTargetingMode()
    {
        isTargeting = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
