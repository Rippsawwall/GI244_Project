using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float mass = 1f;
    public float fuel = 100f;
    
    private float currentSpeed;
    private float currentMass;
    private bool isGameOver = false;
    private float currentFuel;
    
    private Rigidbody rb;
    private InputAction moveAction;
    
    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentSpeed = speed;
        currentMass = mass;
        currentFuel = fuel;
    }

    void Update()
    {
        currentFuel -= 0.05f;
        // ถ้าเกมจบแล้ว ไม่ต้องให้ผู้เล่นขยับ
        if(isGameOver) return;
        
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * currentSpeed * Time.deltaTime * Vector3.right);
        
        // จำกัดขอบเขตการเคลื่อนที่ของผู้เล่น (ไม่ให้ออกนอกจอ)
        float xRange = 4f; // ขอบเขตซ้าย-ขวา
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (currentFuel <= 0)
        {
            isGameOver = true;
            GameManager.Instance.GameOver();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            currentFuel = fuel;
            Destroy(other.gameObject);
        }
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public float getFuel()
    {
        return currentFuel;
    }
    
}