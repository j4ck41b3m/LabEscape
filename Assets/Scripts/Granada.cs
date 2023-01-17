using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public float delay = 3f;
    float countDown;
    public float radius = 5f;
    public float fuerzaExplosion = 70f;
    bool exploded = false;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0 && !exploded)
        {
            exploded = true;
            GameObject boom = Instantiate(explosion, transform.position, transform.rotation);

            Exploded(); 

        }
    }

    private void Exploded()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach ( var rangeObjec in colliders)
        {
            Rigidbody rb = rangeObjec.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fuerzaExplosion * 10, transform.position, radius);
            }
            Destroy(gameObject);
        }
    }
}
