using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlassFall : MonoBehaviour
{
    [SerializeField] private bool playerDetected;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player is on the plane!");
            playerDetected = true;
            Destroy(gameObject);

        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
