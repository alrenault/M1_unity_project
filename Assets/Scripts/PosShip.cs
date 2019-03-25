using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosShip : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 size;
    void Start()
    {
        //taille du vaisseau
        size =gameObject.GetComponent<SpriteRenderer>().bounds.size * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //lien entre 0/1 taille d'écran et les unités unity
        Vector3 pos = transform.position;

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);

        pos.x = Mathf.Clamp(pos.x, bottomLeft.x + size.x, topRight.x - size.x);
        pos.y = Mathf.Clamp(pos.y, bottomLeft.y + size.y, topRight.y - size.y);

        transform.position = pos;


    }
}
