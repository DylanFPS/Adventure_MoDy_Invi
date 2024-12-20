using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f;        // Standardgeschwindigkeit des Spielers
    public float sprintSpeed = 6f;     // Geschwindigkeit des Spielers im Sprint
    public float smoothTime = 0.3f;     // Verzögerung für die Kameraverfolgung
    private Vector3 velocity = Vector3.zero; // für Glättung der Kamerabewegung
    private Animator Player;            // Referenz auf den Animator des Spielers
    private bool Sprint;                // Variabel für Sprintstatus


    // Start ist beim ersten Frame
    void Start()
    {
        Player = GetComponent<Animator>();
        Sprint = false;
    }

    // Update wird pro Frame aufgerufen
    void Update()
    {
        float richtungh = Input.GetAxis("Horizontal");
        float richtungv = Input.GetAxis("Vertical");

        // Sprint-Logik
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Sprint = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Sprint = false;
        }

        float currentSpeed = Sprint ? sprintSpeed : moveSpeed;

        // Bewegung und Animation
        if (richtungh < 0)
        {
            transform.Translate(Vector2.left * currentSpeed * -richtungh * Time.deltaTime);
            Player.SetBool("isRunningLeft", true);
        }
        else
        {
            Player.SetBool("isRunningLeft", false);
        }

        if (richtungh > 0)
        {
            transform.Translate(Vector2.right * currentSpeed * richtungh * Time.deltaTime);
            Player.SetBool("isRunningRight", true);
        }
        else
        {
            Player.SetBool("isRunningRight", false);
        }

        if (richtungv < 0)
        {
            transform.Translate(Vector2.down * currentSpeed * -richtungv * Time.deltaTime);
            Player.SetBool("isRunningDown", true);
        }
        else
        {
            Player.SetBool("isRunningDown", false);
        }

        if (richtungv > 0)
        {
            transform.Translate(Vector2.up * currentSpeed * richtungv * Time.deltaTime);
            Player.SetBool("isRunningUp", true);
        }
        else
        {
            Player.SetBool("isRunningUp", false);
        }
        }

    void LateUpdate()
    {
        // Kamera verfolgen
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, -10); // -10 sorgt dafür, dass die Kamera im Hintergrund bleibt
        Vector3 smoothPosition = Vector3.SmoothDamp(Camera.main.transform.position, targetPosition, ref velocity, smoothTime);
        Camera.main.transform.position = smoothPosition;
    }
}