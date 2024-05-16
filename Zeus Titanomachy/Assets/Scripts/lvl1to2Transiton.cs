using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1to2Transiton : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&trident.tridC)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
