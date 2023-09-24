using System;
using UnityEngine;
public class Player : MonoBehaviour
{

    [SerializeField] private float MovementSpeed = 5.0f;
    private void Awake()
    {
    }

    private void Update()
    {
        Move();
        
    }

    private void Move()
    {
        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), .0f, Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(inputVector * (MovementSpeed * Time.deltaTime));
    }

}