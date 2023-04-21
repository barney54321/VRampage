using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGrab : MonoBehaviour
{

    Vector3 scale;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrab()
    {
        scale = transform.localScale;
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    public void OffGrab()
    {
        StartCoroutine()
    }

    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localScale = scale;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
