using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int startingPoint = 0;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;
    [SerializeField] private bool startActive = true;

    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        transform.position = waypoints[startingPoint].position;
        currentWaypointIndex = startingPoint;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= checkDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.fixedDeltaTime);
    }
}
