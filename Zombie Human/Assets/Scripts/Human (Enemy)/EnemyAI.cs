using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 1f;
    public float nextWayPointDistance = 3f;

    Path path;
    int currentWayPoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //chairs = FindObjectsOfType<EmptyChair>();

        //StartCoroutine(lookPlayer());

        target = GameObject.Find("Player").transform;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void OnPathComplete(Path p)
    {
        if (!reachedEndOfPath || !p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void FixedUpdate()
    {
        if (reachedEndOfPath || path == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        //rb.position = Vector2.MoveTowards(rb.position, (Vector2)path.vectorPath[currentWayPoint], speed * Time.deltaTime);

        rb.MovePosition(Vector2.MoveTowards(rb.position, (Vector2)path.vectorPath[currentWayPoint], speed * Time.deltaTime));

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }

/*    IEnumerator lookPlayer()
    {
        while (true)
        {
            for (int i = 0; i < chairs.Length; i++)
            {
                if (!chairs[i].isOccupied)
                {
                    target = chairs[i].transform;
                    tempChair = chairs[i];
                    tempChair.isOccupied = true;
                    yield break;
                }
            }
            yield return new WaitForSeconds(5);
        }
    }
*/}