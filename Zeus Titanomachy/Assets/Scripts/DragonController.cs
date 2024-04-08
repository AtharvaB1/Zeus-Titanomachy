using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
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


    // Specific actions for different checkpoints
    public void firstCheckpointAction()
    {
        // Rotate the dragon 60 degrees counterclockwise over 1 second
        StartCoroutine(RotateDragonCoroutine(-60f, 1f));

        // Trigger the "Hover" animation
        anim.SetBool("Hover", true);

        // Wait for 1 second
        StartCoroutine(ReturnToIdleAgressiveAfterHover(1f));
    }

    // Coroutine to rotate the dragon over time
    private IEnumerator RotateDragonCoroutine(float targetAngle, float duration)
    {
        float currentAngle = transform.eulerAngles.y;
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

            yield return null;
        }

        // Ensure the rotation ends exactly at the target angle
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentAngle + targetAngle, transform.eulerAngles.z);
    }

    // Coroutine to stop the "Hover" animation after a delay
    private IEnumerator ReturnToIdleAgressiveAfterHover(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Stop the "Hover" animation
        anim.SetBool("Hover", false);

        // Transition back to IdleAgressive (assuming "IdleAgressive" is a trigger parameter)
        anim.SetTrigger("IdleAgressive");
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

    // Update is called once per frame
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("IdleSimple"))
            {
                anim.SetBool(IdleSimple, false);
                anim.SetBool(IdleAgressive, false);
                anim.SetBool(IdleRestless, false);
                anim.SetBool(Walk, true);
                anim.SetBool(BattleStance, false);
                anim.SetBool(Bite, false);
                anim.SetBool(Drakaris, false);
                anim.SetBool(FlyingFWD, false);
                anim.SetBool(FlyingAttack, false);
                anim.SetBool(Hover, false);
                anim.SetBool(Lands, false);
                anim.SetBool(TakeOff, false);
                anim.SetBool(Die, false);

            }
        }

    }
    */
}

