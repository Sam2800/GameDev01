using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float profundidad = 0.5f;
    public float desplazamiento = 3f;
    public Rigidbody rigid;

    private void FixedUpdate()
    {
        if(transform.position.y < 0f)
        {
            float multiplicador = Mathf.Clamp01(-transform.position.y / profundidad) * desplazamiento;
            rigid.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * multiplicador, 0f), ForceMode.Acceleration);
        }
    }
}
