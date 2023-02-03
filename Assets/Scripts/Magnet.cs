using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject blue, red;
    public bool thing;
    // Start is called before the first frame update
    void Start()
    {
        thing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            thing = true;
        }
            if (thing)
        {
            blue.transform.Translate(red.transform.position);
        }
    }
}
