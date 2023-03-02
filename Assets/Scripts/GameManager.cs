using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Singleton
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI lifeText;
    public float timer;
    public static GameManager instance
    {
        get; private set; 
    }

    public int gunAmmo = 10;
    public int vidas = 10;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        timer += Time.deltaTime;
        ammoText.text = gunAmmo.ToString();
        lifeText.text = vidas.ToString();
        if (gunAmmo < 0)
        {
            gunAmmo = 0;
        }
    }

    public void LoseHealth(int healthtoReduce)
    {
        if (timer > 0.5f)
        {
            vidas -= healthtoReduce;
            if (vidas <= 0)
            {
                vidas = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            timer = 0;
        }
       
    }
}
