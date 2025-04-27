using UnityEngine;

public class GameInput : MonoBehaviour
{
    // Синглтон экземпляр класса GameInput
    public static GameInput Instance {get; private set;}

    // Система ввода для управления игроком
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    } 

    // Получить вектор движения игрока
    public Vector2 GetMovementVector(){
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }  
}
