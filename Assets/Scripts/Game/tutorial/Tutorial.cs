using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject wasd;
    public GameObject findCoins;
    public GameObject deliverCoin;
    public GameObject zoom;
    public GameObject sprint;


    public GameObject secondMoney;
    public Enemy[] enemies;
    public Vector3 enemyDestination;

    public void FixedUpdate()
    {
        if (wasd.activeSelf)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (horizontal != 0 || vertical != 0)
            {
                wasd.SetActive(false);
                findCoins.SetActive(true);
            }
        }

        if (zoom.activeSelf && Input.GetAxis("Map") > 0f)
        {
            zoom.SetActive(false);
            Enemy enemy = GetFarestEnemy();
            enemy.gameObject.SetActive(true);
            enemy.SetNextDestionation(enemyDestination);
            sprint.SetActive(true);
        }

        if (sprint.activeSelf && Input.GetAxis("Sprint") > 0f)
        {
            sprint.SetActive(false);
        }
    }

    public void MoneyCollected()
    {
        if (findCoins.activeSelf)
        {
            findCoins.SetActive(false);
            deliverCoin.SetActive(true);
        }
    }

    public void MoneyDelivered()
    {
        if (deliverCoin.activeSelf)
        {
            deliverCoin.SetActive(false);
            secondMoney.SetActive(true);
            zoom.SetActive(true);
        }
    }

    private Enemy GetFarestEnemy()
    {
        Vector3 playerPos = GameManager.Instance().player.transform.position;
        Enemy enemy = enemies[0];
        float enemyDistance = (enemy.transform.position - playerPos).sqrMagnitude;
        for (var i = 1; i < enemies.Length; i++)
        {
            Enemy currentEnemy = enemies[i];
            float currentDistance = (currentEnemy.transform.position - playerPos).sqrMagnitude;
            if (enemyDistance < currentDistance)
            {
                enemy = currentEnemy;
                enemyDistance = currentDistance;
            }
        }
        return enemy;
    }
}
