using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//refer to conversation1.cs for all the logic used here. pretty much identical.
public class conversation2: MonoBehaviour {
    public GameObject textBox;
    public Text theText;

    public TextAsset secondConvo;
    public string[] convoLines;

    public int currentLine;
    public int endLine;

    public GameObject goodButton2;
    public GameObject badButton2;
    public Transform canvas;

    public float canJump;

    bool stopSpawn = false;
	// Use this for initialization
	void Start () {
	    if (secondConvo != null)
        {
            convoLines = (secondConvo.text.Split('\n'));
        }

        endLine = convoLines.Length - 1;

        

    }

    public void goodChoice2()
    {

        Debug.Log("works");
        PlayerPrefs.SetInt("hasDoubleJump", 1);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().loadLevel("level3");
    }

    public void badChoice2()
    {
        Debug.Log("also works");
        PlayerPrefs.SetInt("hasDoubleJump", 0);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().loadLevel("level3");
    }

    // Update is called once per frame
    void Update () {

        theText.text = convoLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
        }

        if (currentLine == endLine && stopSpawn == false)
        {
            Invoke("buttonSpawn", 0f);
        }

        canJump = PlayerPrefs.GetInt("hasDoubleJump");
        Debug.Log(canJump);
	}

    void buttonSpawn()
    {
        GameObject temp = (GameObject)Instantiate(goodButton2, new Vector3(-100, -75, 0), Quaternion.identity);
        GameObject temp2 = (GameObject)Instantiate(badButton2, new Vector3(100, -75, 0), Quaternion.identity);
        temp.transform.SetParent(canvas, false);
        temp2.transform.SetParent(canvas, false);
        stopSpawn = true;
    }
}
