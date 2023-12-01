using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {


    public Transform bullet_rocket;
    public Transform bullet_Fire;
    public AudioClip tank_bullet;
    public AudioClip tank_rooket;
    public Transform spw;
    public Transform spw2;
    public RectTransform crosshair;
    public float luc = 200f;
    public float lucbullet;

    public int Rocket = 10;
    public Text RocketText;

    bool bandan;
    bool PussRocket;
   

    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RocketText.text = " " + Rocket;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonFire();
        }
        if (Rocket > 0)
        {
            bandan = true;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ButtRocket();
                Rocket--;
            }
            else if(Rocket <= 0){

                bandan = false;
            }
        }
    }
    public void ButtonFire()
    {
        GameObject bullet1 = Instantiate(bullet_rocket.gameObject, spw.position,spw.rotation) as GameObject;
        bullet1.GetComponent<Rigidbody>().AddForce(spw.forward * lucbullet);
        if (tank_bullet)
        {
            AudioSource.PlayClipAtPoint(tank_bullet, transform.position, 5.0f);
        }

    }
    public void ButtRocket()
    {
        GameObject bullet3 = Instantiate(bullet_Fire.gameObject, spw2.position, spw2.rotation) as GameObject;
        bullet3.GetComponent<Rigidbody>().AddForce(spw2.forward * luc);

        if (tank_rooket)
        {
            AudioSource.PlayClipAtPoint(tank_rooket, transform.position, 100f);
        }
    }
    public void PlusBullet(int PussB)
    {
        //debug cho anh tai day
        Debug.Log("A");
        if(Rocket < 10)
        {
            PussRocket = true;
            Rocket += PussB;
            Debug.Log("B" + Rocket);
            //tai day
             RocketText.text = " " + Rocket;
        }
        else if(Rocket>= 10)
        {
            PussRocket = false;
            Debug.Log("C:");
        }
    }
}
