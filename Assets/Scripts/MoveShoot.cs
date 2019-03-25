using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShoot : MonoBehaviour
{
    private Vector2 speed;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = new Vector2(5, 0);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add the fade script to the gameObject containing this script
        collision.gameObject.AddComponent<FadeOut>();

        GameState.instance.addScorePlayer(1);

        //Shoot destroy
        Destroy(gameObject);
    }
}
