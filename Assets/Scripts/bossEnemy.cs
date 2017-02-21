using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class bossEnemy : MonoBehaviour
{
    //the guns are the spawn points for his bullets. floats are gameplay variables. attackSpeed is a little weird though, don't touch that.
    public GameObject gun;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject enemyBullet;
    public GameObject sword;
    public GameObject healthBarSprite;
    Animator anim;
    public float health;
    Vector3 homePos;
    public float moveSpeed;
    public bool goRight;

    public bool canLaunch;
    public float attackSpeed;
    public float bulletUpSpeed;
    public float bulletSpeed;

    public Transform spriteTransform;

    int frames;

    // Use this for initialization
    void Start()
    {
        /*constantly makes the boss turn around after a fixed amount of time. the code says 10s, but I timed it and it totally isn't. if you change the 10fs here, you also have to change float 
        attackSpeed to match it otherwise everything falls apart. */
        homePos = transform.position;
        canLaunch = true;
        anim = GetComponent<Animator>();
        InvokeRepeating("flip", 0f, 10f);
        InvokeRepeating("unflip", 5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        //increase a float 'frames' every frame update 
        frames++;

        //if health reaches 0 display the winscreen.
        if (health <= 0)
        {
            SceneManager.LoadScene("winScreen");
        }

        /*if (homePos.x + 5f < transform.position.x)
        {
            goRight = false;
        }

        if (homePos.x - 5f > transform.position.x)
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
        }*/


        //the boss fires a spray of bullets every x amount of frames, as dictated by a modulo.
        if (canLaunch && frames % 15 == 0)
        {
            GameObject temp = (GameObject)Instantiate(enemyBullet, gun.transform.position, Quaternion.identity);
          
            temp.GetComponent<Rigidbody2D>().AddForce((Vector2)spriteTransform.right * spriteTransform.localScale.x * bulletSpeed);
            

        


            GameObject temp2 = (GameObject)Instantiate(enemyBullet, gun2.transform.position, Quaternion.identity);

        
                temp2.GetComponent<Rigidbody2D>().AddForce((Vector2)spriteTransform.right * spriteTransform.localScale.x * bulletSpeed);
                temp2.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletUpSpeed);
            


            GameObject temp3 = (GameObject)Instantiate(enemyBullet, gun3.transform.position, Quaternion.identity);
         
                temp3.GetComponent<Rigidbody2D>().AddForce((Vector2)spriteTransform.right * spriteTransform.localScale.x * bulletSpeed);
                temp3.GetComponent<Rigidbody2D>().AddForce(Vector2.down * bulletUpSpeed);
            

   
            //Invoke("stopBurst", attackSpeed);


            Vector3 newScale = new Vector3(((float)health / (float)20), 1,1);
            healthBarSprite.transform.localScale = Vector3.Lerp(healthBarSprite.transform.localScale, newScale, 0.9f) ;
        }
    }

    //if boss touches player, hurt the player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<playerMovement>().decreaseHealth();
        }

    }

    //pretty sure these 2 functions are useless given recent updates to my boss AI but i'm afraid to remove it.
    void shootingReset()
    {
        CancelInvoke("stopBurst");
        canLaunch = true;
    }

    /*void stopBurst()
    {
        canLaunch = false;
        Invoke("shootingReset", attackSpeed);
    }*/

    //functions called to flip the boss every x seconds
    void flip()
    {
        Debug.Log("Flip");
        // transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        spriteTransform.localScale = new Vector3(-1f, 1f, 1f);
    }

    void unflip()
    {
        //transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        spriteTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    //lowers health, plays a sound and animation.
    public void decreaseHealth()
    {
        health--;
        AudioSource[] sources = sword.GetComponents<AudioSource>();
        sources[0].Play();
        anim.SetTrigger("Hurt");

    }

}
