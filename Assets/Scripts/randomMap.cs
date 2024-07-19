using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomMap : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Danh sách các prefab của quái vật
    public List<GameObject> spawnedEnemies; // Danh sách chứa các quái vật đã tạo ra
    public List<GameObject> listGround; //Mảng các block bản đồ
    public GameObject applePrefab;
    public Transform player;
    public float rangeToDestroyObject = 60f; //Khoảng cách để tạo sẵn map và hủy

    public List<GameObject> listGroundOld; //Mảng chứa các block map được tạo ra

    Vector3 endPos; //Vi tri cuoi cung
    Vector3 nextPos; //Vi tri tiep theo


    int groundLen;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(18.0f, -2.0f, 0.0f);

        generateBlockMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, endPos) < rangeToDestroyObject)
        {
            generateBlockMap();
        }

        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }

    void generateBlockMap()
    {
        for (int i = 0; i < 5; i++)
        {
            float khoangCach = Random.Range(4f, 6f); //Khoảng cách ngẫu nhiên giữa các block
            nextPos = new Vector3(endPos.x + khoangCach, -2f, 0f);

            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            int groundID = Random.Range(0, listGround.Count);

            //Tạo ra block bản đồ ngẫu nhiên
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(newGround); //THêm miếng đất vừa tạo vào mảng

            switch (groundID)
            {
                case 0: groundLen = 6; break;
                case 1: groundLen = 8; break;
                case 2: groundLen = 10; break;
                case 3: groundLen = 12; break;
                case 4: groundLen = 14; break;
            }

            endPos = new Vector3(nextPos.x + groundLen, -2f, 0f);

            // Randomly choose an enemy prefab
            int enemyIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[enemyIndex];

            // Random position within the bounds of the ground block
            Vector3 enemySpawnPos = new Vector3(Random.Range(nextPos.x - groundLen / 2, nextPos.x + groundLen / 2), -1f, 0f);

            // Instantiate the enemy
            GameObject newEnemy = Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity);

            // Add the enemy to the list of spawned enemies
            spawnedEnemies.Add(newEnemy);

            // Randomly spawn apples on the ground block
            if (Random.value < 0.2f) // Adjust the probability as needed
            {
                Vector3 appleSpawnPos = new Vector3(Random.Range(nextPos.x - groundLen / 2, nextPos.x + groundLen / 2), -1f, 0f);
                Instantiate(applePrefab, appleSpawnPos, Quaternion.identity);
            }
        }
    }

}
