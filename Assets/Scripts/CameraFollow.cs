using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTrans; //get reference to player's transform
    private Vector3 tempPos; //temporary pos of Camera

    [SerializeField]
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position; //curr camera's pos
        tempPos.x = playerTrans.position.x; 

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        transform.position = tempPos;
    }
}
