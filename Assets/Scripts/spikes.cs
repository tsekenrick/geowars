using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {

    public float hurtForce;
    public float hurtForceUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //hurts enemies and players alike and causes a knockback

        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<playerMovement>().decreaseHealth();
        }

        if (collision.gameObject.tag == "meleeEnemy")
        {
            collision.gameObject.GetComponent<meleeEnemy>().decreaseHealth();
        }

        if (collision.gameObject.tag == "rangedEnemy")
        {
            collision.gameObject.GetComponent<rangedEnemy>().decreaseHealth();
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
