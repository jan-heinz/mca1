using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLerper : MonoBehaviour {
    public float speed = 4.0f;
    public Color initialColor;
    public Color endColor;

    Renderer renderer;
    
    // Start is called before the first frame update
    void Start() {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        // code from lecture notes
        float t = Mathf.Sin(Time.time * speed);
        t += 1;
        t /= 2;

        renderer.material.color = Color.Lerp(initialColor, endColor, t);
    }
}
