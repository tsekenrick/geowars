using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class playerMovement : MonoBehaviour
{

    //basically a crapload of variables. the floats adjust certain game functions, the bools are basically flags to check certain functions to turn on/off their functionality.
    public float canDoubleJump = 1f;
    public bool inAir = false;
    
    public float health;
    public float drag;
    public float moveSpeed;
    public float friction;
    public float wallJumpForce;
    public float jumpHeight;
    public float hurtForce;
    public float hurtForceUp;
    public float wallJumpHeight;

    public float moralityCheck2;

    public bool canHurt;
    public bool leftFacing;
    public bool rightFacing;
    public bool interactMode;
    public bool touchingWall = false;
    public GameObject sword;
    public GameObject deathParticles;

    //public Sprite idlesprite;
    //public Sprite meleesprite;

    public LayerMask rayMask;

    //checks for raycast hits. used for detecting whether or not i'm in the air and whether or not i'm on a wall (for walljumps)
    RaycastHit2D hit;
    RaycastHit2D hitLeft;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    RaycastHit2D hitLeft2;
    RaycastHit2D hitLeft3;
    RaycastHit2D hitDown;
    RaycastHit2D hitDown2;

    Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        //player starts off facing right. these bools switch between true/false based on the last key pressed, and rotate the sprite accordingly
        leftFacing = false;
        rightFacing = true;
        //interactMode is used only for doors, basically when W is held down this will become true and I can interact with doors
        interactMode = false;
        //used to give iframes - after losing health this bool becomes false for 1 second, during which you cannot be hurt
        canHurt = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource[] sources = GetComponents<AudioSource>();

        //idle and walk animations based on velocity of player
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.magnitude) < .1f)
        {
            anim.Play("idleAnim");
        }

        if (GetComponent<Rigidbody2D>().velocity.magnitude != 0 && inAir == false)
        {
            anim.Play("walkAnim");
        }

        touchingWall = false;
        //basically a crapload of raycast logic for awhile, its function was described above. you can see the raycasts in the client since I did drawray.
        GetComponent<BoxCollider2D>().sharedMaterial.friction = .5f;
        Debug.DrawRay(transform.position, Vector3.right * .6f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, .6f, rayMask);
        if (hit)
        {
            if (hit.transform.tag == "ground" || hit.transform.tag == "wall")
            {
                Debug.Log(hit);
                //GetComponent<BoxCollider2D>().sharedMaterial.friction = 0.5f;
                //inAir = false;
                canDoubleJump = 0f;
                touchingWall = true;
            }
            /*else
            {
                inAir = true;
            }*/

        }

        Debug.DrawRay(transform.position, Vector3.left * .6f, Color.red);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, .6f, rayMask);
        if (hitLeft)
        {
            if (hitLeft.transform.tag == "ground" || hitLeft.transform.tag == "wall")
            {
                Debug.Log(hitLeft);
                //inAir = false;
                canDoubleJump = 0f;
                touchingWall = true;

            }
            /*else
            {
                inAir = true;
            }*/

        }

        Vector3 lowRay = new Vector3(transform.position.x, transform.position.y - .75f, transform.position.z);
        Debug.DrawRay(lowRay, Vector3.right * .6f, Color.red);
        RaycastHit2D hit2 = Physics2D.Raycast(lowRay, Vector2.right, .6f, rayMask);
        if (hit2)
        {
            if (hit2.transform.tag == "ground" || hit2.transform.tag == "wall")
            {
                Debug.Log("touching wall to right");
                //inAir = false;
                canDoubleJump = 0f;
                touchingWall = true;

            }
            /*else
            {
                inAir = true;
            }*/

        }

        Debug.DrawRay(lowRay, Vector3.left * .6f, Color.red);
        RaycastHit2D hitLeft2 = Physics2D.Raycast(lowRay, Vector2.left, .6f, rayMask);
        if (hitLeft2)
        {
            if (hitLeft2.transform.tag == "ground" || hitLeft2.transform.tag == "wall")
            {
                Debug.Log(hitLeft2);
                //inAir = false;
                canDoubleJump = 0f;
                touchingWall = true;

            }
            /*else
            {
                inAir = true;
            }*/

        }

        Vector3 highRay = new Vector3(transform.position.x, transform.position.y + .75f, transform.position.z);
        Debug.DrawRay(highRay, Vector3.right * .6f, Color.red);
        RaycastHit2D hit3 = Physics2D.Raycast(highRay, Vector2.right, .6f, rayMask);
        if (hit3)
        {
            if (hit3.transform.tag == "ground" || hit3.transform.tag == "wall")
            {
                Debug.Log("touching wall to right");
                //inAir = false;
                canDoubleJump = 0f;
                touchingWall = true;

            }
            /*else
            {
                inAir = true;
            }*/

        }

        Debug.DrawRay(highRay, Vector3.left * .6f, Color.red);
        RaycastHit2D hitLeft3 = Physics2D.Raycast(highRay, Vector2.left, .6f, rayMask);
        if (hitLeft3)
        {
            if (hitLeft3.transform.tag == "ground" || hitLeft3.transform.tag == "wall")
            {
                Debug.Log(hitLeft3);
                //inAir = false;
                canDoubleJump = 0f;
                touchingWall = true;

            }
            /*else
            {
                inAir = true;
            }*/

        }

        Vector3 downRayLeft = new Vector3(transform.position.x-.4f, transform.position.y, transform.position.z);
        Debug.DrawRay(downRayLeft, Vector3.down * 1f, Color.red);
        RaycastHit2D hitDown = Physics2D.Raycast(downRayLeft, Vector2.down, 1f, rayMask);
        if (hitDown)
        {
            if (hitDown.transform.tag == "ground" /*|| hitDown.transform.tag == "wall"*/)
            {
                inAir = false;
                canDoubleJump = 1f;
            }
            else
            {
                Debug.Log("left ray missed ground");
                inAir = true;
            }
        }

        Vector3 downRayRight = new Vector3(transform.position.x + .4f, transform.position.y, transform.position.z);
        Debug.DrawRay(downRayRight, Vector3.down * 1f, Color.red);
        RaycastHit2D hitDown2 = Physics2D.Raycast(downRayRight, Vector2.down, 1f, rayMask);
        if (hitDown2)
        {
            if (hitDown2.transform.tag == "ground" /*|| hitDown2.transform.tag == "wall"*/)
            {
               

                inAir = false;
                canDoubleJump = 1f;
            }
            else
            {
                inAir = true;
                Debug.Log("right ray missed ground");
            }
        }

        /*logic for jumps. if any of the left/right facing raycasts hit an object, it assumes i'm touching a wall and lets me wall jump. otherwise, it does a regular jump and decreases candoublejump by one
        if candoublejump is less than 0, no jump actions can be performed. the float is reset to 1 anytime the player is touching the ground. walljumps don't decrease the float because you can wall
        jump infinitely*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ((canDoubleJump >= 0) || (inAir == false))
            {
                if (touchingWall)
                {
                    walljump();
                    jump();
                }
                else
                {
                    jump();
                    canDoubleJump--;
                }
                //canDoubleJump--;

                /*else
                {
                    Invoke("jump", 0f);
                    canDoubleJump--;
                }*/

            }
        }

        //door interacting code
        if (Input.GetKeyDown(KeyCode.W))
        {
            interactMode = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            interactMode = false;
        }

        //movement code, also switches bools for right/left facing as previously described
        if (Input.GetKey(KeyCode.D))
        {
            if (inAir == false)
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }

            if (inAir == true)
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }

            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            rightFacing = true;
            leftFacing = false;
        }

        if (Input.GetKey(KeyCode.A))
        {

            if (inAir == false)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }

            if (inAir == true)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }

            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            leftFacing = true;
            rightFacing = false;
        }


        if (inAir)
        {
            //apply drag           
            rb.AddForce(drag * rb.velocity.normalized * rb.velocity.sqrMagnitude); //this force increases as the rigidbody moves faster while in the air

        }

        if (inAir == false)
        {
            //apply friction
            rb.AddForce(friction * rb.velocity.normalized * rb.velocity.sqrMagnitude); //this force increases as the rigidbody moves faster while not in the air

        }

        //health indicator
        if (health >= 3)
        {
            GameObject.Find("3hp").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("2hp").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("1hp").GetComponent<SpriteRenderer>().enabled = false;
        }

        if (health == 2)
        {
            GameObject.Find("3hp").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("2hp").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("1hp").GetComponent<SpriteRenderer>().enabled = false;
        }

        if (health == 1)
        {
            GameObject.Find("3hp").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("2hp").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("1hp").GetComponent<SpriteRenderer>().enabled = true;
        }

        if (health <= 0 && SceneManager.GetActiveScene().buildIndex != 6)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (health <= 0 && SceneManager.GetActiveScene().buildIndex == 6)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);         
        }

        //invincibility flash
        Color mainColor = GetComponent<SpriteRenderer>().color;
        if (canHurt == false)
        {
            mainColor.a = Mathf.Abs(Mathf.Sin(Time.time * 20f));
        }
        else
        {
            mainColor.a = 1f;
        }
        GetComponent<SpriteRenderer>().color = mainColor;

    }


    void jump()
    {
        //anim.Play("jumpAnim");
        anim.SetTrigger("Jump");
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        
        /*morality check is a float grabbed from playerprefs for hasdoublejump, which checks whether or not the player has chosen to discard his double jump (a choice you make between lvl 2 and 3). if 
        hasdoublejump is 1, the player can no longer doublejump.*/
        moralityCheck2 = PlayerPrefs.GetInt("hasDoubleJump");
        if (moralityCheck2 == 1f)
        {
            canDoubleJump = -1f;
        }

    }

    /*walljump only ever executes in tandem with jump. combined, they create a slight push perpendicular to the wall as well as an upwards boost. the code isn't perfect so the walljump doesn't always feel
    great, i'm thinking about fine tuning it.*/
    void walljump()
    {
        if (rightFacing)
        {
            rb.AddForce(Vector2.left * wallJumpForce, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * wallJumpHeight, ForceMode2D.Impulse);
        }

        if (leftFacing)
        {
            rb.AddForce(Vector2.right * wallJumpForce, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * wallJumpHeight, ForceMode2D.Impulse);
        }
    }

    //checks if you're in the air
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "wall")
        {
            inAir = true;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //old boolean based air detection, replaced with shiny new raycast tech. keeping here in case.
        /*if (collision.gameObject.tag == "ground")
        {
            inAir = false;
            canDoubleJump = 1f;
        }

        if (collision.gameObject.tag == "wall")
        {
            inAir = false;
            canDoubleJump = 1f;
        }*/

        //knockback when hurt by enemy
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "meleeEnemy" || collision.gameObject.tag == "bossEnemy")
        {
            if (collision.gameObject.transform.position.x > transform.position.x)
            {
                rb.AddForce(Vector2.left * hurtForce, ForceMode2D.Impulse);
                rb.AddForce(Vector2.up * hurtForceUp, ForceMode2D.Impulse);
            }

            if (collision.gameObject.transform.position.x < transform.position.x)
            {
                rb.AddForce(Vector2.right * hurtForce, ForceMode2D.Impulse);
                rb.AddForce(Vector2.up * hurtForceUp, ForceMode2D.Impulse);
            }
        }
    }

    //decreases health, plays a hurt sound and activates invincibility frames
    public void decreaseHealth()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        if (canHurt)
        {
            health--;
            canHurt = false;
            Invoke("iFramesOff", 1f);
            sources[2].Play();
        }
    }

    void iFramesOff()
    {
        canHurt = true;
    }

    //function for walk sound, called in an animation event for walking
    public void walkSound()
    {
        if (inAir == false)
        {
            AudioSource[] sources = GetComponents<AudioSource>();
            sources[0].Play();
        }
    }

    //function for jump sound, called in animation event for jumping
    public void jumpSound()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        sources[1].Play();
    }
}
