using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//refer to conversation1.cs for logic of how the text rolling works.
public class instructions : MonoBehaviour {
    public Text textBox;
    public string[] dialog;
    public int endLine;
    public int currentLine;
	// Use this for initialization
	void Start () {       
        endLine = dialog.Length;
    }

    // Update is called once per frame
    void Update() {

        textBox.text = dialog[currentLine];
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
        }

        //resets any moral choices made at end of scene to make sure you start with your double jump and ranged attack.
        if (currentLine == endLine)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerPrefs.SetInt("hasDoubleJump", 0);
                PlayerPrefs.SetInt("hasRangedAttack", 0);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().loadLevel("game");
            }
        }
    }
}
