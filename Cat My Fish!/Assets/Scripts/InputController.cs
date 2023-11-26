using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector3 MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector3(x, y);
    }

    public Vector3 MouseInput()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        return new Vector3(x, y);
    }
}
