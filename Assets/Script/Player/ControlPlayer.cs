using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    float Health = 100f;

    float currentMoveSpeed;         // Tốc độ di chuyển theo thời gian (VD: di chuyển nhanh dần từ 0, hay chậm dần từ 100)
    float finalMoveSpeed;           // Tốc độ đạt được (VD: tốc độ max là 120 của xe máy)

    public float speed = 12f;

    float currentRotateSpeed;
    float finalRotateSpeed;
    //
    public Transform[] rightWheels, leftWheels;
    //
   

    public GameObject barrel;
    public float speedBarrelRotate = 5f;
    bool rotUpBarrel, rotDownBarrel;

    AudioSource Enzin;
    public AudioClip enzin;
    bool button;

    void Awake()
    {
        Enzin = gameObject.AddComponent<AudioSource>();
        Enzin.clip = enzin;
        
        
        
    }
    //	// Update is called once per frame
    void Update()
    {


        currentMoveSpeed = Mathf.MoveTowards(currentMoveSpeed, finalMoveSpeed, Time.deltaTime); // Ở đây Time.deltaTime <=> (1.5f/1.5f) * Time.deltaTime
        transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
        // + 
        currentRotateSpeed = Mathf.MoveTowards(currentRotateSpeed, finalRotateSpeed, (360 / 7 / 1.5f) * Time.deltaTime);
        transform.Rotate(Vector3.up * currentRotateSpeed * Time.deltaTime);
        //
        for (int i = 0; i < rightWheels.Length; i++)
        {
            // Xoay bánh khi xoay xe tăng:
            rightWheels[i].Rotate(Vector3.down * 5 * currentRotateSpeed * Time.deltaTime);
            leftWheels[i].Rotate(Vector3.up * 5 * currentRotateSpeed * Time.deltaTime);

            // Xoay bánh khi di chuyển xe tăng:
            rightWheels[i].Rotate(Vector3.up * 10 * currentMoveSpeed * (360 / 7) * Time.deltaTime);
            leftWheels[i].Rotate(Vector3.up * 10 * currentMoveSpeed * (360 / 7) * Time.deltaTime);
        }
        //
        //soundTank.pitch = 0.5f + Mathf.Abs(currentMoveSpeed / 1.5f / 3);
        //
        if (Input.GetKey(KeyCode.W))
        {
            
            //gameObject.GetComponent<AudioSource>().Stop();
            //gameObject.GetComponent<AudioSource>().PlayOneShot(MusicAllGame.Instance.aClip[4]);
            finalMoveSpeed = 1.5f;
        }
        //
        if (Input.GetKey(KeyCode.S))
        {
            finalMoveSpeed = -1.5f;
            if(button == true)
            {
                Enzin.Play();
            }
            else
            {
                Enzin.Stop();
            }
           

        }
        //
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            finalMoveSpeed = 0;
            //			finalRotateSpeed = 0;
        }
        //
        //
        if (Input.GetKey(KeyCode.A))
        {
            finalRotateSpeed = -360 / 7; // 360 do la 1 vong quay
        }

        if (Input.GetKey(KeyCode.D))
        {
            finalRotateSpeed = 360 / 7;
        }
        //
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            finalRotateSpeed = 0;
        }


        if (rotUpBarrel == true)
        {
            barrel.transform.Rotate(-speedBarrelRotate * Time.deltaTime, 0, 0);
        }
        if (rotDownBarrel == true)
        {
            barrel.transform.Rotate(speedBarrelRotate * Time.deltaTime, 0, 0);
        }



    }
   
}