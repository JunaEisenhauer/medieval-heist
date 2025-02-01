using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMoneyCollector : MonoBehaviour
{
    public List<GameObject> safes;
    public AudioClip moneyCollectClip;
    public AudioClip moneyDeliveredClip;

    public Tutorial tutorial;

    private bool holding;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Money>() != null && !holding)
        {
            holding = true;
            GameUIManager.Instance().moneyUi.Collect();
            Destroy(collision.gameObject);

            GameManager.Instance().PlaySound(moneyCollectClip);

            GameObject safe = safes[0];
            safe.SetActive(true);

            tutorial.MoneyCollected();
        }
        else if (collision.GetComponent<Safe>() != null && holding)
        {
            holding = false;
            GameUIManager.Instance().moneyUi.Deliver();

            GameManager.Instance().PlaySound(moneyDeliveredClip);
            GameManager.Instance().MoneyDelivered();

            Destroy(collision.gameObject);
            safes.Remove(collision.gameObject);

            tutorial.MoneyDelivered();
        }
    }
}
