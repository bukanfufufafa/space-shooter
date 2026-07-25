using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] private List<Transform> backgrounds = new();

    [Header("Setting")]
    [SerializeField] private float scrollSpeed = 2f;

    private Camera cam;
    private float backgroundHeight;

    private void Start()
    {
        cam = Camera.main;

        if (backgrounds.Count == 0)
            return;

        SpriteRenderer sr = backgrounds[0].GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("Background tidak memiliki SpriteRenderer.");
            enabled = false;
            return;
        }

        backgroundHeight = sr.bounds.size.y;
    }

    private void Update()
    {
        if (backgrounds.Count == 0)
            return;

        float bottomScreen = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        // Gerakkan semua background ke bawah
        foreach (Transform bg in backgrounds)
        {
            bg.Translate(Vector3.down * scrollSpeed * Time.deltaTime, Space.World);
        }

        // Cari background paling atas
        Transform highest = backgrounds[0];

        foreach (Transform bg in backgrounds)
        {
            if (bg.position.y > highest.position.y)
                highest = bg;
        }

        // Loop
        foreach (Transform bg in backgrounds)
        {
            SpriteRenderer sr = bg.GetComponent<SpriteRenderer>();

            // Jika seluruh sprite sudah keluar layar
            if (bg.position.y + sr.bounds.extents.y <= bottomScreen)
            {
                bg.position = new Vector3(
                    highest.position.x,
                    highest.position.y + backgroundHeight,
                    highest.position.z);

                highest = bg;
            }
        }
    }
}