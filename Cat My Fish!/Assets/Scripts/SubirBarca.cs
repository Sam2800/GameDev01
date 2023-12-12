using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirBarca : MonoBehaviour
{
    [SerializeField] private GameObject panelAviso;
    public Behaviour scripController;
    public GameObject Activation;
    public GameObject canvas;
    public GameObject sCanvas;
    public Rigidbody rigid;

    public float distanceInteraction = 12f;
    public bool onBoat = false;
    public bool offBoat = false;
    public int anclado = 0;

    //CharacterController controller;
    GameObject boat;
    GameObject dock;
    GameObject hook;

    bool onRange;
    float distance;
    GameObject target;
    GameObject targets;

    public Animator animator;
    public string variableBote;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
        boat = GameObject.FindGameObjectWithTag("barca");
        dock = GameObject.FindGameObjectWithTag("muelle");
        hook = GameObject.FindGameObjectWithTag("hook");
        target = GameObject.Find("Target");
        targets = GameObject.Find("Targets");
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, boat.transform.position);
        distance = Vector3.Distance(transform.position, dock.transform.position);

        if (distance <= distanceInteraction)
        {
            onRange = true;
        }
        else
        {
            onRange = false;
        }

        if (onRange && !onBoat)
        {
            canvas.SetActive(true);
        }
        if (!onRange || onBoat)
        {
            canvas.SetActive(false);
        }

        if (distance <= distanceInteraction)
        {
            onRange = true;
        }
        else
        {
            onRange = false;
        }

        if (onRange && onBoat)
        {
            sCanvas.SetActive(true);
        }
        if (!onRange || !onBoat)
        {
            sCanvas.SetActive(false);
        }

        if (onBoat)
        {
            scripController.enabled = false;
            //controller.enabled = false;

            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;

            gameObject.transform.SetParent(target.transform);
            hook.transform.SetParent(target.transform);

            animator.SetBool(variableBote, true);
        }
        else
        {
            scripController.enabled = true;
            //controller.enabled = true;

            gameObject.transform.SetParent(null);
            hook.transform.SetParent(gameObject.transform);

            animator.SetBool(variableBote, false);
        }

        if (offBoat)
        {
            transform.position = targets.transform.position;
            transform.rotation = targets.transform.rotation;
        }

        if (onRange && !onBoat && Input.GetKeyUp(KeyCode.F))
        {
            onBoat = true;
        }
        if (onBoat && Input.GetKeyDown(KeyCode.E))
        {
            offBoat = true;
        }
        if (onBoat && Input.GetKeyUp(KeyCode.E))
        {
            onBoat = false;
            offBoat = false;
        }

        if(onBoat == true && anclado == 0)
        {
            panelAviso.SetActive(true);
        }
        else
        {
            panelAviso.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onBoat == true)
            {
                Constraints();
                anclado++;
            }
            if (anclado == 2)
            {
                Constraintsed();
                anclado = 0;
            }
        }
    }

    void Constraints()
    {
        rigid.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    void Constraintsed()
    {
        rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
