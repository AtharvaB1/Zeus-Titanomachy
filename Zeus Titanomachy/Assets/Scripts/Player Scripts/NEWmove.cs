using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWmove : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    CapsuleCollider capsule;

    // Start is called before the first frame update
    float horizontal;
    float vertical;
    public float speed = 25;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        Application.targetFrameRate = int.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*vertical*speed*Time.deltaTime);
        transform.Translate(Vector3.right*horizontal*speed*Time.deltaTime);
        animator.SetFloat("front", vertical);
        animator.SetFloat("side",horizontal);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
    public void jump()
    {
        transform.Translate(Vector3.up * 8);
    }
}
