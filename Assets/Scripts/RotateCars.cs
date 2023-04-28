using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateCars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            //child is your child transform
            GameObject obj = child.gameObject;

            Quaternion rot = UnityEngine.Random.rotation;

            obj.transform.rotation = Quaternion.Euler(0, rot.y * 200, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
