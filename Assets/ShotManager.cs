using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
        [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject hitexplosion;
    private GameObject explosions;
       void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Stage")
        {
            explosions=Instantiate (explosion, transform.position, Quaternion.identity);
        }
        else
        {
             explosions = Instantiate(hitexplosion, transform.position, Quaternion.identity);
        }
        Destroy(explosions, 3.0f);
        Destroy(gameObject);
    }
}
