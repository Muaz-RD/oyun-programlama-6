using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager_sc : MonoBehaviour
{

    bool stopSpawing = false;

    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject EnemyContainer;

    IEnumerator SpawnEnemyRoutine()
    {

        while (stopSpawing == false)
        {
            Vector3 position = new Vector3(Random.Range(-10f, 10f), 4.36f, 0);
            GameObject new_enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            new_enemy.transform.parent = EnemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpwanBonusRoutine()
    {
        while (stopSpawing == false)
        {
            Vector3 position = new Vector3(Random.Range(-10f, 10f), 4.36f, 0);
            Instantiate(enemyPrefab, position, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }

    }

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpwanBonusRoutine());

    }

    public void OnPlayerDeath()
    {
        stopSpawing = true;
    }


}
