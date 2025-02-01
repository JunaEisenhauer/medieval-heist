using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public GameObject[] money;

    private int current = 0;

    private void Start()
    {
        GameUIManager.Instance().moneyUi = this;
    }

    public void Collect()
    {
        money[current].GetComponent<Animator>().SetBool("Collected", true);
    }

    public void Deliver()
    {
        money[current].GetComponent<Animator>().SetBool("Delivered", true);
        current++;
    }
}
