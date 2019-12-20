using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpawnEnemy : MonoBehaviour
{
    public GameObject spawnPoint;
    [SerializeField] GameObject player;
    public GameObject prefabToSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject==player)
        {
            GameObject enemy = Instantiate(prefabToSpawn);
            enemy.transform.position = spawnPoint.transform.position;
            gameObject.SetActive(false);
        }
    }

}