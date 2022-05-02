using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMan : MonoBehaviour
{
    public Transform playerTransform;

    public float maxTime = 1f;
    public float maxDistance = 1f;

    NavMeshAgent agent;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            float sqdistance = (playerTransform . position - agent.destination).sqrMagnitude;
            if(sqdistance > maxDistance * maxDistance)
            {
                agent.destination = playerTransform.position;
            }
            timer = maxTime;
        }
    }
}
