using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {
    int currentStage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    //skips you to the next scene in the sequence when you press t. this script is attacked to a gameobject in every stage.
    currentStage = SceneManager.GetActiveScene().buildIndex;
	if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene(currentStage +1);
        }
	}

    public void loadLevel(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
