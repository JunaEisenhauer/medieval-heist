using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float mapSize = 50f;
    public float distanceToPlayer = 20f;

    public virtual void SpawnEnemy()
    {
        NavMeshHit hit;
        float distance;
        do
        {
            Vector3 randomPosition = Random.insideUnitSphere * mapSize;
            NavMesh.SamplePosition(randomPosition, out hit, mapSize, 1);

            distance = Vector3.Distance(GameManager.Instance().player.transform.position, hit.position);
        } while (distance < distanceToPlayer);

        GameObject newEnemy = Instantiate(enemy, transform);
        newEnemy.transform.position = hit.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, mapSize);
    }
}
