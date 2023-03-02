using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("metal"))
        {
            collision.gameObject.GetComponent<IA>().Hurt();
            Destroy(gameObject, 0.1f);

        }
    }
}
