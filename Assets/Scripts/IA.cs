using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destino;
    public Transform destino2;
    public Transform Target, spawnPoint1, spawnPoint2;
    private Transform destinoActual;
    public GameObject body, bullet, ammo, health, boom;
    public Animator anim;
    public bool chasing;
    private float distPlayer;
    public float shotForce = 50f;
    public int vidas;
    public Component[] partes;

    // Start is called before the first frame update
    void Start()
    {
        partes = gameObject.GetComponentsInChildren<Renderer>();
        destino.parent = null;
        destino2.parent = null;
        destinoActual = destino;
        agent.destination = destinoActual.transform.position;
        Target = GameObject.Find("Player").transform;
        chasing = false;
        anim = body.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        distPlayer = Vector3.Distance(transform.position, Target.transform.position);
        if (!chasing)
        {
            Patrol();
        }
        else
        if (chasing)
        {
            Chase();
        }
        
        if (distPlayer < 20)
        {
            chasing = true;
        }
        if (distPlayer > 50)
        {
            chasing = false;
        }

    }
    public void Chase()
    {
        agent.destination = Target.transform.position;
        transform.LookAt(Target);
        if (distPlayer < 10)
        {
            anim.Play("shoot");
        }
        else
            anim.Play("breathing");

    }

    public void Patrol()
    {
        anim.Play("breathing");

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

    public void Hurt()
    {
        vidas--;
        if (vidas <= 0)
        {
            vidas = 0;
            Death();
        }
        foreach (Renderer part in partes)
        {
            part.material.color = Color.blue;
        }
        Invoke("Normal", 0.4f);
    }
    public void Death()
    {
        bool nuuh = false;
        if (nuuh == false)
        {
            Instantiate(health, spawnPoint1.position, spawnPoint1.rotation);
            Instantiate(ammo, spawnPoint2.position, spawnPoint2.rotation);
            Instantiate(boom, gameObject.transform.position, gameObject.transform.rotation);
            nuuh = true;
        }
        

        Destroy(gameObject, 0.1f);
    }

    public void shoot()
    {
        GameObject newBullet1 = Instantiate(bullet, spawnPoint1.position, spawnPoint1.rotation);
        newBullet1.GetComponent<Rigidbody>().AddForce(spawnPoint1.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
        Destroy(newBullet1, 3f);

        GameObject newBullet2 = Instantiate(bullet, spawnPoint2.position, spawnPoint2.rotation);
        newBullet2.GetComponent<Rigidbody>().AddForce(spawnPoint2.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
        Destroy(newBullet2, 3f);

    }

    public void Normal()
    {
        foreach (Renderer part in partes)
        {
            part.material.color = Color.white;
        }
    }

   
}
