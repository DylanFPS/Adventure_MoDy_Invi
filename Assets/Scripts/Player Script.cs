using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 10f;       // Standardgeschwindigkeit des Spielers
    public float sprintSpeed = 6f;      // Geschwindigkeit des Spielers im Sprint
    public float smoothTime = 0.3f;     // Verzögerung für die Kameraverfolgung
    public float sprintAnimationSpeedMultiplier = 1.5f; // Multiplikator für die Animationsgeschwindigkeit im Sprint
    private Vector3 velocity = Vector3.zero; // für Glättung der Kamerabewegung
    private Animator playerAnimator;    // Referenz auf den Animator des Spielers
    private bool isSprinting;           // Variable für Sprintstatus
    private Camera mainCamera;          // Referenz auf die Hauptkamera

    private float cameraWidth, cameraHeight;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        mainCamera = Camera.main;

        // Berechne die Größe des Kamerasichtbereichs (basierend auf der orthografischen Größe)
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
    }

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
        UpdateAnimation(moveX, moveY, currentSpeed);
    }

    void LateUpdate()
    {
        // Spielerposition abrufen
        Vector3 playerPosition = transform.position;

        // Berechne die Kamera-Grenzen basierend auf der Spielerposition
        minX = playerPosition.x - cameraWidth / 2f;
        maxX = playerPosition.x + cameraWidth / 2f;
        minY = playerPosition.y - cameraHeight / 2f;
        maxY = playerPosition.y + cameraHeight / 2f;

        // Berechne die Zielposition der Kamera
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(playerPosition.x, minX, maxX),
            Mathf.Clamp(playerPosition.y, minY, maxY),
            -10 // Z-Achse bleibt konstant
        );

        // Kamera smooth bewegen
        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void UpdateAnimation(float moveX, float moveY, float currentSpeed)
    {
        // Setzen der Bewegungsanimation
        playerAnimator.SetBool("isRunningLeft", moveX < 0);
        playerAnimator.SetBool("isRunningRight", moveX > 0);
        playerAnimator.SetBool("isRunningDown", moveY < 0);
        playerAnimator.SetBool("isRunningUp", moveY > 0);

        // Setzen der Animationsgeschwindigkeit
        playerAnimator.speed = isSprinting ? sprintAnimationSpeedMultiplier : 1f;
    }
}
