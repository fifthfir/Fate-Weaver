using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowThePath : MonoBehaviour
{
    public KeyCode hitKey;
    public GameObject hitPrefab;
    public TextMeshProUGUI resultText;
    public bool reverserPath = false;
    public float hitThreshold = 0.1f; // Threshold distance to consider a hit
    public GameObject path;
    public bool endQTEAfterCompletion = false; // this should be set to true if the rune has a unsegmented path/if this is the last segment
    public bool pauseOrbAfterHit = false; // set to true if no lines should be drawn after player hit
    public float travelTime = 6f; // for sychronizing with music
    public float initialDelay; // the order of which the line will be drawn for a segmented rune

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float move_speed;

    // Index of current waypoint from which the orb moves to the next one
    // to the next one
    private int waypoint_index = 0;

    private bool ready_to_hit = false;

    private bool can_move = true;

    private bool hit_pressed = false;

    [SerializeField]
    private Transform curr_hit_zone_transform;

    Subscription<HitZoneExitEvent> exit_hit_zone_event_subscription;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(InitialDelay());

    }

    // Update is called once per frame
    private void Update()
    {
        if (can_move) { Move(); }

        if (can_move && ready_to_hit)
        {
            hit_pressed = false;
            // If hit button is pressed
            if (Input.GetKeyDown(hitKey))
            {
                hit_pressed = true;
               GameObject hitMark =  Instantiate(hitPrefab, GetComponentInParent<Transform>().position, Quaternion.identity);
                hitMark.transform.parent = this.gameObject.transform.parent;
                ready_to_hit = false;

                /* extra logic for handling pausing orb after hit for segmented runes*/
                if (pauseOrbAfterHit)
                {
                    can_move = false;
                }
                /* end */

                CheckHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HitPoint>() != null)
        {
            ready_to_hit = true;
            curr_hit_zone_transform = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HitPoint>() != null)  
        {
            ready_to_hit = false;
            //Publish Exit Event for calling checkhit
            EventBus.Publish(new HitZoneExitEvent(curr_hit_zone_transform));
        }
    }



    private void Move()
    {
        // If orb didn't reach last waypoint it can move
        // If orb reached last waypoint then it stops
        if (!reverserPath) { 
            if (waypoint_index < waypoints.Length)
            {
                can_move = true;
                // Move orb from current waypoint to the next one
                // using MoveTowards method
                transform.position = Vector3.MoveTowards(transform.position,
                   waypoints[waypoint_index].transform.position,
                   move_speed * Time.deltaTime);
                // If orb reaches position of waypoint he walked towards
                // then waypointIndex is increased by 1
                // and  starts to walk to the next waypoint
                if (transform.position == waypoints[waypoint_index].transform.position)
                {
                    waypoint_index += 1;
                }
            }
            else
            {
                can_move = false;
                // end qte and calculate final results if this is the only or the last line segment
                if (endQTEAfterCompletion)
                {
                    EventBus.Publish(new QteEndEvent());
                    Debug.Log("QTE end not reverse");
                }
            }
        }

        else
        {
            if(waypoint_index > 0)
            {
                can_move = true;
                // end qte and calculate final results if this is the only or the last line segment
                transform.position = Vector3.MoveTowards(transform.position,
                    waypoints[waypoint_index].transform.position,
                    move_speed * Time.deltaTime);
            }
            else
            {
                can_move = false;
                if (endQTEAfterCompletion)
                {
                    EventBus.Publish(new QteEndEvent());
                }
            }

            if(transform.position == waypoints[waypoint_index].transform.position)
            {
                waypoint_index -= 1;
            }
        }
    }
  
    void CheckHit()
    {
        Transform targetWaypoint = curr_hit_zone_transform;
        float distance = Vector2.Distance(transform.position, targetWaypoint.position);
        string curr_result = "";

        if (distance <= hitThreshold)
        {
            Debug.Log("Perfect!");
            curr_result = "Perfect!";
        }
        else if (distance <= hitThreshold * 3f)
        {
            Debug.Log("Excellent!");
            curr_result = "Excellent!";
        }
        else if (distance <= hitThreshold * 5f)
        {
            Debug.Log("Fair!");
            curr_result = "Fair!";
        }
        else
        {
            Debug.Log("Fail!");
            curr_result = "Fail!";
        }

        EventBus.Publish(new HitZoneResultEvent(curr_result,(1-distance)));
    }

    void OnHitZoneExit(HitZoneExitEvent e)
    {
        string curr_result = "";
        if (curr_hit_zone_transform == e.hitZoneTransform)
        {
            if (!hit_pressed)
            {
                Debug.Log("Missed!");
                curr_result = "Miss!";
                EventBus.Publish(new HitZoneResultEvent(curr_result, 0));
            }
        }
    }

    private IEnumerator InitialDelay()
    {
        can_move = false;
        yield return new WaitForSeconds(initialDelay);

        /* Get Waypoints */
        //waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        Transform[] allTransforms = path.GetComponentsInChildren<Transform>(true);

        // Filter out the parent transform
        Transform parentTransform = path.transform;
        Transform[] childTransforms = System.Array.FindAll(allTransforms, t => t != parentTransform);
        waypoints = childTransforms;

        /*End*/

        exit_hit_zone_event_subscription = EventBus.Subscribe<HitZoneExitEvent>(OnHitZoneExit);

        // Calculate the total distance from the first waypoint to the last waypoint
        float totalDistance = 0f;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            totalDistance += Vector3.Distance(waypoints[i].transform.position, waypoints[i + 1].transform.position);
        }

        // Calculate the move speed based on the total distance and the total travel time
        move_speed = totalDistance / travelTime;

        // Initialize orb position
        if (!reverserPath)
        {
            transform.position = waypoints[waypoint_index].transform.position;
        }
        else
        {
            transform.position = waypoints[waypoints.Length - 1].transform.position;
            waypoint_index = waypoints.Length - 1;
        }

        // Start moving
        can_move = true;
    }
}
