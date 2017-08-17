using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO Pass arguments from preparation scene.
public class StallGenerator : MonoBehaviour {

    public GameObject kwekKwekStall;

    void Awake()
    {
        Instantiate(kwekKwekStall, new Vector3(-4, 2, 0), Quaternion.identity);
        Instantiate(kwekKwekStall, new Vector3(0, 2, 0), Quaternion.identity);
        Instantiate(kwekKwekStall, new Vector3(4, 2, 0), Quaternion.identity);
    }
}
