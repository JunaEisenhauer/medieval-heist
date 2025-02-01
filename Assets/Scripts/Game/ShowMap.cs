using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMap : MonoBehaviour
{
    public AudioClip zoomClip;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetAxis("Map") > 0f)
        {
            if (cam.enabled) return;
            cam.enabled = true;
            GameManager.Instance().isMapShown = true;

            GameManager.Instance().PlaySound(zoomClip);
        }
        else if (cam.enabled)
        {
            cam.enabled = false;
            GameManager.Instance().isMapShown = false;
        }
    }
}
