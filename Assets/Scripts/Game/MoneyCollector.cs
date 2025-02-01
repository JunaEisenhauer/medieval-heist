using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    public List<GameObject> safes;
    public AudioClip moneyCollectClip;
    public AudioClip moneyDeliveredClip;

    public GameObject alreadyHolding;

    private bool holding;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Money>() != null && !holding)
        {
            holding = true;
            GameUIManager.Instance().moneyUi.Collect();
            Destroy(collision.gameObject);

            GameManager.Instance().PlaySound(moneyCollectClip);

            GameObject safe = safes[Random.Range(0, safes.Count)];
            safe.SetActive(true);
        }
        else if (collision.GetComponent<Money>() && holding)
        {
            alreadyHolding.SetActive(true);
        }
        else if (collision.GetComponent<Safe>() != null && holding)
        {
            holding = false;
            GameUIManager.Instance().moneyUi.Deliver();

            GameManager.Instance().enemySpawner.SpawnEnemy();
            GameManager.Instance().PlaySound(moneyDeliveredClip);
            GameManager.Instance().MoneyDelivered();

            Destroy(collision.gameObject);
            safes.Remove(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<Money>() != null && alreadyHolding.activeSelf)
        {
            alreadyHolding.SetActive(false);
        }
    }
}
