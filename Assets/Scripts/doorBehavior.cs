using UnityEngine;
using System.Collections;

public class doorBehavior : MonoBehaviour {
    public GameObject player;
    GameObject[] meleeEnemyCount;
    GameObject[] rangedEnemyCount;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //changes door from black to green after you kill all the enemies on the map, and allows you to interact with it.
        meleeEnemyCount = GameObject.FindGameObjectsWithTag("meleeEnemy");
        rangedEnemyCount = GameObject.FindGameObjectsWithTag("rangedEnemy");

        if (meleeEnemyCount.Length + rangedEnemyCount.Length != 0)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
            GameObject.Find("lockedDoorText").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("openDoorText").GetComponent<SpriteRenderer>().enabled = false;
        }

        if (meleeEnemyCount.Length + rangedEnemyCount.Length == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(.086f, .706f, .608f, 1f);
            GameObject.Find("lockedDoorText").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("openDoorText").GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.gameObject.name == "player" && player.GetComponent<playerMovement>().interactMode == true && meleeEnemyCount.Length + rangedEnemyCount.Length == 0)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().loadLevel("conversation1");
        }
    }
}
