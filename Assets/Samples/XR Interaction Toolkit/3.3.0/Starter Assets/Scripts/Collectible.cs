using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound;
    public float collectDistance = 0.5f;

    private bool collected = false;
    private Transform player;

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        if (collected || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= collectDistance)
        {
            Collect();
        }
    }

    void Collect()
    {
        collected = true;

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        Destroy(gameObject);
    }
}