using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] obstaclePrefab;
    public GameObject fuelPrefab;
    
    public float startDelay = 0.1f;
    public float repeatLate = 1f;
    
    private PlayerController playerController; // Reference ไปที่ PlayerController
    void Start()
    {
        // ค้นหา "Car" PlayerController มาใช้
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        InvokeRepeating("Spawn", startDelay, repeatLate);
    }

    void Spawn()
    {
        // ถ้าเกมจบแล้ว ให้หยุด Spawn
        if (playerController.GetIsGameOver())
        {
            CancelInvoke("Spawn");
            return;
        }
        
        // สุ่ม Spawn (Fuel, เหรียญ, หรือสิ่งกีดขวาง)
        float randomValue = Random.value;
        int spawnIndex = Random.Range(0, spawnPoint.Length);
        
        if (randomValue <= 0.25f)
        {
            Instantiate(fuelPrefab, spawnPoint[spawnIndex].position, Quaternion.identity);
        }
        else // (โอกาส Spawn Obstacle)
        {
            // สุ่มจุด Spawn 2 จุดที่ไม่ซ้ำกัน
            int firstSpawnIndex = Random.Range(0, spawnPoint.Length);
            int secondSpawnIndex;
                    
            do
            {
                secondSpawnIndex = Random.Range(0, spawnPoint.Length);
            } while (secondSpawnIndex == firstSpawnIndex); // ห้ามซ้ำกับจุดแรก
                    
            // สุ่มเลือก Prefab ของ Obstacle
            int randomIndex1 = Random.Range(0, obstaclePrefab.Length);
                    
            int randomIndex2;
            if (randomValue < 0.1f) // (โอกาสใช้ Prefab เดียวกันทั้งคู่)
            {
                randomIndex2 = randomIndex1;
            }
            else
            {
                randomIndex2 = Random.Range(0, obstaclePrefab.Length);
            }
                    
            // สร้าง Obstacle ที่จุดแรก
            Instantiate(obstaclePrefab[randomIndex1], spawnPoint[firstSpawnIndex].position, Quaternion.identity);
                    
            // สร้าง Obstacle ที่จุดสอง
            Instantiate(obstaclePrefab[randomIndex2], spawnPoint[secondSpawnIndex].position, Quaternion.identity);
        }
    }
}