using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    public float aliveTime;
    public float startTime;

    public float hurtForce;
    public float hurtForceUp;
    // Use this for initialization
    void Start()
    {
        
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //gives bullet a certain time to live, defined by alivetime
        if (Time.time > startTime + aliveTime)
        {
            Destroy(this.gameObject);
        }

    }

    //makes sure bullet dies when it hits an obstacle, and decreases enemy health on impact, and applies a knockback.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "ground" || collision.gameObject.tag == "spikes")
        {
            Destroy(this.gameObject);
        }

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

        Destroy(this.gameObject);

        
    }
}
