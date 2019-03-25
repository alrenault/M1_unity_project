using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    private Vector2 speed;
    private Vector3 size;

    private GameObject[] respawns;
    private Vector3 siz;

    Vector3 bottomright;
    Vector3 topRight;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = new Vector2(-5,0);
        size = Camera.main.WorldToViewportPoint(gameObject.GetComponent<SpriteRenderer>().bounds.size)*0.5f;

        bottomright = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
        topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = speed;

        respawns = GameObject.FindGameObjectsWithTag("asteroid");
        if(respawns.Length > 0)
        {
            siz.x = respawns[0].GetComponent<SpriteRenderer>().bounds.size.x;
            siz.y = respawns[0].GetComponent<SpriteRenderer>().bounds.size.y;
        }

        if(respawns.Length < 10)
        {
            if(Random.Range(1,100) == 50 || respawns.Length < 4)
            {
                Vector3 tmpPos = new Vector3(bottomright.x + (siz.x / 2),
                                                Random.Range(bottomright.y + (siz.y / 2),
                                                (topRight.y - (siz.y / 2))),
                                                transform.position.z);

                GameObject gY = Instantiate(Resources.Load("asteroid"), tmpPos, Quaternion.identity) as GameObject;
            }
        }


        //disparait quand la moitié de l'asteroide sort de la camera...
        /* Vector3 pos = transform.position;
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x < (bottomLeft.x - size.x) */ /*|| screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y*/ /*)
        {
            pos = Camera.main.ViewportToWorldPoint(new Vector3(1+size.x, Random.Range(0.2f, 0.8f), 1));
            transform.position = pos;
        }*/

    }

    //si on sort de la camera... ou de la scene (moyen)...
    void OnBecameInvisible()
    {
        //Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(1 + size.x, Random.Range(0.2f, 0.8f), 1));

        Destroy(gameObject);

        //GameObject go = (GameObject)Instantiate(Resources.Load("Asteroid"));
        //go.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1 + size.x, Random.Range(0.2f, 0.8f), 1));
    }

    private void OnDestroy()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "myShip")
        {
            Debug.Log(collider.name);
            if (GameObject.FindGameObjectWithTag("life5"))
                GameObject.FindGameObjectWithTag("life5").AddComponent<FadeOut>();
            else if (GameObject.FindGameObjectWithTag("life4"))
                GameObject.FindGameObjectWithTag("life4").AddComponent<FadeOut>();
            else if (GameObject.FindGameObjectWithTag("life3"))
                GameObject.FindGameObjectWithTag("life3").AddComponent<FadeOut>();
            else if (GameObject.FindGameObjectWithTag("life2"))
                GameObject.FindGameObjectWithTag("life2").AddComponent<FadeOut>();
            else if (GameObject.FindGameObjectWithTag("life1"))
                GameObject.FindGameObjectWithTag("life1").AddComponent<FadeOut>();
            else if (GameObject.FindGameObjectWithTag("life0"))
                GameObject.FindGameObjectWithTag("life0").AddComponent<FadeOut>();
        }
    }
}
