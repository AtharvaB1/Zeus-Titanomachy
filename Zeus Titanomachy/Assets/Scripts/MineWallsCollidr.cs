using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineWallsCollidr : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "teleport" && other.gameObject.tag == "lb_bird")
        {
            Debug.Log("TP");
            SceneManager.LoadScene("Mine");
        }else if (other.gameObject.tag == "lb_bird")
        {
            other.transform.position = respawnPoint.position;
            Debug.Log("Hit");
        }
    }
}
