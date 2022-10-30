using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
        [SerializeField] private GameObject explosion;
       void OnCollisionEnter(Collision other)
    {

            GameObject explosions= Instantiate (explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosions,3.0f);
    }
}
