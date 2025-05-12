using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 10f;
    public float mass = 1f;
    private float currentSpeed;
    private float baseSpeed;
    
    private PlayerController playerController; // อ้างอิงถึง PlayerController เพื่อตรวจสอบว่าเกมจบหรือยัง
    void Start()
    {
        // ค้นหา "Player" PlayerController มาใช้
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        currentSpeed = speed;
        baseSpeed = speed;
    }

    void Update()
    {
        // ถ้าเกมยังไม่จบ ให้วัตถุเคลื่อนที่ไปข้างหลังหาผู้เล่น
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
    }

    public float GetMass()
    {
        return mass;
    }

    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }
}