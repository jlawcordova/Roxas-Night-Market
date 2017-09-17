using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Speed;
    public float LeftEnd;
    public float RightEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(Speed, 0, 0);

        if (Speed < 0)
        {
            if (transform.position.x < LeftEnd)
            {
                transform.position = new Vector3(RightEnd, transform.position.y, 0);
            }
        }
        else
        {
            if (transform.position.x > RightEnd)
            {
                transform.position = new Vector3(LeftEnd, transform.position.y, 0);
            }
        }
        
	}
}
