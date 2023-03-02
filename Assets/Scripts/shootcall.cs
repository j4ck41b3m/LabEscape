using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootcall : MonoBehaviour
{
    private Transform Bot;
    // Start is called before the first frame update
    void Start()
    {
        Bot = transform.root.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallShot()
    {
        Bot.GetComponent<IA>().shoot();
    }
}
