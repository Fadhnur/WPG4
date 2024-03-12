using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountObj : MonoBehaviour
{
    [SerializeField] int Count;
    public 

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            Count ++;
            Debug.Log("counting");
        }
    }
}
