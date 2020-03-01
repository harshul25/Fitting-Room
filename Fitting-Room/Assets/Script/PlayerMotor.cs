﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame

    public void MoveToPoint(Vector3 Point){
        agent.SetDestination(Point);
    }


    void Update()
    {
       if(target != null){
           agent.SetDestination(target.position);
           FaceTarget();
       } 
    }

    public void FollowTarget(Interactables newTarget){
        agent.stoppingDistance = newTarget.radius * 0.8f;
        target = newTarget.interactiontransform;
        agent.updateRotation  = false;
    }

    public void StopFollowTarget(){
        target = null;
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
    }

    public void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRoation = Quaternion.LookRotation(new Vector3(direction.x,0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRoation, Time.deltaTime * 5f); 
    }
}
