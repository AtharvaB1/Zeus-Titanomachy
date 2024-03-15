using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null) {
            if(collision.gameObject.name == "Zeus")
            {
                SceneManager.LoadScene(1);
                SceneManager.GetSceneAt(1);
                //cant remember which one did what, pls fix if broke
            }
        }
    }
}
