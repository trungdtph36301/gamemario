using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vẽ coin theo hình sin
// Mỗi 5s thì vẽ một lần
// Xóa coin bị bỏ qua


public class sinhCoin : MonoBehaviour
{
    public Transform _player; //ánh xạ tới nhân vật
    public GameObject _coin; //ánh xạ tới prefab coin
    public float _nextPosX;
    public float _nextPosY; //Vị trí sẽ sinh ra coin
    private float _khoangCach; //Khoảng cách coin cách ra với người chơi
    //độ cong hình sin
    public float _chieuCaoSin;
    public float _doRongSin;
    public float _chieuCao; //chiều cao so với mặt đất của coin
    public float _chieuCaoToiThieu;
    public float _thoiGian; //Bao lâu vẽ coin 1 lần
    public int _soLuongCoin; //Số lượng coin mỗi lần vẽ ra

    public float _timer; //Theo dõi thời gian

    void Start()
    {
        _khoangCach = 20f;
        _chieuCaoToiThieu = 4f;
        _thoiGian = 5f;
        _soLuongCoin = 3;
        _timer = 0;
        veCoin();

    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _thoiGian) {
            veCoin();
            _timer = 0;
        }
    }

    private void veCoin()
    {
        _chieuCao = Random.Range(1f, 2f) + _chieuCaoToiThieu;
        _chieuCaoSin = 3.5f;
        _doRongSin = 3.5f;
        //_doCong = Random.Range(0.8f, 1.2f);
        _nextPosX = _player.position.x + _khoangCach;
        for (int i = 0; i < _soLuongCoin; i++) { 
            _nextPosY = Mathf.Abs(_chieuCaoSin * Mathf.Sin(_nextPosX/ _doRongSin)) + _chieuCao;
            Instantiate(_coin, new Vector3(_nextPosX, _nextPosY, 0f), Quaternion.identity, transform);
            _nextPosX ++;
        }
    }
}
