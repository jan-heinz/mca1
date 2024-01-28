using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpinner : MonoBehaviour {
    public float rotationSpeed = 45.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // rotate around the y axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
