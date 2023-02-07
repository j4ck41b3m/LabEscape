using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject blue, red;
    public bool thing;

    public GameObject Minus, Plus;

    public Transform spawnPoint;

    public float shotForce = 50f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        thing = false;
        red = GameObject.FindGameObjectWithTag("red");
        blue = GameObject.FindGameObjectWithTag("blue");
    }

    // Update is called once per frame
    void Update()
    {
        red = GameObject.FindGameObjectWithTag("red");
        blue = GameObject.FindGameObjectWithTag("blue");

        if (Input.GetButtonDown("Fire1"))
        {
            


            if (Time.time > shotRateTime && GameManager.instance.gunAmmo > 0)
            {
                GameManager.instance.gunAmmo--;
                //shotSource.PlayOneShot(shotsound);
                GameObject newBullet = Instantiate(Minus, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 5f);
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (Time.time > shotRateTime && GameManager.instance.gunAmmo > 0)
            {
                GameManager.instance.gunAmmo--;
                //shotSource.PlayOneShot(shotsound);
                GameObject newBullet = Instantiate(Plus, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 5f);
            }
        }




            if (Input.GetButton("Fire3"))
        {
            // blue.transform.Translate(red.transform.position * Time.deltaTime);
            blue.transform.position = Vector3.MoveTowards(blue.transform.position, red.transform.position, 1 + Time.deltaTime);
        }
    }
}
