using UnityEngine;
using System.Collections;

public class loopToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        //restarts game when you press R. gives back double jump and ranged attack if you chose to discard it during the previous game.
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("hasDoubleJump", 0);
            PlayerPrefs.SetInt("hasRangedAttack", 0);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().loadLevel("game");
        }
	}
}
