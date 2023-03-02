using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destino;
    public Transform destino2;
    public Transform Target;
    private Transform destinoActual;
    public bool chasing;
    // Start is called before the first frame update
    void Start()
    {
        destino.parent = null;
        destino2.parent = null;
        destinoActual = destino;
        agent.destination = destinoActual.transform.position;
        Target = GameObject.Find("Player").transform;
        chasing = false;

    }

    // Update is called once per frame
    void Update()
    {
        float distPlayer = Vector3.Distance(transform.position, Target.transform.position);
        if (!chasing)
        {
            Patrol();
        }
        else
        if (chasing)
        {
            Chase();
        }
        
        if (distPlayer < 8)
        {
            chasing = true;
        }
        if (distPlayer > 20)
        {
            chasing = false;
        }

    }
    public void Chase()
    {
        agent.destination = Target.transform.position;
        transform.LookAt(Target);

    }

    public void Patrol()
    {
        float distPunto = Vector3.Distance(transform.position, destino.transform.position);
        if (distPunto < 3)
        {
            destinoActual = destino2;
            //Debug.Log(1);
        }

        distPunto = Vector3.Distance(transform.position, destino2.transform.position);
        if (distPunto < 3)
        {
            destinoActual = destino;
            // Debug.Log(2);
        }

        agent.destination = destinoActual.transform.position;
    }
    public void Death()
    {
        Destroy(gameObject, 0.5f);
    }
}
