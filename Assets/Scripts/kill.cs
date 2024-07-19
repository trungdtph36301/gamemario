using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class kill : MonoBehaviour
{
    public thanhMau thanhmau;
    public float luongMauHienTai;
    public float luongMauToiDa = 5;
    public GameObject panel1, button, text;
    public GameObject panel2, button2, text2;
    public TextMeshProUGUI diemText;
    public TextMeshProUGUI highScoreText;
    int tong = 0;
    public GameObject PSBrick;

    void tinhTong(int score)
    {
        tong += score;
        diemText.text = "" + tong;
        // diemText.text = tong.ToString();

        // Lưu điểm vào PlayerPrefs mỗi khi điểm số thay đổi
        // PlayerPrefs.SetInt("DiemCoin", tong);

        // Cập nhật high score nếu cần
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (tong > highScore)
        {
            PlayerPrefs.SetInt("HighScore", tong);
            highScoreText.text = "High Score: " + tong.ToString(); // Cập nhật text high score
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        luongMauHienTai = luongMauToiDa;
        thanhmau.capNhatThanhMau(luongMauHienTai, luongMauToiDa);
        tinhTong(0);
        // Tải điểm từ PlayerPrefs khi game bắt đầu
        // tong = PlayerPrefs.GetInt("DiemCoin", 0); // Giá trị mặc định là 0 nếu chưa có lưu
        // diemText.text = tong.ToString();

         int highScore = PlayerPrefs.GetInt("HighScore", 0); // Load high score
        highScoreText.text = "High Score: " + highScore.ToString(); // Hiển thị high score
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "tao")
        {
            luongMauHienTai += 1;
            thanhmau.capNhatThanhMau(luongMauHienTai, luongMauToiDa);
             Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "trai")
        {
            luongMauHienTai -= 1;
            thanhmau.capNhatThanhMau(luongMauHienTai, luongMauToiDa);
            if (luongMauHienTai <= 0)
            {
                Destroy(this.gameObject);
                Time.timeScale = 0;
                panel1.SetActive(true);
                button.SetActive(true);
                text.SetActive(true);
            }

        }
        if (other.gameObject.tag == "bay")
        {
            luongMauHienTai -= 5;
            thanhmau.capNhatThanhMau(luongMauHienTai, luongMauToiDa);
            if (luongMauHienTai <= 0)
            {
                Destroy(this.gameObject);
                Time.timeScale = 0;
                panel1.SetActive(true);
                button.SetActive(true);
                text.SetActive(true);
            }

        }
        if (other.gameObject.tag == "roi")
        {
            luongMauHienTai -= 1000;
            thanhmau.capNhatThanhMau(luongMauHienTai, luongMauToiDa);
            if (luongMauHienTai <= 0)
            {
                Destroy(GameObject.Find("Player"));
                Time.timeScale = 0;
                panel1.SetActive(true);
                button.SetActive(true);
                text.SetActive(true);
            }

        }
        if (other.gameObject.tag == "tren")
        {
            var name = other.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            // tinhTong(10);
        }
        if (other.gameObject.tag == "coin")
        {

            Destroy(other.gameObject);
            tinhTong(1);
        }
        if (other.gameObject.tag == "an")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "item")
        {
            var name = other.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            Instantiate(PSBrick,
                        other.gameObject.transform.position,
                        other.gameObject.transform.localRotation);
            // tinhTong(20);
        }
        if (other.gameObject.tag == "man")
        {
            panel2.SetActive(true);
            button2.SetActive(true);
            text2.SetActive(true);
        }

    }
}