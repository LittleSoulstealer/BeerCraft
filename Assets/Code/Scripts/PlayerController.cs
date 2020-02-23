using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Cinemachine;

public class PlayerController : Character

{


    public HitPoints hitPoints;
    public Stamina stamina;
    public float maxStamina;
    float startingStamina;
    public float staminaLoss;
    public float staminaGain;
    public GameObject magicBulletPrefab;
    public float moveSpeed;
    public float walkingSpeed;
    public float runningSpeed;
   public HealthMeter healthMeterPrefab;
   public StaminaBar StaminaBarPrefab;
    public bool isKilled;



     HealthMeter healthMeter;
    StaminaBar staminaBar;
    private Animator anim;
    Rigidbody2D myRigidbody;
    bool playerMoving;
    Vector2 lastMove;
    public GameObject magicBulletSpawnPoint;
    //RaycastHit2D hit;
    List<GameObject> bulletObjectPool;


    ActionCollider actionCollider;
    GameObject acgo;


    void Awake()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        actionCollider = GetComponentInChildren<ActionCollider>();
        acgo = actionCollider.gameObject;
    
        startingStamina = maxStamina;

        bulletObjectPool = new List<GameObject>();
        FillObjectPool();
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


    private void Start()
    {
    }
    void Update()
    {
        Running();
        Moving();
        Action();
        CastSpell();
       

    }
void Running()
    {
        if(stamina.value>=Mathf.Epsilon && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            moveSpeed = runningSpeed;
            stamina.value -= staminaLoss * Time.deltaTime;
        }
        else
        {
            moveSpeed = walkingSpeed;
            if(stamina.value<=maxStamina)
            {
                stamina.value += staminaGain * Time.deltaTime;
            }
         
        }
    }
    void FillObjectPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject magicBulletObject = Instantiate(magicBulletPrefab);
            magicBulletObject.SetActive(false);
            bulletObjectPool.Add(magicBulletObject);
        }
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

        SetMagicBulletSpawPointTransformPosition();

        anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("playerMoving", playerMoving);
        anim.SetFloat("lastMoveX", lastMove.x);
        anim.SetFloat("lastMoveY", lastMove.y);

    }

    private void SetMagicBulletSpawPointTransformPosition()
    {
        if (lastMove.y != 0)
        {
            magicBulletSpawnPoint.transform.localPosition = new Vector3(0, 0.7f, 0);
        }
        else
        {
            magicBulletSpawnPoint.transform.localPosition = new Vector3(0.7f * lastMove.x, 0.7f, 0);
        }
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
       
        healthMeter = Instantiate(healthMeterPrefab);
        staminaBar = Instantiate(StaminaBarPrefab);

        hitPoints.value = startingHitPoints;
        stamina.value = startingStamina;
        healthMeter.character = this;
        staminaBar.character = this;
       
    }
    public override void KillCharacter()
    {
        Destroy(healthMeter.gameObject);
        Destroy(staminaBar.gameObject);
        isKilled = true;
        base.KillCharacter();
        
        
    }

    private void CastSpell()
    {
        {
            if (Input.GetKeyDown("space"))
            {
                GameObject bullet = RetrieveBulletFromPool();
                bullet.SetActive(true);
                bullet.transform.position = magicBulletSpawnPoint.transform.position;
                bullet.GetComponent<MagicBullet>().Cast(lastMove);
            }
        }

    }

    GameObject RetrieveBulletFromPool()
    {
        for (int i = 0; i < bulletObjectPool.Count; i++)
        {
            if(!bulletObjectPool[i].activeInHierarchy)
            { return bulletObjectPool[i]; }
        }
        bulletObjectPool.Add(Instantiate(magicBulletPrefab));
        return bulletObjectPool[bulletObjectPool.Count - 1];
    }
}
