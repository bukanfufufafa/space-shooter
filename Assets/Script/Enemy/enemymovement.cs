using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public enum MoveDirectionType
    {
        Left,
        Right,
        Up,
        Down
    }

    public enum WaveType
    {
        None,
        Sin,
        Cos,
        Tan
    }

    public enum WaveAxis
    {
        Horizontal,
        Vertical
    }

    [Header("Movement")]
    [SerializeField] private MoveDirectionType direction = MoveDirectionType.Left;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Loop Position")]
    [SerializeField] private float minPosition = -10f;
    [SerializeField] private float maxPosition = 10f;

    [Header("Wave")]
    [SerializeField] private WaveType waveType = WaveType.None;
    [SerializeField] private WaveAxis waveAxis = WaveAxis.Vertical;
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 3f;

    [Tooltip("Offset agar musuh tidak bergelombang bersamaan")]
    [SerializeField] private float phaseOffset = 0f;

    private Vector2 position;
    private float baseX;
    private float baseY;

    private void Start()
    {
        position = transform.position;
        baseX = position.x;
        baseY = position.y;
    }

    private void FixedUpdate()
    {
        // =========================
        // Movement
        // =========================

        switch (direction)
        {
            case MoveDirectionType.Left:

                position.x -= moveSpeed * Time.fixedDeltaTime;

                if (position.x < minPosition)
                    position.x = maxPosition;

                baseX = position.x;

                break;

            case MoveDirectionType.Right:

                position.x += moveSpeed * Time.fixedDeltaTime;

                if (position.x > maxPosition)
                    position.x = minPosition;

                baseX = position.x;

                break;

            case MoveDirectionType.Up:

                position.y += moveSpeed * Time.fixedDeltaTime;

                if (position.y > maxPosition)
                    position.y = minPosition;

                baseY = position.y;

                break;

            case MoveDirectionType.Down:

                position.y -= moveSpeed * Time.fixedDeltaTime;

                if (position.y < minPosition)
                    position.y = maxPosition;

                baseY = position.y;

                break;
        }

        // =========================
        // Wave
        // =========================

        float t;

        if (direction == MoveDirectionType.Left || direction == MoveDirectionType.Right)
            t = baseX * frequency + phaseOffset;
        else
            t = baseY * frequency + phaseOffset;

        float wave = 0f;

        switch (waveType)
        {
            case WaveType.Sin:
                wave = Mathf.Sin(t);
                break;

            case WaveType.Cos:
                wave = Mathf.Cos(t);
                break;

            case WaveType.Tan:
                wave = Mathf.Clamp(Mathf.Tan(t), -1f, 1f);
                break;
        }

        Vector2 finalPos = position;

        if (waveType != WaveType.None)
        {
            if (waveAxis == WaveAxis.Horizontal)
                finalPos.x = baseX + wave * amplitude;
            else
                finalPos.y = baseY + wave * amplitude;
        }

        transform.position = finalPos;
    }
}