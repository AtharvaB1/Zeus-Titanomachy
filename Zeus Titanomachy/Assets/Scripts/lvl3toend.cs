using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl3toend : MonoBehaviour
{
    BoxCollider BoxCollider;
    bool finish =false;
    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        BoxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lvl3Health.ext1&& lvl3Health.ext2&& lvl3Health.ext3&& lvl3Health.bgot)
        {
            finish=true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision!=null)
        {
            if(finish)
            {
                if (collision.gameObject.name == "Zeus")
                {
                    Debug.Log("end");
                    SceneManager.LoadScene(6);
                }
            }
        }
    }
}
