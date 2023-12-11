using UnityEngine;
using UnityEngine.InputSystem;

public class InputCustom : MonoBehaviour, IInputCustom
{
    private Vector2 _movementInput;
    public void Move(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }
    
    public Vector2 GetMovementInput()
    {
        return _movementInput;
    }
}