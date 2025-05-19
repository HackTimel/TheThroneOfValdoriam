using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float delayBeforeFire = 1f;

    private bool isFiring = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isFiring)
        {
            StartCoroutine(FireAfterDelay());
        }
    }

    private System.Collections.IEnumerator FireAfterDelay()
    {
        isFiring = true;
        yield return new WaitForSeconds(delayBeforeFire);
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        isFiring = false;
    }
}
