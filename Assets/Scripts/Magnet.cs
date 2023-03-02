using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject blue, red;
    public bool thing;
    private float swayAmount = 8;

    public GameObject Minus, Plus;

    public Transform spawnPoint;
    private Quaternion startRotation;

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
        Sway();
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

    private void Sway()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion yAngle = Quaternion.AngleAxis(mouseY * -1.25f, Vector3.up);
        Quaternion xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.left);

        Quaternion targetRoation = startRotation * xAngle * yAngle;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRoation, Time.deltaTime * swayAmount);


    }

    public void Nullyfy()
    {
        GameObject[] fogs = GameObject.FindGameObjectsWithTag("fog");
        for (int i = 0; i < fogs.Length; i++)
        {
            Destroy(fogs[i]);
        }

        GameObject[] reds = GameObject.FindGameObjectsWithTag("red");
        for (int i = 0; i < reds.Length; i++)
        {
            reds[i].tag = "metal";
        }

        GameObject[] blues = GameObject.FindGameObjectsWithTag("blue");
        for (int i = 0; i < blues.Length; i++)
        {
            blues[i].tag = "metal";
        }

        blue = null;
        red = null;
    }


}
