using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRender : MonoBehaviour
{
    public GameObject hook;
    private TrailRenderer hookTR;
    //public CameraController _cameraController;

    void Start()
    {
        //_cameraController = FindObjectOfType<CameraController>();
        hookTR = hook.GetComponent<TrailRenderer>();
        hookTR.emitting = false;
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if(otherObj.gameObject.tag == "Ground")
        {
            hookTR.emitting = true;
            //_cameraController._mouseSensitivity = 180f;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hookTR.emitting = false;
        }
    }
}
