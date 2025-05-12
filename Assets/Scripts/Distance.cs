using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private float score;
    
    public TextMeshProUGUI distanceText;
    private PlayerController playerController; // Reference ไปที่ PlayerController
    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.GetIsGameOver())
        {
            score += playerController.GetCurrentSpeed() * Time.deltaTime; // คำนวณระยะทางจากความเร็วปัจจุบัน x เวลา
            distanceText.text = "Distance\n" + Mathf.RoundToInt(score); // แสดงระยะทางแบบจำนวนเต็ม (ปัดเศษด้วย Mathf.RoundToInt)
        }
    }
}