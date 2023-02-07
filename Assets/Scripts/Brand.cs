using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brand : MonoBehaviour
{
    public bool tick;
    private string tag;
    public GameObject energyR, energyB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tick)
            tag = "red";
        else
            tag = "blue";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("metal"))
        {
            other.gameObject.tag = tag;


            if (tick)
            {
                GameObject redsmoke = Instantiate(energyR, other.transform.position, other.transform.rotation);
                redsmoke.transform.parent = other.transform;

            }
            else
            {
                GameObject bluesmoke = Instantiate(energyB, other.transform.position, other.transform.rotation);
                bluesmoke.transform.parent = other.transform;
            }
        }
            
    }
}
