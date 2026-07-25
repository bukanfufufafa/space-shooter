using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    [Header("Circle")]
    [SerializeField] private float radius = 2f;
    [SerializeField] private float speed = 2f;

    [Header("Rotation")]
    [SerializeField] private bool clockwise = true;

    [Header("Phase")]
    [Tooltip("Offset sudut (dalam derajat) agar musuh tidak berada di posisi yang sama.")]
    [SerializeField] private float phaseOffset = 0f;

    private Vector2 center;
    private float angle;

    private void Start()
    {
        center = transform.position;

        // Konversi derajat ke radian
        angle = phaseOffset * Mathf.Deg2Rad;
    }

    private void Update()
    {
        if (clockwise)
            angle -= speed * Time.deltaTime;
        else
            angle += speed * Time.deltaTime;

        float x = center.x + Mathf.Cos(angle) * radius;
        float y = center.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector2(x, y);
    }
}