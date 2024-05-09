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
    public GameObject MC;
    
    
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
            this.gameObject.transform.LookAt(MC.transform.position);
    }
}
