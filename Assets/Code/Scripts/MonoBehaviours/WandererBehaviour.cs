using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]


public class WandererBehaviour : MonoBehaviour
{

    public float pursuitSpeed;
    public float wandererSpeed;
    float currentSpeed;

    public float directionChangeInterval;
    public bool followPlayer;
    Coroutine moveCoroutine;
    Rigidbody2D rb2d;
     Animator animator;
    Transform targetTransform = null;
    Vector3 endPosition;
    float currentAngle = 0;

    CircleCollider2D circleCollider;


    private void Start()
    {
         animator = GetComponentInParent<Animator>();
        currentSpeed = wandererSpeed;
        rb2d = transform.GetComponentInParent<Rigidbody2D>();
        StartCoroutine(WandererCoroutine());
        circleCollider = GetComponent<CircleCollider2D>();


    }

    void Update()
    {

        Debug.DrawLine(rb2d.position, endPosition, Color.red);
     
    }
    private void FixedUpdate()
    {
     
        if (rb2d.velocity!=Vector2.zero && Vector3.Distance(transform.position, endPosition )<=0.1)
        {
            
            rb2d.velocity = Vector2.zero;
        }
    }

    private void OnDrawGizmos()
    {
        if (circleCollider != null)
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
    }
    public IEnumerator WandererCoroutine()
    {
        while (true)
        {
            ChooseNewEndpoint();
            Move();
            yield return new WaitForSeconds(directionChangeInterval);
        }

    }

    void ChooseNewEndpoint()
    {
        currentAngle += UnityEngine.Random.Range(0, 360);
        currentAngle = Mathf.Repeat(currentAngle, 360);
        endPosition += Vector3FromAngle(currentAngle);
    }

    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        float imputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(inputAngleDegrees), Mathf.Sin(imputAngleRadians), 0);
    }


     void Move()
    {
        if (targetTransform != null)
        {
            endPosition = targetTransform.position;
        }
        
        Vector2 direction = new Vector2(endPosition.x - rb2d.transform.position.x, endPosition.y - rb2d.transform.position.y).normalized;
        rb2d.velocity = (direction * currentSpeed);
      

         animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            currentSpeed = pursuitSpeed;
            targetTransform = collision.gameObject.transform;
            Move();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            currentSpeed = wandererSpeed;
            targetTransform = null;
            rb2d.velocity = Vector2.zero;
        }

    }
}
