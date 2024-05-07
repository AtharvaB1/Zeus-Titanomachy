using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleEffect;
    public GameObject targetObject;
    private Animator anim;
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
        // Constantly rotate towards the target object
        RotateTowardsTarget();
    }


    // Specific actions for different checkpoints
    public void firstCheckpointAction()
    {
        // Rotate the dragon degrees counterclockwise over 1 second
        StartCoroutine(RotateDragonCoroutine(-30f, 10f, 1f));

        // Trigger the animation
        anim.SetBool("Drakaris", true);
        particleEffect.Play();

        // Wait for 1 second
        StartCoroutine(ReturnToIdleSimpleAfterDelay("Drakaris", 2f));
    }

    public void secondCheckpointAction()
    {
        // Example: Trigger specific animation or action for the second checkpoint
        Debug.Log("Performing action for second checkpoint");
        // Add your specific actions here
    }

    public void thirdCheckpointAction()
    {
        // Example: Trigger specific animation or action for the third checkpoint
        Debug.Log("Performing action for third checkpoint");
        // Add your specific actions here
    }

    public void fourthCheckpointAction()
    {
        // Example: Trigger specific animation or action for the fourth checkpoint
        Debug.Log("Performing action for fourth checkpoint");
        // Add your specific actions here
    }

    public void fifthCheckpointAction()
    {
        // Example: Trigger specific animation or action for the fifth checkpoint
        Debug.Log("Performing action for fifth checkpoint");
        // Add your specific actions here
    }

    public void sixthCheckpointAction()
    {
        // Example: Trigger specific animation or action for the sixth checkpoint
        Debug.Log("Performing action for sixth checkpoint");
        // Add your specific actions here
    }

    public void dieKekw()
    {
        anim.SetBool("IdleSimple", false);
        anim.SetBool("Die", true);
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

    // Coroutine to rotate the dragon over time
    private IEnumerator RotateDragonCoroutine(float targetAngle, float targetYOffset, float duration)
    {
        float currentAngle = transform.eulerAngles.y;
        float startY = transform.position.y;
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the interpolation factor (0 to 1)
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Interpolate rotation smoothly
            float newAngle = Mathf.LerpAngle(currentAngle, currentAngle + targetAngle, t);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newAngle, transform.eulerAngles.z);

            // Interpolate Y position smoothly
            float newY = Mathf.Lerp(startY, startY + targetYOffset, t);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            yield return null;
        }

        // Ensure the rotation ends exactly at the target angle
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentAngle + targetAngle, transform.eulerAngles.z);

        // Ensure the position ends exactly at the target Y offset
        transform.position = new Vector3(transform.position.x, startY + targetYOffset, transform.position.z);
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
}

