using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerIncteraction : MonoBehaviour
{
    public TextMeshProUGUI textAmmo;
    public Transform startposition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AmmoBox"))
        {
            GameManager.instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            Destroy(other.gameObject);
           // textAmmo.text = other.GetComponent<AmmoBox>().ammo.ToString();
        }
        
        if (other.gameObject.CompareTag("SueloMuerte"))
        {
            GameManager.instance.LoseHealth(3);
            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = startposition.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
