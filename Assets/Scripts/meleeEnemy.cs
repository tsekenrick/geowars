using UnityEngine;
using System.Collections;

public class meleeEnemy : MonoBehaviour {
    Vector3 homePos;
    public bool goRight;
    Rigidbody2D rb;

    //as usual, floats dictate gameplay variables
    public GameObject player;
    public GameObject sword;
    public GameObject deathParticles;
    public float health;
    public float moveSpeed = 1f;
    public Vector2 distBetween;
    public Vector2 aggroRangeUpper;
    public Vector2 aggroRangeLower;
    public float aggroMoveSpeed;
    public float jumpTimer;
    public bool canJump;
    public float deaggroRange;
    Animator anim;
    // Use this for initialization
    void Start () {
        homePos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //scoutmode is just the standard, walk back and forth behavior
        Invoke("scoutMode", 0f);

        //die at health 0
        if (health <= 0)
        {
            //anim.SetTrigger ("dead");
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        //distbetween is the x and y coordinate difference between the enemy and the player
        distBetween = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        //if the distbetween x or y is within a certain range of the enemy it stops being in scoutmode and jumps, before aggroing and chasing you
        if ((distBetween.x < aggroRangeUpper.x && distBetween.x > aggroRangeLower.x) && (distBetween.y < aggroRangeUpper.y && distBetween.y > aggroRangeLower.y))
        {
            CancelInvoke("scoutMode");
            Invoke("warningJump", 0f);
        }

        //code for fancy pants back and forth movement, didn't use it but keeping for reference
        //velocity = new vector3 (0, Mathf.Sin(Time.time *1f)*1.5f,0); code for oscillation in the y axis, *8f is to increase period of the sine function (from 2pi to 2pi*8), *1.5f changes amplitude

    }

    //hurt player when the enemy hits him
    void OnCollisionEnter2D (Collision2D collision)
    {

        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<playerMovement>().decreaseHealth();
        }
            
    }

    //as described. moving back and forth
    void scoutMode()
    {

        if (homePos.x + 2f < transform.position.x)
        {
            goRight = false;
        }

        if (homePos.x - 2f > transform.position.x)
        {
            goRight = true;
        }

        if (goRight)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            transform.position += moveSpeed * Vector3.right * Time.deltaTime;
        }

        if (goRight == false)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            transform.position += moveSpeed * Vector3.left * Time.deltaTime;
        }
    }

    //initiated when you reach a certain range of the enemy. causes him to jump before aggroing on you after .7 seconds
    void warningJump()
    {
        if (canJump)
        {
            GetComponent<AudioSource>().Play();
            rb.AddForce(Vector2.up * 250, ForceMode2D.Impulse);
            canJump = false;
        }
        Invoke("aggroModeOn", .7f);
    }

    void aggroModeOn()
    {
        Invoke("aggroMode", 0f);
    }

    void aggroModeOff()
    {
        CancelInvoke("aggroMode");
    }

    //runs at you until you kill it or run out of a certain range, denoted by var deaggrorange
    void aggroMode()
    {
        

        if (distBetween.x > 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), aggroMoveSpeed * Time.deltaTime);
        }

        if (distBetween.x < 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), aggroMoveSpeed * Time.deltaTime);
        }

        if (distBetween.x > deaggroRange || distBetween.x < -deaggroRange)
        {
            Invoke("aggroModeOff",0f);
            Invoke("scoutMode", 0f);
            canJump = true;
        }
    }

    //plays animation and sound and decreases your health. function called externally by bullet or swordbehavior.
    public void decreaseHealth()
    {
        AudioSource[] sources = sword.GetComponents<AudioSource>();
        sources[0].Play();
        health--;
        anim.SetTrigger("Hurt");
    }

    public void kill()
    {
        Destroy(this.gameObject);
    }
}
