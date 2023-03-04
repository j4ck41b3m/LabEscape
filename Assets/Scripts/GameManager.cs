using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Singleton
    public GameObject panel;
    public GameObject[] enemies;
    public TextMeshProUGUI ammoText, lifeText, bombstext, scoretext;
    public float timer;
    public int initEnemies, currEnemies;
    private bool paused;
    public static GameManager instance
    {
        get; private set; 
    }

    public int gunAmmo = 10;
    public int vidas = 10;
    public int granadas = 3;

    private void Awake()
    {
        instance = this;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        initEnemies = enemies.Length;
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        currEnemies = enemies.Length;

        timer += Time.deltaTime;
        ammoText.text = gunAmmo.ToString();
        lifeText.text = vidas.ToString();
        bombstext.text = granadas.ToString();
        scoretext.text = currEnemies.ToString() + "/" + initEnemies.ToString(); 

        if (gunAmmo < 0)
        {
            gunAmmo = 0;
        }

        if (granadas < 0)
        {
            granadas = 0;
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
