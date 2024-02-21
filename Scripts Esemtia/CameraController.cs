using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // La mesa alrededor de la cual la c�mara se mover�
    public float speed = 1.0f; // Velocidad de movimiento de la c�mara

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position; // Calcula el offset inicial
    }

    void Update()
    {
        // Calcula una posici�n en el c�rculo alrededor de la mesa
        Vector3 targetPosition = target.position + offset;
        targetPosition += Quaternion.Euler(0, Time.time * speed, 0) * offset;

        // Interpola suavemente hacia la nueva posici�n
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        // Mira hacia el objetivo (la mesa) en todo momento
        transform.LookAt(target.position);
    }
}
