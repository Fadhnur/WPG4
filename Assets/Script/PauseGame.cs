using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject resume;
    public GameObject quit;

    public bool on;
    public bool off;

    void Start()
    {
        menu.SetActive(false);
        off = true;
        on = false;
    }


    void Update()
    {
        if (off && Input.GetButtonDown("pause"))//"pause" merupakan tombol "escape"
        {
            Time.timeScale = 0; //Menghentikan jalannya permainan
            menu.SetActive(true);
            off = false;
            on = true;
        }

        else if (on && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 1; //Memulai kembali jalannya permainan 
            menu.SetActive(false);
            off = true;
            on = false;
        }
        
    }

    public void Resume()
    {
            Time.timeScale = 1;
            menu.SetActive(false);
            off = true;
            on = false;

    }

    public void Exit()
    {
        Application.Quit();
    }
}