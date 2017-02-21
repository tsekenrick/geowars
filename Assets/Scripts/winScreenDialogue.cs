using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//refer to conversation1.cs for text roll logic.
public class winScreenDialogue : MonoBehaviour {
    public Text textBox;
    public string[] dialog;
    public int endLine;
    public int currentLine;

    public GameObject player;
    public GameObject bossHologram;

    public float jumpMorality;
    public float rangedMorality;

    bool stopChange;
    bool stopSpawn = false;
    // Use this for initialization
    void Start ()
    {
        stopChange = false;
    }
	
	// Update is called once per frame
	void Update () {
        textBox.text = dialog[currentLine];

        //checks the moral choices you made and displays a different set of lines based on what you chose; good if you did the good thing both times, neutral if one each, bad if you did bad choice both times
        jumpMorality = PlayerPrefs.GetInt("hasDoubleJump");
        rangedMorality = PlayerPrefs.GetInt("hasRangedAttack");

        if (rangedMorality == 1 && jumpMorality == 1 && stopChange == false)
        {
            currentLine = 0;
            stopChange = true;
            endLine = 4;
        }

        if ((rangedMorality == 1 && jumpMorality == 0 && stopSpawn == false) || (rangedMorality == 0 && jumpMorality == 1 && stopSpawn == false))
        {
            Destroy(player.gameObject);
            Invoke("bossSpawn", 0f);
            currentLine = 4;
            endLine = 10;
        }

        if (rangedMorality == 0 && jumpMorality == 0 && stopSpawn == false)
        {
            Destroy(player.gameObject);
            Invoke("bossSpawn", 0f);
            currentLine = 10;
            endLine = 16;
        }

        

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
            if (currentLine >= endLine)
            {
                SceneManager.LoadScene("endScreen");
            }
        }

    }

    //spawns the boss sprite if neutral or bad end (good end spawns the player sprite)
    void bossSpawn()
    {
        Instantiate(bossHologram, new Vector3(0, 1.7f, 0), Quaternion.identity);
        stopSpawn = true;
    }
}
