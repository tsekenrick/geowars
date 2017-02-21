using UnityEngine;
using System.Collections;

public class bulletSpawn : MonoBehaviour {
    //floats are gameplay variables. why do I bother saying so every time?
    public GameObject bullet;
    public bool canLaunch;
    public float attackSpeed;
    public GameObject player;
    public float bulletSpeed;
    public float moralityCheck;
    public GameObject sword;
    // Use this for initialization
    void Start(){
        canLaunch = true;

    }

    // Update is called once per frame
    void Update() {
        //shoot on right click, works as both automatic or semi-auto.
        //like the doublejump logic, checks a playerprefs int for hasrangedattack. the int is changed depending on your choice in the conversation between lvl 1 and 2. if =1, you can't shoot.
        moralityCheck = PlayerPrefs.GetInt("hasRangedAttack");
        if (canLaunch && moralityCheck == 0 && (Input.GetMouseButton(1) || Input.GetMouseButtonDown(1)))
        {
            //play animation and sound
            GetComponent<AudioSource>().Play();
            sword.GetComponent<Animator>().SetTrigger("Recoil");

            GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            
            //bulletspeed and direction as dictated by a float and bool state respectively
            if (player.GetComponent<playerMovement>().leftFacing)
            {
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletSpeed);
            }

            if (player.GetComponent<playerMovement>().rightFacing)
            {
                temp.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletSpeed);
            }

            //code to restrict shooting to every 'attackSpeed' seconds
            canLaunch = false;
            Invoke("shootingReset", attackSpeed);
        }
	}
        
    void shootingReset()
    {
        canLaunch = true;
    }
}
