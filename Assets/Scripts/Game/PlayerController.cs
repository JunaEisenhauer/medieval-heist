using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100f;
    public float sprintMultiplier = 1.5f;

    public Animator animator;
    public Animator sprintAnimator;

    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance().isMapShown)
        {
            rBody.velocity = Vector2.zero;
            return;
        }

        bool sprintActive = false;
        if (sprintAnimator.GetCurrentAnimatorStateInfo(0).IsName("SprintUsable") && Input.GetAxis("Sprint") > 0f)
        {
            GameUIManager.Instance().sprintUi.Active();
            sprintActive = true;
        }
        else if(sprintAnimator.GetCurrentAnimatorStateInfo(0).IsName("SprintActive"))
        {
            sprintActive = true;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        Vector3 movement = direction * speed * Time.deltaTime;
        if (sprintActive) movement *= sprintMultiplier;
        rBody.velocity = movement;

        animator.SetBool("up", vertical > 0);
        animator.SetBool("down", vertical < 0);
        animator.SetBool("right", horizontal > 0);
        animator.SetBool("left", horizontal < 0);
    }
}
