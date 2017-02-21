using UnityEngine;
using System.Collections;

public class bossBullet : MonoBehaviour
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
        if (Time.time > startTime + aliveTime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "ground")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<playerMovement>().decreaseHealth();

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
        /*if (collision.gameObject.tag== "wall" || collision.gameObject.tag == "ground")
        {
            Destroy(this.gameObject);
        }*/
    }
}
