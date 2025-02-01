using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageHeight : MonoBehaviour
{
    public float heightMultiplier = 0.001f;

    private void FixedUpdate()
    {
        var deltaHeight = -transform.position.z * heightMultiplier;
        transform.position = new Vector3(transform.position.x, deltaHeight + 2, transform.position.z);
    }
}
