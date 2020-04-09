using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float delay = 3f;
    public float blastRadius = 5f;
    public float explosionForce = 700f;

    float countdown;
    bool hasExploded;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        //Show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //Find nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in colliders)
        {
            //Add forces
            Rigidbody nearbyRb = nearbyObject.GetComponent<Rigidbody>();

            if(nearbyRb != null)
            {
                nearbyRb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }

        

        //Remove grenade
        //Destroy(GameObject);
    }
}
