using UnityEngine;

public class FloatingRotate : MonoBehaviour
{
    public float floatAmplitude = 0.25f;
    public float floatSpeed = 2f;
    public float rotationSpeed = 180f;

    private Vector3 startPos;
    private float timeOffset;
    private float halfHeight;

    void Start()
    {
        startPos = transform.position;

var col = GetComponentInChildren<Collider>();
if (col != null)
    halfHeight = col.bounds.extents.y;
else
{
    var renderer = GetComponentInChildren<Renderer>();
    if (renderer != null)
        halfHeight = renderer.bounds.extents.y;
}

        timeOffset = -Mathf.PI / 2f / floatSpeed;
        timeOffset += Random.Range(0f, 100f);
    }

    void Update()
    {
        float wave = (Mathf.Sin((Time.time + timeOffset) * floatSpeed) + 1f) * 0.5f;
        float newY = startPos.y + halfHeight + wave * floatAmplitude;

        transform.position = new Vector3(startPos.x, newY, startPos.z);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}