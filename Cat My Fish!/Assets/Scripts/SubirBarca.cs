using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirBarca : MonoBehaviour
{
    public Behaviour scripController;
    public GameObject Activation;
    public GameObject canvas;
    public GameObject sCanvas;

    public float distanceInteraction = 12f;
    public bool onBoat = false;
    public bool offBoat = false;

    //CharacterController controller;
    GameObject boat;
    GameObject dock;

    bool onRange;
    float distance;
    GameObject target;
    GameObject targets;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
        boat = GameObject.FindGameObjectWithTag("barca");
        dock = GameObject.FindGameObjectWithTag("muelle");
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
        }
        else
        {
            scripController.enabled = true;
            //controller.enabled = true;

            gameObject.transform.SetParent(null);
        }

        if (offBoat)
        {
            transform.position = targets.transform.position;
            transform.rotation = targets.transform.rotation;
        }

        if (onRange && !onBoat && Input.GetKeyUp(KeyCode.B))
        {
            onBoat = true;
        }
        if (onBoat && Input.GetKeyDown(KeyCode.N))
        {
            offBoat = true;
        }
        if (onBoat && Input.GetKeyUp(KeyCode.N))
        {
            onBoat = false;
            offBoat = false;
        }
    }
}
