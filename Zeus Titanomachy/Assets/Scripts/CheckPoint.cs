using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public DragonController dragon;         // Reference to the Dragon GameObject
    public Transform[] pathGroups; // Array of path group Transforms to move

    private int currentCheckpointIndex = 0; // Index of the current checkpoint in relation to pathGroups

    // Dictionary to map path group index to specific falling amount
    private Dictionary<int, float> pathFallingAmounts = new Dictionary<int, float>()
    {
        { 0, 10f },   // First path falls by 10 units
        { 1, 15f },   // Second path falls by 15 units
        { 2, 47f },   // Third path falls by 47 units
        { 3, 60f },   // Fourth path falls by 60 units
        { 4, 75f },   // Fifth path falls by 75 units
        { 5, 80f }    // Sixth path falls by 80 units
    };

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the dragon's action immediately
            TriggerDragonAction(currentCheckpointIndex);

            // Increment the checkpoint index to move to the next checkpoint
            currentCheckpointIndex++;

            // Check if there are more checkpoints to process
            if (currentCheckpointIndex < pathGroups.Length)
            {
                // Start a coroutine to move the path group after a delay
                StartCoroutine(MovePathGroupDelayed(pathGroups[currentCheckpointIndex], currentCheckpointIndex));
            }
        }
    }

    private IEnumerator MovePathGroupDelayed(Transform pathGroup, int pathIndex)
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        // Check if the pathIndex exists in the pathFallingAmounts dictionary
        if (pathFallingAmounts.ContainsKey(pathIndex))
        {
            float fallingAmount = pathFallingAmounts[pathIndex];
            // Move the path group down on the Y-axis by the specified falling amount
            pathGroup.position -= new Vector3(0f, fallingAmount, 0f);
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
                dragon.thirdCheckpointAction();
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
