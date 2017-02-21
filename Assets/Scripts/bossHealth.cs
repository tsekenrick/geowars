using UnityEngine;
using System.Collections;

public class bossHealth : MonoBehaviour {
    public GameObject boss;
    public TextMesh textBox;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    //basically a ghetto way for me to display the boss's health above his head. honestly I should get a proper health bar, I've just been too busy to so far. definitely high on the to-do.
	void Update () {
       // textBox.text = boss.GetComponent<bossEnemy>().health.ToString();
        //transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);


		//works the same as the player health system
		if (boss.GetComponent<bossEnemy> ().health == 6) {
			GameObject.Find ("bossHealth3").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth2.5").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth2").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth1.5").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth1").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth0.5").GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (boss.GetComponent<bossEnemy> ().health == 5) {
			GameObject.Find ("bossHealth3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2.5").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth2").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth1.5").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth1").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth0.5").GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (boss.GetComponent<bossEnemy> ().health == 4) {
			GameObject.Find ("bossHealth3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2.5").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth1.5").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth1").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth0.5").GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (boss.GetComponent<bossEnemy> ().health == 3) {
			GameObject.Find ("bossHealth3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2.5").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth1.5").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth1").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth0.5").GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (boss.GetComponent<bossEnemy> ().health == 2) {
			GameObject.Find ("bossHealth3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2.5").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth1.5").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth1").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bossHealth0.5").GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (boss.GetComponent<bossEnemy> ().health == 1) {
			GameObject.Find ("bossHealth3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2.5").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth1.5").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bossHealth0.5").GetComponent<SpriteRenderer> ().enabled = true;
		}


	}
}
