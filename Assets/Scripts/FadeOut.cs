using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color cl = GetComponent<SpriteRenderer>().color;
        cl.a -= 0.05f;
        GetComponent<SpriteRenderer>().color = cl;
        if(cl.a < 0)
        {
            Destroy(gameObject);
        }
    }
}
