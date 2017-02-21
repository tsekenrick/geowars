using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(SceneManager.GetActiveScene().buildIndex != 6)
        {
            Invoke("failNormalLoad", 1.8f);
        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Invoke("failBossLoad", 1.8f);
        }        

        Invoke("Die", 1.8f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Die()
    {
        Destroy(gameObject);
    }

    void failNormalLoad()
    {
        SceneManager.LoadScene("failScreenNormal");
    }

    void failBossLoad()
    {
        SceneManager.LoadScene("failScreenBoss");
    }
}
