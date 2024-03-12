using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLight : MonoBehaviour
{
    //public Light light;
    public GameObject lightSource;
    public TMP_Text percentage;

    public TMP_Text batteryAmmount;

    public float lifetime = 100;

    public float batteries = 0;

    public AudioSource flashON;
    public AudioSource flashOFF;

    private bool on;
    private bool off;


    void Start()
    {
        //light = GetComponent<Light>();

        off = true;
        //light.enabled = false;
        lightSource.SetActive(false);
    }



    void Update()
    {
        percentage.text = lifetime.ToString("0") + "%";
        batteryAmmount.text = batteries.ToString();

        if(Input.GetKeyDown(KeyCode.F) && off)
        {
            Debug.Log("F pressed");
            flashON.Play();
            //light.enabled = true;
            lightSource.SetActive(true);
            on = true;
            off = false;
        }

        else if (Input.GetKeyDown(KeyCode.F) && on)
        {
            Debug.Log("F pressed");
            flashOFF.Play();
            //light.enabled = false;
            lightSource.SetActive(false);
            on = false;
            off = true;
        }

        if (on)
        {
            lifetime -= 1 * Time.deltaTime;
        }

        if(lifetime <= 0)
        {
            //light.enabled = false;
            lightSource.SetActive(false);
            on = false;
            off = true;
            lifetime = 0;
        }

        if (lifetime >= 100)
        {
            lifetime = 100;
        }

        if (Input.GetKeyDown(KeyCode.R) && batteries >= 1)
        {
            Debug.Log("R Pressed");
            batteries -= 1;
            lifetime += 50;
        }

        if (Input.GetKeyDown(KeyCode.R) && batteries == 0)
        {
            Debug.Log("R Pressed");
            return;
        }

        if(batteries <= 0)
        {
            batteries = 0;
        }
    }

    public void AddBattery(){
        batteries +=1;
    }
}
