using UnityEngine;

[RequireComponent(typeof(InputController))]

public class Character_Controller : MonoBehaviour
{
    [SerializeField] float _speed = 0f;
    //[SerializeField] float _rotationSpeed = 0f;

    InputController _inputController = null;
    public Animator animator;

    public string variableMovimiento;

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
        Vector3 input = _inputController.MoveInput();
        transform.position += transform.forward * input.y * _speed * Time.deltaTime;
        animator.SetFloat(variableMovimiento, Mathf.Abs(input.y) + Mathf.Abs(input.x));
        //transform.Rotate(Vector3.up * input.x * _rotationSpeed * Time.deltaTime);
    }
}
