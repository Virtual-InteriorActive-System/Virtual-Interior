using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hackathon : MonoBehaviour {
    public float speed = 5f;
    public Vector3 vector3;

	//private void OnMouseDown()
	//{
 //       transform.Translate(0, speed * Time.deltaTime, 0);  
	//}

	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
        //if(Input.GetButton("UP")){
        //    transform.Translate(0, speed * Time.deltaTime, 0);
        //}
        //if (Input.GetButton("DOWN"))
        //{
        //    transform.Translate(0, -speed * Time.deltaTime, 0);
        //}

        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(-Vector3.down * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
	}

	
}
