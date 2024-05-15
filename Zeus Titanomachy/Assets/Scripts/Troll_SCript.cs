using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Troll_SCript : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    SphereCollider sphere;
    public float speed = 20f; //i dont think this works
    public GameObject troll;
    public GameObject MC;
    private bool move;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = troll.GetComponent<Rigidbody>();
        animator = troll.GetComponent<Animator>();
        this.sphere = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sid = new Vector3(MC.transform.position.x,0,MC.transform.position.z);
        troll.gameObject.transform.LookAt(sid);
        this.gameObject.transform.position = new Vector3(troll.transform.position.x,troll.transform.position.y+3,troll.transform .position.z);
        if(move)
        rb.AddForce(Vector3.Lerp(rb.position, sid, speed),ForceMode.Acceleration); // dont think this works
        move = true;
        animator.SetTrigger("walk");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Zeus")
        {
            animator.SetTrigger("attack2");
            move = false;
        }
    }
}
