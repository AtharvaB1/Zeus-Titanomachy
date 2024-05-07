using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleEffect;
    private bool isMovingY = false;
    public GameObject targetObject;
    private Animator anim;
    public Healthbar healthBar;
    public GameObject raytraceStarter;
    public int currentHealth = 100;
    private Vector3 originalPosition;
    int IdleSimple;
    int IdleAgressive;
    int IdleRestless;
    int Walk;
    int BattleStance;
    int Bite;
    int Drakaris;
    int FlyingFWD;
    int FlyingAttack;
    int Hover;
    int Lands;
    int TakeOff;
    int Die;
    void Start()
    {
        if (particleEffect != null)
        {
            particleEffect.Stop();
        }
        originalPosition = transform.position;
        RotateTowardsTarget();
        anim = GetComponent<Animator>();
        IdleSimple = Animator.StringToHash("IdleSimple");
        IdleAgressive = Animator.StringToHash("IdleAgressive");
        IdleRestless = Animator.StringToHash("IdleRestless");
        Walk = Animator.StringToHash("Walk");
        BattleStance = Animator.StringToHash("BattleStance");
        Bite = Animator.StringToHash("Bite");
        Drakaris = Animator.StringToHash("Drakaris");
        FlyingFWD = Animator.StringToHash("FlyingFWD");
        FlyingAttack = Animator.StringToHash("FlyingAttack");
        Hover = Animator.StringToHash("Hover");
        Lands = Animator.StringToHash("Lands");
        TakeOff = Animator.StringToHash("TakeOff");
        Die = Animator.StringToHash("Die");

    }

    private void Update()
    {
        RotateTowardsTarget();
    }

    // Specific actions for different checkpoints
    public void firstCheckpointAction()
    {
        //Move the dragon up by value
        MoveOnYAxis(1);
        
        // Trigger the animation
        anim.SetBool("Drakaris", true);
        particleEffect.Play();

        fireRaycast();

        // Wait for 1 second
        StartCoroutine(ReturnToIdleSimpleAfterDelay("Drakaris", 1f));
    }

    public void secondCheckpointAction()
    {
        MoveOnYAxis(1);

        // Trigger the animation
        anim.SetBool("Drakaris", true);
        particleEffect.Play();

        fireRaycast();

        // Wait for 1 second
        StartCoroutine(ReturnToIdleSimpleAfterDelay("Drakaris", 1f));
    }

    public void thirdCheckpointAction()
    {
        MoveOnYAxis(1);

        // Trigger the animation
        anim.SetBool("Drakaris", true);
        particleEffect.Play();

        fireRaycast();

        // Wait for 1 second
        StartCoroutine(ReturnToIdleSimpleAfterDelay("Drakaris", 1f));
    }

    public void fourthCheckpointAction()
    {
        MoveOnYAxis(1);

        // Trigger the animation
        anim.SetBool("Drakaris", true);
        particleEffect.Play();

        fireRaycast();

        // Wait for 1 second
        StartCoroutine(ReturnToIdleSimpleAfterDelay("Drakaris", 1f));
    }

    public void fifthCheckpointAction()
    {
        MoveOnYAxis(1);

        // Trigger the animation
        anim.SetBool("Drakaris", true);
        particleEffect.Play();

        fireRaycast();

        // Wait for 1 second
        StartCoroutine(ReturnToIdleSimpleAfterDelay("Drakaris", 1f));
    }

    public void sixthCheckpointAction()
    {
        // Trigger the animation
        anim.SetBool("Drakaris", true);
        particleEffect.Play();

        fireRaycast();

        // Wait for 1 second
        StartCoroutine(ReturnToIdleSimpleAfterDelay("Drakaris", 1f));
    }

    public void dieKekw()
    {
        anim.SetBool("IdleSimple", false);
        anim.SetBool("Die", true);
        MoveToOriginalPosition(2f);
    }

    private void RotateTowardsTarget()
    {
        if (targetObject != null)
        {
            // Calculate the direction vector from the dragon to the target object
            Vector3 targetDirection = targetObject.transform.position - transform.position;
            targetDirection.y = 0f; // Ensure rotation only happens in the horizontal plane

            // Rotate the dragon to face towards the target object
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }

    public void MoveOnYAxis(float duration)
    {
        if (!isMovingY)
        {
            isMovingY = true;
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = new Vector3(transform.position.x, targetObject.transform.position.y, transform.position.z);
            StartCoroutine(MoveCoroutine(startPosition, targetPosition, duration));
        }
    }

    IEnumerator MoveCoroutine(Vector3 startPosition, Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMovingY = false;
    }

    private void fireRaycast()
    {
        // Calculate the direction towards the targetObject
        Vector3 direction = (targetObject.transform.position - raytraceStarter.transform.position).normalized;

        // Loop through 10 times to shoot 10 different raycasts
        for (int i = 0; i < 10; i++)
        {
            // Calculate the rotation offset based on the iteration count
            Quaternion rotationOffset = Quaternion.Euler(Random.insideUnitSphere * 5f);

            // Create a ray from the raytraceStarter GameObject's position towards the targetObject with the rotation offset
            Ray ray = new Ray(raytraceStarter.transform.position, rotationOffset * direction);

            // Declare a RaycastHit variable to store information about the hit object
            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object has the "Player" tag
                if (hit.collider.CompareTag("Player"))
                {
                    // Subtract 10 from the currentHealth variable
                    currentHealth -= 15;
                    healthBar.updateHealthBar(100, currentHealth);

                    // Output the new health value to the console (optional)
                    Debug.Log("Player hit! Current health: " + currentHealth);

                    // Exit the loop to ensure only the first hit counts
                    break;
                }
            }
        }
    }

    // Coroutine to stop the "Hover" animation after a delay
    private IEnumerator ReturnToIdleSimpleAfterDelay(string orig, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Stop the "Hover" animation
        particleEffect.Stop();
        anim.SetBool(orig, false);
        anim.SetBool("IdleSimple", true);

    }

    public void MoveToOriginalPosition(float duration)
    {
        // Check if the dragon is not already moving
        if (!isMovingY)
        {
            // Set the dragon as moving
            isMovingY = true;

            // Start coroutine to move the dragon
            StartCoroutine(MoveCoroutine(transform.position, originalPosition, duration));
        }
    }
}

