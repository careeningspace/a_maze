using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    float distance;
    Vector3 playerPrevPos, playerMoveDir;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

        distance = offset.magnitude;
        playerPrevPos = player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerMoveDir = player.transform.position - playerPrevPos;
        playerMoveDir.Normalize();

        transform.position = player.transform.position - playerMoveDir * distance;

        transform.LookAt(player.transform.position);

        playerPrevPos = player.transform.position;
    }
}
