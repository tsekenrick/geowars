using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPos;
    Vector3 cameraPos;
    //public bool canMove = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //basically has the sum effect of making the camera follow slightly behind the player at all times. also fixes camera 1.5 higher than center.
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, transform.position.z);
        cameraPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Vector3 delta = playerPos - cameraPos;
        float moveX=0;
        float moveY=0;
        if (Mathf.Abs(delta.x) > 1.35f)
        {
            if (delta.x > 0) moveX = delta.x - 1.20f; //zero until the camera moves outside the window  
            else moveX = delta.x + 1.20f; //zero until the camera moves outside the window  
        }
        if (Mathf.Abs(delta.y) > 1.35f)
        {
            if (delta.y > 0) moveY = delta.y - 1.20f; //zero until the camera moves outside the window    
            else moveY = delta.y + 1.20f;
        }


        transform.position = Vector3.Lerp(cameraPos, cameraPos + new Vector3(moveX, moveY, 0), .125f);



        transform.rotation = Quaternion.identity;

    }
}
