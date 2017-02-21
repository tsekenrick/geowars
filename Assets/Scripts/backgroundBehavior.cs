using UnityEngine;
using System.Collections;

public class backgroundBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //background follows camera which in turn follows the player, at a function of the speed of the camera's movement
        Vector3 newPosition = Camera.main.transform.position;
        newPosition.z = 0;
        transform.position = newPosition * .8f;
    }
}
