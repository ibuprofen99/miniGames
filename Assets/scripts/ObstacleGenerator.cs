using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject floorObstacle;
    public GameObject ceilingObstacle;
    Rigidbody rb;

    int life = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floors" || other.gameObject.tag == "Ceiling")
        {
            life -= 1;
            // Play sound?
            Debug.Log("You got hit");
        }
    }
}

