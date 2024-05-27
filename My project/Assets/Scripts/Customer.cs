using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] customerPath;
    public int currentPos;
    public NavMeshAgent agent;
    void Start()
    {
        currentPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= .01) 
        {
            currentPos += 1;
            agent.SetDestination(customerPath[currentPos].position);
        }
    }

    void WalkPath() 
    {
        agent.SetDestination(customerPath[currentPos + 1].position);
        /*if (customerPath[currentPos].gameObject.name == "FrontOfTheLine") 
        {
            if(agent.speed <= 5 && numberOfCustomersAlreadyServed < 50)
            agent.speed = 1 * (.1 * numberOfCustomersAlreadyServed)
        }
        */
    }
}