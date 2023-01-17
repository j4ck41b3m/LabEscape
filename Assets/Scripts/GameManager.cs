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
        ammoText.text = gunAmmo.ToString();
        lifeText.text = vidas.ToString();
        if (gunAmmo < 0)
        {
            gunAmmo = 0;
        }
    }

    public void LoseHealth(int healthtoReduce)
    {
        vidas -= healthtoReduce;
        if (vidas <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
