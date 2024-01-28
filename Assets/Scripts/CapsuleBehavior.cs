using System;
using UnityEngine;

public class CapsuleBehavior : MonoBehaviour {
    public Transform target;

    private float warningDistance = 3.0f;
    private string message = "";
    
    void Update() {
        Vector3 directionToTarget = target.position - transform.position;
        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        float dotProduct = Vector3.Dot(transform.forward, directionToTarget);
        
        if (distanceToTarget < warningDistance) {
            if (dotProduct > 0.2) { // padding of .2 for approximating right angles
                message = gameObject.name + ": Cube is in front";
            } else if (dotProduct < -0.2) {
                message = gameObject.name + ": Cube is behind";
            } else {
                message = gameObject.name + ": Cube is at a right angle";
            }
        } else {
            message = ""; // Clear message when the target is too far
        }
    }


    void OnGUI() {
        GUI.Button(new Rect(20, 20, 250, 40), message);
        }
    }


    

