using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartCollider : MonoBehaviour
{
    public Healthbar healthBar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            healthBar.updateHealthBar(100, 0);
            // Restart the scene if the player touches the collider
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
