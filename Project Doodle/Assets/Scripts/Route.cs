using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    float allowedDistanceAway = 0.1f;
    public float waitTime = 2.5f;
    float cooldownTimer = 0;
    public Transform[] waypoints;
    public float moveSpeed;
    int currentWaypoint = 0;

    Unit unit;
    SpriteAnimation sa;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        sa = GetComponentInChildren<SpriteAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            sa.SetIdle();
            return;
        }

        sa.SetMoving();
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) > allowedDistanceAway)
        {
            UpdateRealFacing();

            transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoints[currentWaypoint].transform.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) <= allowedDistanceAway)
            {
                // Set cooldown and go to next waypoint
                cooldownTimer = waitTime;
                currentWaypoint += 1;
                ValidateWaypointIndex();
            }
        }

    }

    void UpdateRealFacing()
    {
        var heading = waypoints[currentWaypoint].position - gameObject.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.

        int x = Mathf.RoundToInt(direction.x);
        int z = Mathf.RoundToInt(direction.z);
        if (x == 1)
        {
            unit.facing = Direction.EAST;
        }
        if (x == -1)
        {
            unit.facing = Direction.WEST;
        }
        if (z == 1)
        {
            unit.facing = Direction.NORTH;
        }
        if (z == -1)
        {
            unit.facing = Direction.SOUTH;
        }

    }

    void ValidateWaypointIndex()
    {
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
    }


}
