using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControll : MonoBehaviour {


    public int attackDamage = 20;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float time;

    public AudioClip eShoot; 
    public GameObject explosion;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log("ten player:" + player.name);
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnCollisionEnter(Collision other)
    {
       // Debug.Log("da va cham;" + other.transform.name);
        //Debug.Log("da va cham;" +player.name);
        if (other.gameObject.name == player.name)
        {
            if (eShoot)
            {
                AudioSource.PlayClipAtPoint(eShoot, transform.position, 500.0f);
            }
            GameObject exp2 = Instantiate(explosion, transform.position, Quaternion.identity);
            // MusicAllGame.Instance.PlayMusicGame(6);//dung nay de phat
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().PlayOneShot(MusicAllGame.Instance.aClip[6]);


           // StartCoroutine(Camera.main.GetComponent<CameraController>().Rung());
            Destroy(gameObject);
            Destroy(exp2, 1.5f);
           // Debug.Log("da va cham;" + other.transform.name);
            //Debug.Log("va cham:");
            Attack();
            playerInRange = true;

        }
        else if(other.gameObject.tag == "Ground"){
            if (eShoot)
            {
                AudioSource.PlayClipAtPoint(eShoot, transform.position, 500.0f);
            }
            GameObject exp2 = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(exp2, 1.5f);
        }
        else if(other.gameObject != gameObject)
        {
            if (eShoot)
            {
                AudioSource.PlayClipAtPoint(eShoot, transform.position, 500.0f);
            }
            GameObject exp2 = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(exp2, 1.5f);
        }
    }
     void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("va cham ");
            Attack();
            playerInRange = false;
        }
        
    }
    // Use this for initialization
    void Start () {
        Destroy(gameObject, 3f);
		
	}
	
	// Update is called once per frame
	void Update () {
       
           
        
	}
    void Attack()
    {
        //Debug.Log("attck");
            playerHealth.TakeDamage(attackDamage);

    }
}
