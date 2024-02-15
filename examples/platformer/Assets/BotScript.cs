using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotScript : MonoBehaviour
{
    public GameObject target;
    float speed = 10;

    NavMeshAgent nma;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();

        target = GameObject.Find("Player");

        animator = gameObject.GetComponentInChildren<Animator>();
        animator.Play("hover", 0, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        //// 1. Compute vector to target
        //Vector3 vecToTarget = target.transform.position - transform.position;

        //// 2. Normalize
        //vecToTarget.Normalize();

        //// 3. Scale by speed
        //vecToTarget *= speed;

        //// 4. Scale by Time.deltaTime
        //vecToTarget *= Time.deltaTime;

        //// 5. Move!
        //transform.position += vecToTarget;

        // One line version
        //transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;

        Vector3 vecToTarget = target.transform.position - transform.position;
        if (vecToTarget.magnitude < 5)
        {
            nma.SetDestination(target.transform.position);
            animator.SetTrigger("attack");
        }
    }
}
