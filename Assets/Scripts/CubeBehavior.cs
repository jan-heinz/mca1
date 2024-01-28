using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine;

public class CubeBehavior : MonoBehaviour {
    public float speed = 5.0f;
    public float minDistance = 1.0f;
    
    List<GameObject> players;
    GameObject currentTarget;

    private bool shouldMove = false;
   
    
    // Start is called before the first frame update
    void Start() {
        players = GameObject.FindGameObjectsWithTag("Player").ToList(); // changed to a list to allow dynamic sizing
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            shouldMove = !shouldMove; // inverts boolean (allows for pausing for extra functionality)
            selectPlayer(); // selects a random player from the list to move towards first
        }

        if (shouldMove && currentTarget != null) { // space has been pressed and players still present to move towards
            // current distance from cube to selected player
            float distanceToPlayer = Vector3.Distance(transform.position, currentTarget.transform.position);

            if (distanceToPlayer <= minDistance) {
                players.Remove(currentTarget); // remove destroyed target from list so we can't re access it
                Destroy(currentTarget); // destroy it in the scene
                selectPlayer(); // select new target
            } else { // not close enough to destroy, keep moving towards it
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
            }
        }
    }

    

    // select a random player from the list of all available players
    private void selectPlayer() {
        if (players.Count > 0) {
            currentTarget = players[Random.Range(0, players.Count)]; // randomly selects an index from the players list
        }
    }
}
