using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public FirstPersonController player;
    float speed = 10f;
    float damage = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer() 
    {
        agent.SetDestination(player.transform.position);
    }
}
