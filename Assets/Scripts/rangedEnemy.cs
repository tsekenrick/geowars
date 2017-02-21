using UnityEngine;
using System.Collections;
//refer to meleeEnemy.cs for AI logic, it's pretty much all identical.
public class rangedEnemy : MonoBehaviour {
    public GameObject player;
    public GameObject gun;
    public GameObject enemyBullet;
    public GameObject sword;
    public GameObject deathParticles;
    public float health;
    Vector3 homePos;
    public Vector2 distBetween;
    public Vector2 aggroRangeUpper;
    public Vector2 aggroRangeLower;
    public float aggroMoveSpeed;
    public float moveSpeed;

    public bool goRight;

    public bool canLaunch;
    public float attackSpeed;
    public float bulletUpSpeed;
    public float bulletSpeed;
    public bool canJump;
    public float deaggroRange;
    public ParticleSystem particles;
    Animator anim;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        canLaunch = true;
        homePos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canJump = true;
    }
	
	// Update is called once per frame
	void Update () {

        Invoke("scoutMode", 0f);

        if (health <= 0)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);           
        }

        distBetween = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        if ((distBetween.x < aggroRangeUpper.x && distBetween.x > aggroRangeLower.x) && (distBetween.y < aggroRangeUpper.y && distBetween.y > aggroRangeLower.y))
        {
            CancelInvoke("scoutMode");
            Invoke("warningJump", 0f);
        }
	}

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

    void aggroMode()
    {
        
        Invoke("shooting", 0f);

        if (distBetween.x > 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x - 5, transform.position.y), aggroMoveSpeed * Time.deltaTime);
        }

        if (distBetween.x < 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x + 5, transform.position.y), aggroMoveSpeed * Time.deltaTime);
        }

        if (distBetween.x > deaggroRange || distBetween.x < -deaggroRange)
        {
            Invoke("aggroModeOff", 0f);
            Invoke("scoutMode", 0f);
            canJump = true;
        }

    }

    public void shooting()
    {

        if (canLaunch)
        {
            GameObject temp = (GameObject)Instantiate(enemyBullet, gun.transform.position, Quaternion.identity);

            if (transform.rotation.y != 0)
            {
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletSpeed);
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletUpSpeed, ForceMode2D.Impulse);
            }

            if (transform.rotation.y == 0)
            {
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletSpeed);
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletUpSpeed, ForceMode2D.Impulse);
            }


            canLaunch = false;
            Invoke("shootingReset", attackSpeed);
        }
    }

    void shootingReset()
    {
        canLaunch = true;
    }

    void scoutMode()
    {

        CancelInvoke("shooting");
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<playerMovement>().decreaseHealth();
        }

    }

    public void decreaseHealth()
    {
        AudioSource[] sources = sword.GetComponents<AudioSource>();
        sources[0].Play();
        health--;
        anim.SetTrigger("Hurt");
    }
}
