using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSens;

    private Transform parent;

    // Start is called before the first frame update
    private void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;  
    }

    // Update is called once per frame
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        parent.Rotate(Vector3.up, mousex);
    } 
}
