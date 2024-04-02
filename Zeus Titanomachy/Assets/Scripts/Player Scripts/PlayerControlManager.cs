using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2 movementInput;
    [SerializeField] float verticalInput;
    [SerializeField] float horizontalInput;
    [SerializeField] float moveAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void handleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) * Mathf.Abs(horizontalInput));

        if (moveAmount <= 0.5 && moveAmount > 0)
        {
            moveAmount = 0.5f;
        }else if(moveAmount > 0.5 && moveAmount <= 1)
        {
            moveAmount = 1;
        }
    }
}
