using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAgain : MonoBehaviour
{
    private Vector2 siz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get size
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

        //if space key pressed
        bool sp = Input.GetKeyDown(KeyCode.Space);
        if (sp)
        {
            SoundState.instance.touchButtonSound();
            //Get the position of the shoot using ship position
            Vector3 tmpPos = new Vector3(transform.position.x + siz.x,
                transform.position.y,
                transform.position.z);

            //Instantiate shootOrange
            GameObject gO = Instantiate(Resources.Load("shootOrange"), tmpPos, Quaternion.identity) as GameObject;
        }
    }
}
