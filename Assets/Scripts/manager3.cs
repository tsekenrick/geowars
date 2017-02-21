using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class manager3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    //code attached to boss stage. instead of resetting back to lvl 1, just resets you to start of the scene, but any moral choices for double jump/ranged attack are not reset.
	if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("bossLevel");
        }
	}
}
