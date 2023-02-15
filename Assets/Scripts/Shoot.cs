using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    private Quaternion startRotation;
    private float swayAmount = 8;

    public Transform spawnPoint;
    public GameObject bullet;

    public float shotForce = 50f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;


    public AudioClip shotsound;
    private AudioSource shotSource;
    // Start is called before the first frame update
    void Start()
    {
        shotSource = GetComponent<AudioSource>();
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Sway();
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shotRateTime && GameManager.instance.gunAmmo > 0)
            {
                GameManager.instance.gunAmmo--;
                //textAmmo.text = GameManager.instance.gunAmmo.ToString();
                shotSource.PlayOneShot(shotsound);
                GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 5f);
            }
            
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
}
