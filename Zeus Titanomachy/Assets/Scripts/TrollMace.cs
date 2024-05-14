using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrollMace : MonoBehaviour
{
    MeshCollider MeshCollider;
    public float dCool = 1.5f;
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        dCool-= Time.deltaTime;
        if (health <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Zeus")
        {
            if (dCool <= 0)
            {
                dCool = 1.5f;
                health -= 25;
            }
        }
    }
}
