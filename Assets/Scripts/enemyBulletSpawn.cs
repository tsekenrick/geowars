using UnityEngine;
using System.Collections;

public class enemyBulletSpawn : MonoBehaviour {
    public GameObject enemyBullet;
    public GameObject rangedEnemy;

    public bool canLaunch;
    public float attackSpeed;
    public float bulletUpSpeed;
    public float bulletSpeed;
    // Use this for initialization
    void Start () {
        canLaunch = true;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    //function invoked in rangedEnemy.cs when player reaches certain distance from the enemy. causes enemy to start shooting in an arc at a fixed rate relative to attackSpeed.
    public void shooting()
    {
        if (canLaunch)
        {
            GameObject temp = (GameObject)Instantiate(enemyBullet, transform.position, Quaternion.identity);

            if (rangedEnemy.transform.rotation.y == 180)
            {
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletSpeed);
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletUpSpeed, ForceMode2D.Force);
            }

            if (rangedEnemy.transform.rotation.y == 0)
            {
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletSpeed);
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletUpSpeed, ForceMode2D.Force);
            }


            canLaunch = false;
            Invoke("shootingReset", attackSpeed);
        }
    }

    void shootingReset()
    {
        canLaunch = true;
    }
}

