using TMPro;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    private float fuel = 100f;

    public TextMeshProUGUI fuelText;
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.GetIsGameOver())
        {
            fuel = playerController.getFuel();
            fuelText.text = "Fuel\n" + Mathf.Floor(fuel); // แสดงระยะทางแบบจำนวนเต็ม (ปัดเศษด้วย Mathf.RoundToInt)
        }
    }
}