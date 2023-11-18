using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Rigidbody rigid;
    public SubirBarca subirBarca;

    public float velocidad = 500;
    public float rotacion = 100;

    void Start()
    {
        subirBarca = FindObjectOfType<SubirBarca>();
    }

    void FixedUpdate()
    {
        if (subirBarca.onBoat == true)
        {
            float traslacion = Input.GetAxis("Vertical") * velocidad * 1000;
            //float rotation = Input.GetAxis("Mouse X") * rotacion * 1000;
            float rotation = Input.GetAxis("Horizontal") * rotacion * 1000;

            traslacion *= Time.deltaTime;
            rotation *= Time.deltaTime;

            rigid.AddRelativeForce(0, 0, traslacion);
            rigid.AddRelativeTorque(0, rotation, 0);
        }
    }
}
