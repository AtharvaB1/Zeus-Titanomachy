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
        // Example: Trigger specific animation or action for the first checkpoint
        Debug.Log("Performing action for first checkpoint");
        anim.SetBool(Hover, true);
        // Add your specific actions here
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

