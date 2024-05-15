using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zPunch : MonoBehaviour
{
    SphereCollider SphereCollider;
    public GameObject zes;
    Animator animator;
    public float pCool = 1f;
    // Start is called before the first frame update
    void Start()
    {
        SphereCollider = GetComponent<SphereCollider>();
        animator = zes.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pCool-=Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other!=null)
        {
            if (pCool <= 0f)
            {
                if (other.gameObject.name == "troll1")
                {
                    Debug.Log("SII");
                    lvl3Health.t1Health -= 20;
                    animator.SetTrigger("punch");
                    pCool = 1f;
                }
                if (other.gameObject.name == "troll2")
                {
                    lvl3Health.t2Health -= 20;
                    animator.SetTrigger("punch");
                    pCool = 1f;
                }
                if (other.gameObject.name == "troll3")
                {
                    lvl3Health.t3Health -= 20;
                    animator.SetTrigger("punch");
                    pCool = 1f;
                }
                if (other.gameObject.name == "tinker(Clone)")
                {
                    Destroy(other.gameObject);
                    lvl3Health.bgot = true;
                }
            }
        }
    }
}
