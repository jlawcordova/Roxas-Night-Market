using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < 0.6666f && transform.position.y < 1.125f)
        {
            transform.position += new Vector3(-0.015f, 0.01f, 0);
        }
        else
        {
            transform.position = Vector3.zero;
        }
        
	}
}
