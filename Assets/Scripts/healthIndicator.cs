using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthIndicator : MonoBehaviour {
    public GameObject player;
    public Text textBox;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    //old ghetto player health indicator code, keeping it in case.
	void Update () {
	textBox.text = "Health is " + player.GetComponent<playerMovement>().health.ToString();
	}
}
