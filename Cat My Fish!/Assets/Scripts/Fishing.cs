using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject Carp;

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "hook")
        {
            Destroy(gameObject);
            ScoreManager.instance.AddPoint();
        }
    }
}
