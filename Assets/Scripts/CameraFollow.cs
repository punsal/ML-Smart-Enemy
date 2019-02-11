using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + distance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + distance;
    }
}
