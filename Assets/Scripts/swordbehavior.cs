using UnityEngine;
using System.Collections;

public class swordbehavior : MonoBehaviour
{
    bool fightmode;
    public GameObject player;
    public bool meleeAllowed;
    public float attackSpeed;

    public float hurtForce;
    public float hurtForceUp;
    public bool playerHurt;

    Animator anim;
    
    // Use this for initialization
    void Start()
    {
        fightmode = false;
        meleeAllowed = true;
        bool playerHurt = true;
        anim = GetComponent<Animator>();
        gameObject.layer = LayerMask.NameToLayer("NoHit");

    }

    // Update is called once per frame
    void Update()
    {
        //uses player script to check if invincibility frames are on. if so, causes the same flashing as the player to indicate iframes are on.
        if (player.GetComponent<playerMovement>().canHurt)
        {
            playerHurt = true;
        }

        if (player.GetComponent<playerMovement>().canHurt == false)
        {
            playerHurt = false;
        }

        //causes animation that moves sword forward to play on mouse1 press, and plays a sound. frequency of attack is restricted to 'attackSpeed' seconds.
        if (meleeAllowed == true && Input.GetMouseButtonDown(0))
        {
            AudioSource[] sources = GetComponents<AudioSource>();
            sources[1].Play();
            anim.SetTrigger("Slash");
            if (player.GetComponent<playerMovement>().leftFacing == false)
            {
                fightmode = true;
                gameObject.layer = LayerMask.NameToLayer("Player");
                transform.position = new Vector3(transform.position.x + .6f, transform.position.y, transform.position.z);
                Invoke("reset", attackSpeed);
            }

            if (player.GetComponent<playerMovement>().leftFacing == true)
            {
                fightmode = true;
                gameObject.layer = LayerMask.NameToLayer("Player");

                transform.position = new Vector3(transform.position.x - .6f, transform.position.y, transform.position.z);
                Invoke("reset", attackSpeed);
            }

            meleeAllowed = false;
            Invoke("meleeReset", attackSpeed);            
        }

        //iFrames flash
        
        Color mainColor = GetComponent<SpriteRenderer>().color;
        if (playerHurt == false)
        {
            mainColor.a = Mathf.Abs(Mathf.Sin(Time.time * 20f));
        }
        else
        {
            mainColor.a = 1f;
        }
        GetComponent<SpriteRenderer>().color = mainColor;
    }

    void reset()
    {
        fightmode = false;
        gameObject.layer = LayerMask.NameToLayer("NoHit");

        if (player.GetComponent<playerMovement>().leftFacing == false)
        {
            transform.position = new Vector3(transform.position.x - .6f, transform.position.y, transform.position.z);
        }

        if (player.GetComponent<playerMovement>().leftFacing == true)
        {
            transform.position = new Vector3(transform.position.x + .6f, transform.position.y, transform.position.z);
        }
    }

    void meleeReset()
    {
        meleeAllowed = true;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //plays sound on hit and decreases enemy health and causes knockback.
        AudioSource[] sources = GetComponents<AudioSource>();
        if (fightmode)
        {
            if (collision.gameObject.tag == "meleeEnemy")
            {
                //sources[0].Play();
                collision.gameObject.GetComponent<meleeEnemy>().decreaseHealth();
            }

            if (collision.gameObject.tag == "rangedEnemy")
            {
                //sources[0].Play();
                collision.gameObject.GetComponent<rangedEnemy>().decreaseHealth();
            }

            if (collision.gameObject.tag == "bossEnemy")
            {
                //sources[0].Play();
                collision.gameObject.GetComponent<bossEnemy>().decreaseHealth();
            }

            Rigidbody2D erb;
            erb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (collision.gameObject.transform.position.x > transform.position.x)
            {
                erb.AddForce(Vector2.right * hurtForce, ForceMode2D.Impulse);
                erb.AddForce(Vector2.up * hurtForceUp, ForceMode2D.Impulse);
            }

            if (collision.gameObject.transform.position.x < transform.position.x)
            {
                erb.AddForce(Vector2.left * hurtForce, ForceMode2D.Impulse);
                erb.AddForce(Vector2.up * hurtForceUp, ForceMode2D.Impulse);
            }
        }
    }

}
