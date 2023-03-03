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
    public GameObject panel;
    public TextMeshProUGUI lifeText;
    public float timer;
    private bool paused;
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

        if (paused == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = true;
                panel.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        else
            if (paused == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = false;
                panel.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;

            }
        }
        
        



    }

    public void toMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;


    }

    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;


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
