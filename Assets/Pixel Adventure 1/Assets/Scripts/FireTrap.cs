using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public int damage = 1;
    public float activeTime = 2f;
    public float inactiveTime = 2f;
    public bool useCycle = true;

    private Collider2D col;
    private SpriteRenderer sr;
    private ParticleSystem ps;
    private AudioSource audioSource;

    void Start()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();

        if (useCycle)
            StartCoroutine(Cycle());
    }

    System.Collections.IEnumerator Cycle()
    {
        while (true)
        {
            SetTrapActive(true);
            yield return new WaitForSeconds(activeTime);

            SetTrapActive(false);
            yield return new WaitForSeconds(inactiveTime);
        }
    }

    void SetTrapActive(bool isActive)
    {
        col.enabled = isActive;
        sr.enabled = isActive;

        if (ps != null)
        {
            var emission = ps.emission;
            emission.enabled = isActive;
        }

        if (audioSource != null)
        {
            if (isActive) audioSource.Play();
            else audioSource.Pause();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Tenta achar o script de vida do player
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
                health.TakeDamage(damage);
        }
    }
}
