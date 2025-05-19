using UnityEngine;

public class FireballTargeting : MonoBehaviour
{
    public Camera playerCamera;         // À assigner dans l’inspecteur
    public GameObject fireballPrefab;
    public LayerMask terrainLayer;

    private bool isTargeting = false;

    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            EnterTargetingMode();
        }

        if (isTargeting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);  // ← ici
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f, terrainLayer))
                {
                    Debug.Log("Hit at: " + hit.point);
                    Instantiate(fireballPrefab, hit.point + Vector3.up * 0.5f, Quaternion.identity);
                    ExitTargetingMode();
                }
                else
                {
                    Debug.Log("Raycast missed");
                }
            }

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
        LockCursor();
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
