using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform camerePosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = camerePosition.position;   
    }
}
