
using System.Collections;
using UnityEngine;


public class Enemy : Character
{
    float hitPoints;
    public int damageStrenght;
    Coroutine damageCoroutine;
   [SerializeField] Healing heartDropPrefab;
    Healing heartDrop;
    public Score score;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if(damageCoroutine==null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrenght, 1.0f));

            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(damageCoroutine!=null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
       while(true)
        {
            StartCoroutine(FlickerCharacter());
            hitPoints = hitPoints - damage;
            if(hitPoints<=float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if(interval>float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public override void ResetCharacter()
    {
        hitPoints = startingHitPoints;
    }
    private void OnEnable()
    {
        ResetCharacter();
    }

    public override void KillCharacter()
    {
        DropLoot();
        score.value += 5;
        base.KillCharacter();
    }

    void DropLoot()
    {
        if (Random.Range(0f,100f)<=25)
        {
            heartDrop =Instantiate(heartDropPrefab);
            heartDrop.transform.position = transform.position;
        }
    }
}
