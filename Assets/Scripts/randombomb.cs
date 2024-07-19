using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab; // Prefab của quả bom
    public float spawnInterval = 10f; // Thời gian giữa mỗi lần tạo bom
    public float spawnHeight = 10f; // Độ cao mà bom sẽ được tạo ra

    private void Start()
    {
        // Bắt đầu gọi hàm Tạo bom tự động
        InvokeRepeating("SpawnBomb", spawnInterval, spawnInterval);
    }

    private void SpawnBomb()
    {
        // Tạo một vị trí ngẫu nhiên trên trục x trong phạm vi của màn hình
        float randomX = Random.Range(Camera.main.ScreenToWorldPoint(Vector3.zero).x, Camera.main.ScreenToWorldPoint(Vector3.right * Screen.width).x);

        // Tạo một vị trí từ vị trí ngẫu nhiên và độ cao đã định
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

        // Tạo bom tại vị trí đã được tạo
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }
}
