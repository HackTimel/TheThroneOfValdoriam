using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Assassin : MonoBehaviour
{
    [Header("Dash")]
    public Rigidbody rb;
    public GameObject player;
    public GameObject particleSystemPrefab;
    public GameObject icone_dash;
    public float force = 25f;
    public float dashCooldown = 10f;
    private float dashTimer = 0f;
    private bool canDash = true;

    [Header("Invisibility")]
    public float invisibilityDuration = 5f;
    private bool isInvisible = false;

    void Start()
    {
        if (player == null || rb == null)
        {
            Debug.LogError("Player or Rigidbody reference is missing!");
        }

        if (icone_dash != null)
            icone_dash.SetActive(true);
    }

    void Update()
    {
        // Dash input
        if (Input.GetKeyDown(KeyCode.T) && canDash)
        {
            Dash();
        }

        // Dash cooldown timer
        if (!canDash)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashCooldown)
            {
                canDash = true;
                dashTimer = 0f;
                DashAvailable();
            }
        }

        // Invisibility input
        if (Input.GetKeyDown(KeyCode.Q) && !isInvisible)
        {
            StartCoroutine(BecomeInvisible());
        }
    }

    public void DashAvailable()
    {
        if (icone_dash != null)
            icone_dash.GetComponent<Image>().color = Color.white;
    }

    public void DashUnavailable()
    {
        if (icone_dash != null)
            icone_dash.GetComponent<Image>().color = Color.grey;
    }

    public void Dash()
    {
        Vector3 dashDirection = player.transform.forward.normalized;
        Vector3 startPos = player.transform.position;

        rb.velocity = Vector3.zero;
        rb.AddForce(dashDirection * force, ForceMode.VelocityChange);

        if (particleSystemPrefab != null)
        {
            GameObject clone = Instantiate(particleSystemPrefab, startPos, Quaternion.identity);
            clone.SetActive(true);
            clone.tag = "smoke";
        }

        canDash = false;
        DashUnavailable();
    }

    private IEnumerator BecomeInvisible()
    {
        isInvisible = true;
        gameObject.tag = "Invisible";
        SetVisible(false);  // Rend invisible

        yield return new WaitForSeconds(invisibilityDuration);

        gameObject.tag = "Player";
        SetVisible(true);   // Redevient visible
        isInvisible = false;
    }

    private void SetVisible(bool visible)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = visible;
        }
    }
}
