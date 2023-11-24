using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{ 
    public GameObject hook;
    public Transform cane;
    public float hookForce = 70f;
    public float hookDistance = 0.08f;
    bool holdingHook = false;
    private Rigidbody hookRB;
    //private SphereCollider hookSC;
    [SerializeField] private TrajectoryLine trajectoryLine;
    [SerializeField] private GameObject panelAdvice;
    private float hookMass = 10f;
    //public float changePerSecond;

    void Start()
    {
        hookRB = hook.GetComponent<Rigidbody>();
        //hookSC = hook.GetComponent<SphereCollider>();
        hookRB.useGravity = false;
        //hookSC.isTrigger = false;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    if (holdingHook == true)
        //    {
        //        hookForce += changePerSecond * Time.deltaTime;
        //    }
        //}
        if (Input.GetMouseButtonUp(1))
        {
            holdingHook = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            hookForce = 210f;
            Time.timeScale = 1f;
            panelAdvice.SetActive(false);
        }
    }

    void LateUpdate()
    {
        trajectoryLine.ShowTrajectoryLine(cane.position, cane.forward * hookForce / hookMass);
        if (holdingHook == true)
        {
            hook.transform.position = cane.position + cane.forward * hookDistance;
            if (Input.GetMouseButtonDown(1))
            {
                holdingHook = false;
                hookRB.useGravity = true;
                //hookSC.isTrigger = true;
                hookRB.AddForce(cane.forward * hookForce * 2, ForceMode.Impulse);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            hook.transform.position = cane.position;
            hookRB.useGravity = false;
            holdingHook = true;
            //hookSC.isTrigger = false;
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    hookSC.isTrigger = false;
        //    //hookRB.useGravity = false;
        //}
    }
}
