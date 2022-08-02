using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceTouch : MonoBehaviour
{
    public int goalNumber = 4;
    public bool hasCorrectSideTouched;

    private void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = "" + goalNumber;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entered collision");
        if (collision.collider.name == "side" + goalNumber)
        {
            hasCorrectSideTouched = true;
            GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        }
        else
        {
            hasCorrectSideTouched = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered trigger");
        if (other.name.Equals("side" + goalNumber))
        {
            hasCorrectSideTouched = true;
            GetComponent<Renderer>().material.color = new Color(0, 200, 0);
        }
        else
        {
            hasCorrectSideTouched = false;
            GetComponent<Renderer>().material.color = new Color(200, 0, 0);
        }
    }
}