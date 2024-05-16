using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minetolvl1 : MonoBehaviour
{
    BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (boxCollider != null)
        {
            if (collision.gameObject.name == "Zeus")
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
