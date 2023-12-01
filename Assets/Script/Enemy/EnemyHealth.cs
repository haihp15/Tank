using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float startHealth = 20f;
    private float health;

    [Header("Unity Stuff")]
    public Image healthBar;
    public AudioSource tankno;
    public AudioClip tankno1;

    //explo
    public GameObject destroyedVersion;

    void Start()
    {
        health = startHealth;
    }
    public void TaKeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health/ startHealth;

        if(health <= 0)
        {
            tankno = gameObject.AddComponent<AudioSource>();
            tankno.clip = tankno1;
            tankno.Play();
            Explode();
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Doi tuong destroy:" + gameObject.name);
        Destroy(gameObject);
        tankno.Stop();
    }

    public void Explode()
    {

        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
