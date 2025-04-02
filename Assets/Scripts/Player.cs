using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}
    [SerializeField] private float moveSpeedPlayer = 5f;

    
    private Rigidbody2D rb;

    private float minMoveSpeed = 0.01f; 
    private bool isMoving = false; 

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        
    }  


    private void FixedUpdate()
    {   
        HandleMovement();
    }

    private void HandleMovement(){
        Vector2 movement = GameInput.Instance.GetMovementVector();
        rb.MovePosition(rb.position + movement * (moveSpeedPlayer * Time.fixedDeltaTime));    
    
        if(Mathf.Abs(movement.x) > minMoveSpeed || Mathf.Abs(movement.y) > minMoveSpeed){
            isMoving = true;
        }else{
            isMoving = false;
        }   
    } 

    public bool IsMoving(){
        return isMoving;
    }     

    public float GetHorizontalInput()
    {
        return GameInput.Instance.GetMovementVector().x;
    }

    public float GetVerticalInput()
    {
        return GameInput.Instance.GetMovementVector().y;
    }

    public float GetSpeed()
    {
        Vector2 movement = GameInput.Instance.GetMovementVector();
        return Mathf.Sqrt(movement.x * movement.x + movement.y * movement.y);
    }
}
