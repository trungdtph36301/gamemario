using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fallSpeed = 5f; // Tốc độ rơi của bom
    public float destroyDelay = 2f; // Thời gian trước khi bom biến mất sau khi chạm đất

    private void Start()
    {
        // Bắt đầu đợi và sau đó bắt đầu rơi bom
        Invoke("Fall", 10f);
    }

    private void Fall()
    {
        // Kích hoạt Rigidbody để bom rơi
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu bom chạm đất (collider với tên "Ground")
        if (collision.gameObject.tag == "huy")
        {
            // Gọi hàm DestroyBomb để biến mất bom
            DestroyBomb();
        }
    }

    private void DestroyBomb()
    {
        // Biến mất bom sau một khoảng thời gian delay
        Destroy(this.gameObject);
    }
}
