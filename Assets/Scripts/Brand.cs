using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brand : MonoBehaviour
{
    public bool tick;
    private string tagu;
    public GameObject energyR, energyB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tick)
            tagu = "red";
        else
            tagu = "blue";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("metal"))
        {
            other.gameObject.tag = tagu;

            if (tick)
            {
                GameObject redsmoke = Instantiate(energyR, other.transform.position, other.transform.rotation);
                redsmoke.transform.parent = other.transform;
            other.AddComponent<Destruct>();

        }
        else
            {
                GameObject bluesmoke = Instantiate(energyB, other.transform.position, other.transform.rotation);
                bluesmoke.transform.parent = other.transform;

        }
        Destroy(gameObject);

        }
            
    }
}
