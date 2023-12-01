using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {
    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    float WPradius = 1;
    bool statusDichuyen = true;
    bool tang = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(waypoints[current].transform.position,transform.position) < WPradius)
        {
            float thoigiandung = waypoints[current].GetComponent<InfoDiem>().Thoigiandung;
            statusDichuyen = false;
           

            Invoke("WaitTime", thoigiandung);
           
        }
        if(statusDichuyen)
        {
            //xác định hướng cần xoay tới
            Vector3 relativePos = waypoints[current].transform.position - transform.position;
            // sử dụng hàm LookRotation để đưa ra vòng cần quay
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            // di chuyển camera theo vòng quay được tính
            transform.rotation = rotation;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
       
        
	}
    void WaitTime()
    {
       // Debug.Log("Het cho -> di chuyen toi diem tiep theo");

        if (statusDichuyen == false)
        {

            

            if (tang)
            {
                current++;
                if (current < waypoints.Length - 1)
                    tang = true;
                else
                {
                    tang = false;
                }
            }        
            else
            {
                current--;
                if (current > 0)
                    tang = false;
                else
                    tang = true;
            }
                
                    

                
        }
        statusDichuyen = true;
       //w Debug.Log("current:" + current);
        // yield return new WaitForSeconds(thoigiancho);

    }

}
