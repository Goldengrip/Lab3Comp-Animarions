using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MeshController : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;

    bool isWalking=true;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(isWalking)
            agent.destination = Target.transform.position;
        else
        {
           agent.destination = transform.position; 
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("Attack");
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("Walking");
        }
    }

}
