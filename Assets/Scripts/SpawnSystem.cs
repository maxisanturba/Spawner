using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject singleEnemy;
    public int quantity;
    public float timeToSpawn;

    public float minTime;
    public float maxTime;

    public RandomEnemies newEnemy;

    public enum Selector { SpawnByFixedTime, SpawnByRandomTime, SpawnRandomEnemies};
    public Selector selector;

    private void Start()
    {
        switch (selector)
        {
            case Selector.SpawnByFixedTime:
                StartCoroutine(SpawnByTime(timeToSpawn));
                break;
            case Selector.SpawnByRandomTime:
                StartCoroutine(SpawnByTime(minTime, maxTime));
                break;
            case Selector.SpawnRandomEnemies:
                StartCoroutine(SpawnByTime(minTime, maxTime, newEnemy));
                break;
            default:
                break;
        }
    }

    IEnumerator SpawnByTime(float time)
    {
        Debug.Log("Enemy spawned in: " + timeToSpawn + "secs.");
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < quantity)
        {
            yield return new WaitForSeconds(time);

            GameObject spawnThis;
            spawnThis = Instantiate(singleEnemy, transform.position, Quaternion.identity);
            spawnThis.AddComponent<Rigidbody>();

            StartCoroutine(SpawnByTime(timeToSpawn));
        }
        else
        {
            Debug.Log("Limit of enemies reached!");
            yield break;
        }
    }

    IEnumerator SpawnByTime(float timeA, float timeB)
    {
        float randomTime = Random.Range(timeA, timeB);
        Debug.Log("Enemy spawned in: " + randomTime + "secs.");
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < quantity)
        {
            yield return new WaitForSeconds(randomTime);

            GameObject spawnThis;
            spawnThis = Instantiate(singleEnemy, transform.position, Quaternion.identity);
            spawnThis.AddComponent<Rigidbody>();

            StartCoroutine(SpawnByTime(timeA, timeB));
        }
        else
        {
            Debug.Log("Limit of enemies reached!");
            yield break;
        }
    }
    IEnumerator SpawnByTime(float timeA, float timeB, RandomEnemies randomEnemies)
    {
        float randomTime = Random.Range(timeA, timeB);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < quantity)
        {
            for (int i = 0; i < randomEnemies.enemies.Length; i++)
            {
                if (randomEnemies.enemies[i].chances >= Random.Range(0f, 1f))
                {
                    yield return new WaitForSeconds(randomTime);
                    GameObject spawnThis = Instantiate(singleEnemy, transform.position, Quaternion.identity);
                    spawnThis.name = randomEnemies.enemies[i].prefabName;
                    spawnThis.AddComponent<Rigidbody>();
                    spawnThis.GetComponent<Renderer>().material.color = randomEnemies.enemies[i].randomColor;

                }
                else Debug.Log("Chances to spawn too low");
            }
            
            StartCoroutine(SpawnByTime(minTime, maxTime, newEnemy));
        }
        else
        {
            Debug.Log("Limit of enemies reached!");
            yield break;
        }

    }
}


