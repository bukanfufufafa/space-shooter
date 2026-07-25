using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Waypoint")]
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float reachDistance = 0.1f;

    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (waypoints.Count == 0)
            return;

        Transform target = waypoints[currentWaypointIndex];

        // Bergerak menuju waypoint
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime);

        // Jika sudah sampai
        if (Vector2.Distance(transform.position, target.position) <= reachDistance)
        {
            currentWaypointIndex++;

            // Loop kembali ke waypoint pertama
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    // Mengganti waypoint melalui script jika diperlukan
    public void SetWaypoints(List<Transform> newWaypoints)
    {
        waypoints = newWaypoints;
        currentWaypointIndex = 0;
    }
}