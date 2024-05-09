using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineTPSCRIPT : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    Rigidbody rgbdy;
    int m_Speed = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lb_bird")
        {
            other.transform.position = respawnPoint.position;
            Debug.Log("Hit");
        }
    }

    private void Update()
    {
        transform.Translate(-Vector3.forward * m_Speed * Time.deltaTime);
    }
}
