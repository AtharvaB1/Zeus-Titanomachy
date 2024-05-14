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
    public float speed = 10f;
    public GameObject MC;
    private bool move;
    public float raydist = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sid = new Vector3(MC.transform.position.x,0,MC.transform.position.z);
        this.gameObject.transform.LookAt(sid);
        move = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Zeus")
        {
            animator.SetTrigger("attack2");
        }
    }
}
