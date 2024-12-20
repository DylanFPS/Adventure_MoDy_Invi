using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f;        // Standardgeschwindigkeit des Spielers
    public float sprintSpeed = 6f;      // Geschwindigkeit des Spielers im Sprint
    public float smoothTime = 0.3f;     // Verzögerung für die Kameraverfolgung
    private Vector3 velocity = Vector3.zero; // für Glättung der Kamerabewegung
    private Animator playerAnimator;    // Referenz auf den Animator des Spielers
    private bool isSprinting;           // Variabel für Sprintstatus

    // Start ist beim ersten Frame
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update wird pro Frame aufgerufen
    void Update()
    {
        // Eingaben für Bewegung
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Sprint-Logik
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Geschwindigkeit je nach Sprint
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        // Berechnung der Bewegungsrichtung
        Vector2 movement = new Vector2(moveX, moveY).normalized * currentSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Animationssteuerung
        UpdateAnimation(moveX, moveY);
    }

    // Methode zur Steuerung der Animationen
    private void UpdateAnimation(float moveX, float moveY)
    {

        // Setzen der Bewegungsanimation
        playerAnimator.SetBool("isRunningLeft", moveX < 0);
        playerAnimator.SetBool("isRunningRight", moveX > 0);
        playerAnimator.SetBool("isRunningDown", moveY < 0);
        playerAnimator.SetBool("isRunningUp", moveY > 0);
    }

    void LateUpdate()
    {
        // Kamera verfolgen
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, -10); // -10 sorgt dafür, dass die Kamera im Hintergrund bleibt
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, targetPosition, ref velocity, smoothTime);
    }
}