using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject tank; //player
    public GameObject turret; //điểm nằm trong player mà camera di chuyển theo điểm đó
    Transform followPoint;
    public bool status = false;
	// Use this for initialization
	void Start () {
        followPoint = new GameObject().transform; //tạo 1 gameobject trên unity
        followPoint.name = "follow Point"; //đặt tên cho gameobject
        followPoint.position = transform.position; //đặt vị trí của Follwe Point
        followPoint.SetParent(turret.transform); //chọn turret làm dối tượng cha

	}
	
	// Update is called once per frame
	void Update () {
        //di chuyển camera tới vị trí của followPoint
        transform.position = Vector3.Slerp(transform.position, followPoint.position, 2 * Time.deltaTime);

       // Debug.Log(transform.eulerAngles);
        transform.eulerAngles = new Vector3(
            Mathf.LerpAngle(transform.eulerAngles.x, turret.transform.eulerAngles.x + 3, 28 * Time.deltaTime),
            Mathf.LerpAngle(transform.eulerAngles.y, turret.transform.eulerAngles.y, 20 * Time.deltaTime),
        transform.eulerAngles.z);
        //if(status)
        //{
        //        transform.eulerAngles = new Vector3(
        //    Mathf.LerpAngle(transform.eulerAngles.x, transform.eulerAngles.x , 100 * Time.deltaTime),
        //    Mathf.LerpAngle(transform.eulerAngles.y, transform.eulerAngles.y +20, 100 * Time.deltaTime),
        //transform.eulerAngles.z);
        //}
	}
   public IEnumerator Rung()
    {
        status = true;
        //Debug.Log("Rung camera");
        yield return new WaitForSeconds(5f);
        status = false;

    }
}
