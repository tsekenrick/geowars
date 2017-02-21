using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class conversation1 : MonoBehaviour {
    public GameObject textBox;
    public Text theText;

    public TextAsset firstConvo;
    public string[] convoLines;

    public int currentLine;
    public int endLine;

    public GameObject goodButton;
    public GameObject badButton;
    public Transform canvas;

    public float canRangedAttack;

    bool stopSpawn = false;
	// Use this for initialization
	void Start () {
        //script refers to an external .txt file and compartmentalizes it into a string array, with a new array item every time 'return' shows up in the text file (i.e. one line = one array item)
	    if (firstConvo != null)
        {
            convoLines = (firstConvo.text.Split('\n'));
        }

        endLine = convoLines.Length - 1;

        

    }

    //goodchoice is called when you press the button for the moral choice. badchoice for bad button, etc.
    public void goodChoice()
    {
        //PlayerPrefs.SetInt("hasDoubleJump", 0);
        Debug.Log("works)");
        PlayerPrefs.SetInt("hasRangedAttack", 1);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().loadLevel("level2");
    }

    public void badChoice()
    {
        Debug.Log("also works");
        PlayerPrefs.SetInt("hasRangedAttack", 0);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().loadLevel("level2");
    }

    // Update is called once per frame
    void Update () {
        //displays a line of text in the textbox, the displayed line incremented to the next one every time enter or space is pressed.
        theText.text = convoLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
        }

        //causes the buttons to spawn once the end of the script is reached.
        if (currentLine == endLine && stopSpawn == false)
        {
            Invoke("buttonSpawn", 0f);
        }

        canRangedAttack = PlayerPrefs.GetInt("hasRangedAttack");
        Debug.Log(canRangedAttack);
	}

    //don't touch the buttonspawn code, took me a million years to get it to work.
    void buttonSpawn()
    {
        GameObject temp = (GameObject)Instantiate(goodButton, new Vector3(-100, -75, 0), Quaternion.identity);
        GameObject temp2 = (GameObject)Instantiate(badButton, new Vector3(100, -75, 0), Quaternion.identity);
        temp.transform.SetParent(canvas, false);
        temp2.transform.SetParent(canvas, false);
        stopSpawn = true;
    }
}
