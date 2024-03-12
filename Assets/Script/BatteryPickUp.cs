using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    private bool inReach;

    public GameObject pickUpText;
    private GameObject flashlight;

    public AudioSource pickUpSound;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        flashlight = GameObject.Find("Flashlight");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }




    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inReach)
        {
            flashlight.GetComponent<FlashLight>().batteries += 1;
            pickUpSound.Play();
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }
        
    }
}