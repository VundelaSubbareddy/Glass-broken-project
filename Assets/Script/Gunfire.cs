using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfire : MonoBehaviour
{
    public Transform firepos;
    Rigidbody rd;
    public float firetime = 2f;
    private float timer = 0.01f;
    public GameObject prefab;
    public float Range = 20f;


    void Start()
    {
        rd = GetComponent<Rigidbody>();

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X))
        {
            firepoS();
           
        }
       
    }
    void firepoS()
    {
        Debug.Log("fire");
        GameObject g = Instantiate(prefab, firepos.transform.position,firepos.transform.rotation);
        Rigidbody rb = g.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,0,Range);
       // rb.AddForce(Vector3.forward * 10f);
        Destroy(g , 1f);
    }
}
