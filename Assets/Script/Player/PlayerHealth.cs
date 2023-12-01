using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {


    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;

    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    AudioSource playerAudio;
    ControlPlayer playerMovement;

    bool isDead;
    bool damaged;
    bool pussHP;

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<ControlPlayer>();

        currentHealth = startingHealth;
    }
    // Update is called once per frame
    void Update () {
        //neu damaged == true thi mau se xuat hien
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        //hoac mau se bien mat va tro lai color == 0;
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //reset the damaged flag
        damaged = false;
	}
    public void TakeDamage(int amount)
    {
        //Debug.Log("amont:"+amount);
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        Debug.Log("mau" + healthSlider.value);


      //  playerAudio.Play();
        if(currentHealth <= 0 && !isDead)
        {
            Death();
            SceneManager.LoadScene("GameOver");
        }
       
    }
    void Death()
    {
        isDead = true;
       // playerAudio.clip = deathClip;
        //playerAudio.Play();
        Destroy(gameObject);

        playerMovement.enabled = false;
    }
    public void PusHealth(int amont)
    {
        if (currentHealth < 100)
        {
            pussHP = true;
            currentHealth += amont;
            Debug.Log("mau da cong la" + currentHealth);
           
           healthSlider.value = currentHealth;
        }
        //else if(currentHealth >= 100)
        //{
        //    pussHP = false;
        //}
    }
}
