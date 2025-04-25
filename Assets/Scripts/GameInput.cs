using UnityEngine;

public class GameInput : MonoBehaviour
{
<<<<<<< Updated upstream
    public static GameInput Instance {get; private set;}

=======
    // Синглтон экземпляр класса GameInput
    public static GameInput Instance {get; private set;}

    // Система ввода для управления игроком
>>>>>>> Stashed changes
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    } 

<<<<<<< Updated upstream

=======
    // Получить вектор движения игрока
>>>>>>> Stashed changes
    public Vector2 GetMovementVector(){
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }  
}
