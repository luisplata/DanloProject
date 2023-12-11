using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Player : MonoBehaviour
{
    [SerializeField, InterfaceType(typeof(IInputCustom))]
    private Object _input;
    private IInputCustom InputCustom => _input as IInputCustom;
    
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Vector3 limitsToMoveUp, limitsToMoveDown;

    private void Reset()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var movementInput = InputCustom.GetMovementInput();
        var movement = new Vector3(movementInput.x, 0, movementInput.y);
        rigidbody.velocity = movement * speed;
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, limitsToMoveDown.x, limitsToMoveUp.x),
            0,
            Mathf.Clamp(rigidbody.position.z, limitsToMoveDown.z, limitsToMoveUp.z)
        );
    }
}