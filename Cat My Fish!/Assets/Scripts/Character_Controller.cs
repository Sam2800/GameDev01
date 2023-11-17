using UnityEngine;

[RequireComponent(typeof(InputController))]

public class Character_Controller : MonoBehaviour
{
    [SerializeField] float _speed = 0f;
    //[SerializeField] float _rotationSpeed = 0f;

    InputController _inputController = null;

    void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 input = _inputController.MoveInput();
        transform.position += transform.forward * input.y * _speed * Time.deltaTime;
        //transform.Rotate(Vector3.up * input.x * _rotationSpeed * Time.deltaTime);
    }
}
