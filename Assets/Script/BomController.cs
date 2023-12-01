using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomController : MonoBehaviour {

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public ParticleSystem explosionEffect;
    public AudioSource m_explosionAudio;


    float countdown;
    bool hasExploded = false;
   public AudioSource bomno;
    public AudioClip bomn1;

    void Start()
    {
        countdown = delay;
       
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
           
        }

    }

    void Explode()
    {
        //show effetc
        Instantiate(explosionEffect, transform.position, transform.rotation);
        

        //Get nearby object
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {

                rb.AddExplosionForce(force, transform.position, radius);
               
            }
        }

        explosionEffect.Stop();


        Destroybom();


    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject != gameObject)
        {
            bomno = gameObject.AddComponent<AudioSource>();
            bomno.clip = bomn1;
            bomno.Play();
        }
    }
    void Destroybom()
    {
        Destroy(gameObject);
        bomno.Stop();
        
        
    }
}
