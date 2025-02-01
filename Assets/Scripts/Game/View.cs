using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public float viewDistance = 100f;
    public float rotationSpeed = 10f;
    public LayerMask layerMask;

    public Animator radarAnimator;
    public AudioClip inSightClip;

    private bool inSight;

    public void UpdateDirection(Vector3 direction)
    {
        Quaternion lookDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, rotationSpeed * Time.deltaTime);
    }

    public bool IsPlayerInSight(Vector3 position)
    {
        bool result = false;

        if (inSight)
        {
            GameObject player = GameManager.Instance().player;
            Vector3 rayDirection = player.transform.position - position;
            RaycastHit hit;
            Physics.Raycast(position, rayDirection, out hit);
            if (hit.transform == null) return false;
            result = hit.transform.position == player.transform.position;
        }

        radarAnimator.SetBool("sight", result);
        return result;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameManager.Instance().player;
        if (other.gameObject == player)
        {
            inSight = true;
            GameManager.Instance().PlaySound(inSightClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject player = GameManager.Instance().player;
        if (other.gameObject == player)
        {
            inSight = false;
        }
    }
}
