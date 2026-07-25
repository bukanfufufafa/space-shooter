using System.Collections;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class LaserBeamController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Coroutine beamRoutine;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    public void StartBeam(float beamLength, float duration)
    {
        float spriteHeight = sr.sprite.bounds.size.y;
        float scaleY = beamLength / spriteHeight;

        transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);

        if (beamRoutine != null) StopCoroutine(beamRoutine);
        gameObject.SetActive(true);
        beamRoutine = StartCoroutine(AutoStop(duration));
    }

    private IEnumerator AutoStop(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        gameObject.SetActive(false);
        beamRoutine = null;
    }
}