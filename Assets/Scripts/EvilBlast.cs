using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBlast : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
  
    private void OnTriggerEnter(Collider other)
    {
       
            if (other.CompareTag("Player"))
            {
                GameManager.instance.LoseHealth(1);
                Destroy(gameObject);
            }
       


    }
}
