using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Troll_SCript : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    BoxCollider boxCollider;
    MeshCollider mace;
    public float speed = 10f;
    public GameObject MC;
    public float raydist = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        mace = GetComponentInChildren<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = transform.forward * speed;
        RaycastHit hit;
        Debug.DrawRay(this.gameObject.transform.position, this.gameObject.transform.TransformDirection(Vector3.forward),Color.blue,20000,false);
        //this.gameObject.transform.rotation.x = Quaternion.identity;
        if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.TransformDirection(Vector3.forward), out hit, raydist, 0, QueryTriggerInteraction.Ignore))
        {
            Debug.Log("tre");

        }
        else
            Debug.Log("fals");
    }
}
