using System.Collections;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LaserBeamController : MonoBehaviour
{
    private LineRenderer lr;
    private float length;
    private Coroutine beamRoutine;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        gameObject.SetActive(false);
    }
    public void StartBeam(float beamLength, float duration)
    {
        length = beamLength;

        if (beamRoutine != null) StopCoroutine(beamRoutine);
        gameObject.SetActive(true);
        beamRoutine = StartCoroutine(BeamRoutine(duration));
    }

    private IEnumerator BeamRoutine(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            UpdateLinePosition();
            elapsed += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
        beamRoutine = null;
    }

    private void UpdateLinePosition()
    {
        Vector3 start = transform.position;
        Vector3 end = start + transform.up * length;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}