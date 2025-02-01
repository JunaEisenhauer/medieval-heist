using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintUI : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        GameUIManager.Instance().sprintUi = this;
        anim = GetComponent<Animator>();
    }

    public void Active()
    {
        anim.SetTrigger("Activate");
    }
}
