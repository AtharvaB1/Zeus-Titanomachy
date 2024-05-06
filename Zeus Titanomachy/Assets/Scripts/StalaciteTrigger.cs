using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaciteTrigger : MonoBehaviour
{
    [SerializeField] private GameObject stalactite;
    [SerializeField] private GameObject turnOff;
    [SerializeField] private ParticleSystem particlesOff;
    [SerializeField] private GameObject obj;
    private MeshCollider meshCollider;
    private bool isMoving = false;
    private float startY;
    private float moveDuration = 2f;
    private float moveStartTime;

    private void Start()
    {
        startY = stalactite.transform.position.y;
        // Find the GameObject with the Mesh Collider by name
        if (obj != null)
        {
            // Get the Mesh Collider component
            meshCollider = obj.GetComponent<MeshCollider>();

            // Disable the Mesh Collider by default if found
            if (meshCollider != null)
            {
                meshCollider.enabled = false;
            }
            else
            {
                Debug.LogWarning("Mesh Collider not found on GameObject with name: " + obj);
            }
        }
        else
        {
            Debug.LogWarning("GameObject with name " + obj + " not found.");
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            float timeRatio = (Time.time - moveStartTime) / moveDuration;
            if (timeRatio < 1f)
            {
                float newY = Mathf.Lerp(startY, startY - 100f, timeRatio);
                stalactite.transform.position = new Vector3(stalactite.transform.position.x, newY, stalactite.transform.position.z);
            }
            else
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && !isMoving)
            {
                StartMoving();
                turnOff.SetActive(false);
                particlesOff.Stop();
                if (meshCollider != null)
                {
                    meshCollider.enabled = true;
                }
            }
        }
    }

    private void StartMoving()
    {
        isMoving = true;
        moveStartTime = Time.time;
    }
}
