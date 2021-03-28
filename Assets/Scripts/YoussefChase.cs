using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YoussefChase : MonoBehaviour
{
    public GameObject player;

    Vector3 distanceTo;

    NavMeshAgent navMeshAgent;

    public float speed;

    bool shouldFollow;

    float jumpscareDistance;

    private void Update()
    {
        distanceTo = this.transform.position - player.transform.position;
        this.transform.rotation = Quaternion.LookRotation(distanceTo);
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + 90, 0);

        if (shouldFollow)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) > 1.25)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }
            
            else
            {
                navMeshAgent.velocity = Vector3.zero;
                navMeshAgent.isStopped = true;
                print("YOU ARE DEAD");
            }
        }
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void StartMoving()
    {
        shouldFollow = true;
    }
}
