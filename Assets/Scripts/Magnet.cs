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

    public float soundTime;
    public float shotForce = 50f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;

    public AudioClip shotsound, gather;
    private AudioSource shotSource;
    // Start is called before the first frame update
    void Start()
    {
        shotSource = GetComponent<AudioSource>();

        thing = false;
        red = GameObject.FindGameObjectWithTag("red");
        blue = GameObject.FindGameObjectWithTag("blue");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        red = GameObject.FindGameObjectWithTag("red");
        blue = GameObject.FindGameObjectWithTag("blue");
        if (blue == null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                print("biii");



                if (Time.time > shotRateTime)
                {
                    //GameManager.instance.gunAmmo--;
                    //shotSource.PlayOneShot(shotsound);
                    GameObject newBullet = Instantiate(Minus, spawnPoint.position, spawnPoint.rotation);
                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                    shotRateTime = Time.time + shotRate;
                    Destroy(newBullet, 5f);
                    shotSource.PlayOneShot(shotsound);
                }
            }
        }

        if (red == null)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                print("biii");
                if (Time.time > shotRateTime)
                {
                    //GameManager.instance.gunAmmo--;
                    //shotSource.PlayOneShot(shotsound);
                    GameObject newBullet = Instantiate(Plus, spawnPoint.position, spawnPoint.rotation);
                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                    shotRateTime = Time.time + shotRate;
                    Destroy(newBullet, 5f);
                    shotSource.PlayOneShot(shotsound);

                }
            }
        }
        




            if (Input.GetButton("Fire3"))
        {
            if (blue != null && red != null)
            {
                
                soundTime += Time.deltaTime;
                blue.transform.position = Vector3.MoveTowards(blue.transform.position, red.transform.position, 0.5f + Time.deltaTime);
                if (soundTime > 0.1f)
                {
                    shotSource.PlayOneShot(gather, 0.3f);

                    soundTime = 0;
                }

            }
            //blue.transform.Translate(red.transform.localPosition * Time.deltaTime);

        }
    }

   
}
