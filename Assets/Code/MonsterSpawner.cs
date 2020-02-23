using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
   public Enemy monsterPrefeab;
    Enemy monster;
    BoxCollider2D area;
    Vector3 spawnPos;
    [SerializeField] GameObject player;
    public Timer timer;
    float intervalBetweenMonsters;
    public float  startingIntervalBetweenMonsters;
    public List<Enemy> livingMonsters;
    static public List<Healing> hearts = new List<Healing>();



    private void Start()
    {
        livingMonsters = new List<Enemy>();
        spawnPos = new Vector2();
        area = GetComponent<BoxCollider2D>();
        ResetInterval();
        StartCoroutine(SpawnMonster());
        StartCoroutine(IntervalDecrease());
    }
    
    public void ResetInterval()
    {
        intervalBetweenMonsters = startingIntervalBetweenMonsters;
    }
    IEnumerator SpawnMonster()
    {
       while(true)
        {
            SpawnPosition();
           monster= Instantiate(monsterPrefeab);
            monster.transform.position = spawnPos;
            livingMonsters.Add(monster);
           
            yield return new WaitForSeconds(intervalBetweenMonsters);
        }        
    }

    IEnumerator IntervalDecrease()
    {
        while(intervalBetweenMonsters>0.5f)
        {
            intervalBetweenMonsters = intervalBetweenMonsters * 0.9f;
            yield return new WaitForSeconds(15);
        }
    } 
   Vector3 SpawnPosition()
    {
        spawnPos.x = Random.Range(area.offset.x-area.size.x/2f, area.offset.x + area.size.x / 2f);
        spawnPos.y = Random.Range(area.offset.y - area.size.y / 2f, area.offset.y + area.size.y / 2f);
        spawnPos += transform.position;
        if(Vector3.Distance(player.transform.position,spawnPos) < 10f)
        {
            spawnPos.x = Random.Range(area.offset.x - area.size.x / 2f, area.offset.x + area.size.x / 2f);
            spawnPos.y = Random.Range(area.offset.y - area.size.y / 2f, area.offset.y + area.size.y / 2f);
            spawnPos += transform.position;
        }
        return spawnPos;
       
    }

    public void KillAllMonsters()
    {
        foreach(Enemy monster in livingMonsters)
        {
            if(monster!=null)
            { Destroy(monster.gameObject); }

        }
        livingMonsters.Clear();
    }
    public void DestroyLoot()
    {
        foreach (var loot  in hearts)
        {
            if (loot != null)
            { Destroy(loot.gameObject); }

        }
    
    }
}
