using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPos = transform.position;
        Vector3 move = player.transform.position + new Vector3(12, 4, -3);
        transform.position = Vector3.Slerp(oldPos, move, Time.deltaTime);
    }
}
