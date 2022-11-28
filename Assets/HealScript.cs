using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
           Destroy(this.gameObject);  
    }
}
