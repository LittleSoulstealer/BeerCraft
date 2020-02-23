using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    public int damageInflicted;
    Vector2 direction;
    public int speed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Cast(Vector2 dir)
    {
        rb.velocity = dir * speed;
        StartCoroutine("Deactivate");
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag =="Enemy")
        {
            Enemy enemy =collision.gameObject.GetComponent<Enemy>();
            if(gameObject.activeSelf)
                {
                StartCoroutine(enemy.DamageCharacter(damageInflicted, 0.0f));
                gameObject.SetActive(false);
            }
            
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
