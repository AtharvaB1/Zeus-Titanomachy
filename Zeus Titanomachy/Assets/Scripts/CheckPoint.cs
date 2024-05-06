using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public DragonController dragon;         // Reference to the Dragon GameObject
    public Transform[] pathGroups; // Array of path group Transforms to move

    public int currentCheckpointIndex = 0; // Index of the current checkpoint in relation to pathGroups
    public ParticleSystem particles;      // Reference to the ParticleSystem
    private bool particleSystemActivated = false;
    public GameObject restartColliderObject;

    // Dictionary to map path group index to specific falling amount
    private Dictionary<int, float> pathFallingAmounts = new Dictionary<int, float>()
    {
        { 0, 10f },   // First path falls by 10 units
        { 1, 25f },   // Second path falls by 15 units
        { 2, 50f },   // Third path falls by 47 units
        { 3, 60f },   // Fourth path falls by 60 units
        { 4, 75f },   // Fifth path falls by 75 units
        { 5, 90f }    // Sixth path falls by 80 units
    };

    private void Start()
    {
        // Check if a ParticleSystem is assigned and deactivate it at the start of the game
        if (particles != null)
        {
            particles.Stop(); // Stop the ParticleSystem
        }

        if (restartColliderObject != null)
        {
            restartColliderObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the dragon's action immediately
            TriggerDragonAction(currentCheckpointIndex);

            if (currentCheckpointIndex == 0 && !particleSystemActivated && particles != null)
            {
                // Activate and play the ParticleSystem
                particles.Play();
                particleSystemActivated = true;

                if (restartColliderObject != null)
                {
                    restartColliderObject.SetActive(true);
                }
            }

            // Check if there are more checkpoints to process
            if (currentCheckpointIndex < pathGroups.Length)
            {
                // Start a coroutine to move the path group after a delay
                StartCoroutine(MovePathGroupDelayed(pathGroups[currentCheckpointIndex], currentCheckpointIndex));
            }
            currentCheckpointIndex++;
        }
    }

    private IEnumerator MovePathGroupDelayed(Transform pathGroup, int pathIndex)
    {
        float delayDuration = 7f; // Delay duration before starting movement
        float fallingDuration = 4f; // Total time for the path group to fall
        float elapsedTime = 0f; // Time elapsed since start of coroutine

        // Wait for the delay duration before starting the movement
        yield return new WaitForSeconds(delayDuration);

        // Check if the pathIndex exists in the pathFallingAmounts dictionary
        if (pathFallingAmounts.ContainsKey(pathIndex))
        {
            float fallingAmount = pathFallingAmounts[pathIndex];
            Vector3 startPosition = pathGroup.position;
            Vector3 targetPosition = startPosition - new Vector3(0f, fallingAmount, 0f);

            while (elapsedTime < fallingDuration)
            {
                // Calculate interpolation parameter (0 to 1) based on elapsed time
                float t = elapsedTime / fallingDuration;

                // Interpolate position using Lerp
                pathGroup.position = Vector3.Lerp(startPosition, targetPosition, t);

                // Increment elapsed time
                elapsedTime += Time.deltaTime;

                // Wait for the next frame
                yield return null;
            }

            // Ensure final position is exactly the target position
            pathGroup.position = targetPosition;
        }
        else
        {
            Debug.LogWarning("Path falling amount not specified for index: " + pathIndex);
        }
    }

    private void TriggerDragonAction(int checkpointIndex)
    {
        // Trigger different actions for the dragon based on the checkpoint index
        switch (checkpointIndex)
        {
            case 0:
                Debug.Log("Dragon action for checkpoint 1");
                dragon.firstCheckpointAction();
                break;
            case 1:
                Debug.Log("Dragon action for checkpoint 2");
                dragon.secondCheckpointAction();
                break;
            case 2:
                Debug.Log("Dragon action for checkpoint 3");
                dragon.thirdCheckpointAction(); ;
                break;
            case 3:
                Debug.Log("Dragon action for checkpoint 4");
                dragon.fourthCheckpointAction();
                break;
            case 4:
                Debug.Log("Dragon action for checkpoint 5");
                dragon.fifthCheckpointAction();
                break;
            case 5:
                Debug.Log("Dragon action for checkpoint 6");
                dragon.sixthCheckpointAction();
                break;
        }
    }
}
