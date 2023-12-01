using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_explosionAudio;
    public float m_MaxDamage = 100f;
    public float m_ExplosionForce = 1000f;
    public float m_MaxLifeTime = 2f;
    public float m_ExplosionRadius = 5f;

    public GameObject explosion;

    public float force = 1000;

    Vector3 targer;
    public int attackDamage = 5;
    GameObject enemy;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;

    public AudioClip Bulletfire;
    // Use this for initialization
    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
       
        playerHealth = GetComponent<PlayerHealth>();
    }
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireBullet(Vector3 point)
    {
        float dis = Vector3.Distance(point, transform.position);
        targer = new Vector3(point.x, point.y + dis / 20, point.z);
        gameObject.GetComponent<Rigidbody>().AddForce((targer - transform.position).normalized * force);
    }
    public void hut(Vector3 huong)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(huong * force);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Bulletfire)
            {
                AudioSource.PlayClipAtPoint(Bulletfire, transform.position, 500.0f);
            }
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            Attack();
            
            Debug.Log("da va cham voi enemy");
            GameObject exp1 = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject,1f);
            Destroy(exp1, 1.5f);
        }
        else if (other.gameObject.tag == "Ground")
        {
            if (Bulletfire)
            {
                AudioSource.PlayClipAtPoint(Bulletfire, transform.position, 500.0f);
            }
            GameObject exp1 = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(exp1, 1.5f);
        }
        else if(other.gameObject != gameObject)
        {
            if (Bulletfire)
            {
                AudioSource.PlayClipAtPoint(Bulletfire, transform.position, 500.0f);
            }
            GameObject exp1 = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(exp1, 1.5f);
        }


    }
    void Attack()
    {
        enemyHealth.TaKeDamage(attackDamage);
    }

}
