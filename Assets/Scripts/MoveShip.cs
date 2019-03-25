using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    private Vector2 speed;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        this.movement = new Vector2();
        this.speed = new Vector2(5, 5);
    }


    // Update is called once per frame
    void Update()
    {
        //fait bouger le vaisseau lors de la pression des flèches
        float verti = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        movement = new Vector2(
            speed.x * hori,
            speed.y * verti);

        gameObject.GetComponent<Rigidbody2D>().velocity = movement;
    }

    void FixedUpdate()
    {

    }
}
