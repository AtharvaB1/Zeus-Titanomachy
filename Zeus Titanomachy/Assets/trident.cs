using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trident : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool tridC = false;
    public AudioSource tridentAudioSource;
    BoxCollider boxCollider;
    void Start()
    {
        tridC = false;
        boxCollider = new BoxCollider();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tridC)
        {
            this.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Zeus (2)")
        {
            tridentAudioSource.Play();
            tridC=true;
            
        }
    }
}
