using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audyo : MonoBehaviour
{
    private AudioSource audi;
    public AudioClip kaboom;
    // Start is called before the first frame update
    void Awake()
    {
        audi = GetComponent<AudioSource>();
        audi.PlayOneShot(kaboom);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
