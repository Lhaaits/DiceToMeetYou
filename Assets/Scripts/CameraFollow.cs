using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothness;
    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    public int speed = 300;
    bool isMoving = false;
    void Start()
    {  
        initalOffset = transform.position - targetObject.position;
    }

    void FixedUpdate()
    {
        cameraPosition = targetObject.position + initalOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness*Time.fixedDeltaTime);
    }

    void Update() {
        if (isMoving) {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            StartCoroutine(Roll(1));
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            StartCoroutine(Roll(-1));
        } 
    }

    IEnumerator Roll(int rotationDirection)
    {
        isMoving = true;
// 
// TODO add restart key/button
// scoring
/*
 * TODO
 * fix camera
 * add restart key/button
 * scoring
 * end goal
 * obstacles
 * menu
 * different dice
 */
        float remainingAngle = 90;
        Vector3 rotationCenter = targetObject.position;

        while (remainingAngle > 0) {
            float rotationAngle = rotationDirection * Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, Vector3.up, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        isMoving = false;
    }
}
