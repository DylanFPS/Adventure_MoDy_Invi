using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5;
    private Animator Player;
    public bool Sprint;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Animator>();
        Sprint = false;
    }

    // Update is called once per frame
    void Update()
        

    {
        float richtungh = Input.GetAxis("Horizontal");
        float richtungv = Input.GetAxis("Vertical");

        if(Sprint = true)
        {
            moveSpeed = 3;
        }
        if(Sprint = false)
        {
            moveSpeed = 5;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Sprint = true;
        }
        else
        {
            Sprint = false;
        }
        if(richtungh < 0)
        {
            transform.Translate(Vector2.left * moveSpeed * -richtungh * Time.deltaTime);
            Player.SetBool("isRunningLeft", true);
        }
        else
        {
            Player.SetBool("isRunningLeft", false);
        }

        if(richtungh > 0)
        {
            transform.Translate(Vector2.right * moveSpeed * richtungh * Time.deltaTime);
            Player.SetBool("isRunningRight", true);
        }
        else
        {
            Player.SetBool("isRunningRight", false);
        }

        if(richtungv < 0)
        {
            transform.Translate(Vector2.down * moveSpeed * -richtungv * Time.deltaTime);
            Player.SetBool("isRunningDown", true);
        }
        else
        {
            Player.SetBool("isRunningDown", false);
        }
        
        if(richtungv > 0)
        {
            transform.Translate(Vector2.up * moveSpeed * richtungv * Time.deltaTime);
            Player.SetBool("isRunningUp", true);
        }
        else
        {
            Player.SetBool("isRunningUp", false);
        }
        
    }
}
