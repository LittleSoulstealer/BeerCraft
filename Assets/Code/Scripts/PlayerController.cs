using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : Character

{
   

    public HitPoints hitPoints;
    public GameObject magicBulletPrefab;
    public float moveSpeed;
    private Animator anim;
    Rigidbody2D myRigidbody;
    bool playerMoving;
    Vector2 lastMove;
    //RaycastHit2D hit;

    ActionCollider actionCollider;
    GameObject acgo;


    void Awake()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        actionCollider = GetComponentInChildren<ActionCollider>();
        acgo = actionCollider.gameObject;



    }
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());
            hitPoints.value = hitPoints.value - damage;
            if (hitPoints.value <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
    void Update()
    {
        Moving();
        Action();
        CastSpell();
    }

    void Moving()
    {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            playerMoving = true;

            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            actionCollider.gameObject.transform.position = transform.position + (Vector3)lastMove;
        }
        else
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            playerMoving = true;

            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            actionCollider.gameObject.transform.position = transform.position + (Vector3)lastMove;

        }
        else
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);

        anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("playerMoving", playerMoving);
        anim.SetFloat("lastMoveX", lastMove.x);
        anim.SetFloat("lastMoveY", lastMove.y);

    }


    void Action()
    {

        if (Input.GetKeyDown("e"))
        {
            Debug.Log("e");

           /* if (actionCollider.pointingOnPlantGround == true)
            {
                

            }
            if (actionCollider.collidingGO != null)
            {
                Debug.Log(actionCollider.collidingGO);
                PlayerInteraction interaction = actionCollider.collidingGO.GetComponent<PlayerInteraction>();
                if (interaction != null)
                {
                    interaction.Trigger();
                    if (actionCollider.collidingGO.GetComponent<PickableFruit>())
                    {
                        actionCollider.collidingGO = null;
                    }
                    actionCollider.collidingGO = null;
                }*/
            }




        }

    public override void ResetCharacter()
    {
        throw new System.NotImplementedException();
    }

    private void CastSpell()
    {
        {
            if (Input.GetKeyDown("space"))
            {
                GameObject magicBulletObject = Instantiate(magicBulletPrefab);
                magicBulletObject.transform.position = transform.position + (Vector3)(lastMove)+Vector3.up;
                
            }
        }

    }
}
