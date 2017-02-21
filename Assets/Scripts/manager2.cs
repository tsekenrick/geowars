using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class manager2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //script is attached to scene displayed when player dies. resets game to lvl 1 and gives back your double jump and ranged attack.
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("game");
            PlayerPrefs.SetInt("hasDoubleJump", 0);
            PlayerPrefs.SetInt("hasRangedAttack", 0);
        }
    }
}

