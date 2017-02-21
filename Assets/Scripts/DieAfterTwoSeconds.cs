using UnityEngine;
using System.Collections;

public class DieAfterTwoSeconds : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Die", 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Die()
    {

        Destroy(gameObject);
    }
}
