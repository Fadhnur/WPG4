using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private LayerMask PickupLayer;
    [SerializeField] private float ThrowingForce;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private float Pickuprange;
    [SerializeField] private Transform Hand;
    [SerializeField] private GameObject pickUpUI;

    [SerializeField] private GameObject flashlight;
    private bool inReach;

    private Rigidbody CurrentObjectRigidbody;
    private Collider CurrentObjectCollider;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;
    
    private RaycastHit hit;

    void Start() {
        inReach = false;
        flashlight = GameObject.Find("Flashlight");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray Pickupray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
            if(Physics.Raycast(Pickupray, out RaycastHit hitinfo, Pickuprange, PickupLayer))
            {
                if(CurrentObjectRigidbody)
                {
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidbody = hitinfo.rigidbody;
                    CurrentObjectCollider = hitinfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }   
                else
                {
                    CurrentObjectRigidbody = hitinfo.rigidbody;
                    CurrentObjectCollider = hitinfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }

                return;
            }

            if(CurrentObjectRigidbody)
                {
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidbody = null;
                    CurrentObjectCollider = null;

                    
                } 
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(CurrentObjectRigidbody)
                {
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidbody.AddForce(PlayerCamera.transform.forward * ThrowingForce, ForceMode.Impulse);
                    CurrentObjectRigidbody = null;
                    CurrentObjectCollider = null;

                    
                }
        }

        if(CurrentObjectRigidbody)
        {
            CurrentObjectRigidbody.position = Hand.position;
            CurrentObjectRigidbody.rotation = Hand.rotation;

        }
        
        //Mengaktifkan ui pickUp
        Debug.DrawRay(PlayerCamera.position, PlayerCamera.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleOutline(false);
            pickUpUI.SetActive(false);
            
        }

        // if (inHandItem != null)
        // {
        //     return;
        // }

        //menghighlight object yang diambil
        if (Physics.Raycast(PlayerCamera.position, PlayerCamera.forward, out hit, hitRange, PickupLayer))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleOutline(true);
            pickUpUI.SetActive(true);

        }

        //Menambahkan ke ui battery
        if(Input.GetKeyDown(KeyCode.E) && inReach && hit.collider.CompareTag("Battery"))
        {
            /*currentBattery = hit.collider.gameObject;
            currentBattery.SetActive(false);*/

            
            flashlight.GetComponent<FlashLight>().AddBattery();
            inReach = false;

            //currentBattery = null;
            //pickUpSound.Play();
            //Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Battery"))
        {
            inReach = true;
        }
    }

    void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Battery"))
        {
            inReach = false;
        }
    }


}
