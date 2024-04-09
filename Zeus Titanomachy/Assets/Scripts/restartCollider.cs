using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            // Restart the scene if the player touches the collider
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
