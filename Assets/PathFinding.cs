using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent nav;
    private int destpoint;
    public GameObject playerTank;
    // Start is called before the first frame update
    void Awake()
    {
        playerTank= GameObject.FindGameObjectWithTag("Player");
        points[0] = playerTank.transform;
    }
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        //playerTank = GameObject.FindWithTag("Tank");
        //points[0] = playerTank.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //points[0] = playerTank.transform;
        if (playerTank != null)
        {
            transform.LookAt(nav.destination);

            if (!nav.pathPending && nav.remainingDistance < 12.5f)
            {
                GoToNextPoint();
            }

        }
        else
        {
            points = null;
        }

    }
    //private void FixedUpdate()
    //{
    //    if (!nav.pathPending && nav.remainingDistance < 0.5f)
    //    {
    //        GoToNextPoint();
    //    }
    //}
    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        nav.destination = points[destpoint].position;
        destpoint = (destpoint + 1) % points.Length;

    }
}
