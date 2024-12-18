using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;
    private Animator Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float richtungh = Input.GetAxis("Horizontal");
        float richtungv = Input.GetAxis("Vertical");


        if(richtungh < 0)
        {
            transform.Translate(Vector2.left * speed * -richtungh * Time.deltaTime);
            Player.SetBool("isRunningLeft", true);
        }
        else
        {
            Player.SetBool("isRunningLeft", false);
        }
        if(richtungh > 0)
        {
            transform.Translate(Vector2.right * speed * richtungh * Time.deltaTime);
            Player.SetBool("isRunningRight", true);
        }
        else
        {
            Player.SetBool("isRunningRight", false);
        }
        if(richtungv < 0)
        {
            transform.Translate(Vector2.down * speed * -richtungv * Time.deltaTime);
            Player.SetBool("isRunningDown", true);
        }
        else
        {
            Player.SetBool("isRunningDown", false);
        }
        if(richtungv > 0)
        {
            transform.Translate(Vector2.up * speed * richtungv * Time.deltaTime);
            Player.SetBool("isRunningUp", true);
        }
        else
        {
            Player.SetBool("isRunningUp", false);
        }

    }
}
