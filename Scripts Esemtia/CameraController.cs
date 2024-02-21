using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // La mesa alrededor de la cual la cámara se moverá
    public float speed = 1.0f; // Velocidad de movimiento de la cámara

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position; // Calcula el offset inicial
    }

    void Update()
    {
        // Calcula una posición en el círculo alrededor de la mesa
        Vector3 targetPosition = target.position + offset;
        targetPosition += Quaternion.Euler(0, Time.time * speed, 0) * offset;

        // Interpola suavemente hacia la nueva posición
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        // Mira hacia el objetivo (la mesa) en todo momento
        transform.LookAt(target.position);
    }
}
