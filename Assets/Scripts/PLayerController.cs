using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
  
{

    public float moveSpeed;
    private Animator anim;
    Rigidbody2D myRigidbody;
    bool playerMoving;
    Vector2 lastMove;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position.normalized, Color.yellow);
        Moving();
        Action();
    }

    void Moving()
    {
        playerMoving = false;
      
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            playerMoving = true;
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),0f);

        }
        else
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }

       if (Input.GetAxisRaw("Vertical") != 0)
        {
            playerMoving = true;
            //  transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

        }
        else
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }

        anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("playerMoving", playerMoving);
        anim.SetFloat("lastMoveX", lastMove.x);
        anim.SetFloat("lastMoveY", lastMove.y);
    }


    void Action()
    {
        if(Input.GetKeyDown("e"))
        {
            lastMove.x = lastMove.x / 2;
            lastMove.y = lastMove.y / 2;
            Vector3 startDistance = new Vector3(transform.position.x + lastMove.x, transform.position.y + lastMove.y, transform.position.z);
          
            hit = Physics2D.Raycast(startDistance, lastMove);
            Debug.DrawRay(startDistance, lastMove, Color.red,100);
            Debug.Log(hit.collider);
        }
    }
}
