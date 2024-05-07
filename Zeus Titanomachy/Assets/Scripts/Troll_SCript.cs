using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_SCript : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    BoxCollider boxCollider;
    MeshCollider mace;
    public float speed = 10f;
    
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
        
    }
}
