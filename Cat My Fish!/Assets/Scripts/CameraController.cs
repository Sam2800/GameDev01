using UnityEngine;

[RequireComponent(typeof(InputController))]

public class CameraController : MonoBehaviour
{
    [SerializeField] public float _mouseSensitivity = 0f;
    [SerializeField] Transform _cameraAnchor = null;
    InputController _inputController = null;

    void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    void Update()
    {
        MouseCamera();
        //if (Input.GetMouseButtonDown(1))
        //{
        //    _mouseSensitivity = 0f;
        //}
    }

    void MouseCamera()
    {
        Vector3 input = _inputController.MouseInput();
        transform.Rotate(Vector3.up * input.x * _mouseSensitivity * Time.deltaTime);

        Vector3 angle = _cameraAnchor.eulerAngles;
        angle.x -= input.y * _mouseSensitivity * Time.deltaTime;
        angle.x = Mathf.Clamp(angle.x, 0, 50);
        _cameraAnchor.eulerAngles = angle;
    }
}
