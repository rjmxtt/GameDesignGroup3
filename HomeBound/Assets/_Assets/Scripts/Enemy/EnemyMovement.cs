using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Boolean waitToMove;
    private Animator anim;
    private GameObject player;
    private Transform playerTransform;
    private NavMeshAgent nav;

    private bool attacking;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        nav = GetComponent<NavMeshAgent>();
        attacking = false;

        if (waitToMove == true)
        {
            StartCoroutine(Wait());
        }
    }

    private void Update()
    {

        if (waitToMove == false && attacking == false && GetComponent<NavMeshAgent>().enabled == true) {
            nav.SetDestination(playerTransform.position);
            //Debug.Log("moving");
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            //print("enter");       
            attacking = true;
            //print("attacking = true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            //print("exit");       
            attacking = false;
        }
    }


    IEnumerator Wait()
    {
        //Debug.Log("waiting");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).
            length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime - 0.25f);
        waitToMove = false;
        //Debug.Log("waitToMove = false");
    }
}
