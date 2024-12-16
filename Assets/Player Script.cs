using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float richtungh = Input.GetAxis("Horizontal");
        float richtungv = Input.GetAxis("Vertical");

        if(richtungh < 0)
        {
            transform.Translate(Vector2.left * speed * -richtungh * Time.deltaTime);
        }
        if(richtungh > 0)
        {
            transform.Translate(Vector2.right * speed * richtungh * Time.deltaTime);
        }
        if(richtungv < 0)
        {
            transform.Translate(Vector2.down * speed * -richtungv * Time.deltaTime);
        }
        if(richtungv > 0)
        {
            transform.Translate(Vector2.up * speed * richtungv * Time.deltaTime);
        }

    }
}
