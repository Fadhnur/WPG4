using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyFX : MonoBehaviour
{
    [SerializeField] GameObject obj;

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Burn"))
        {
            if(obj != null){
                GameObject explision = Instantiate(obj, transform.position, transform.rotation);
                Destroy(explision, 0.75f);
            }
            
            Destroy(other.gameObject);
        }
    }
}
