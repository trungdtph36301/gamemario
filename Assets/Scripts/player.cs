using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public thanhMau thanhmau;
    public float luongMauHienTai;
    public float luongMauToiDa = 5;
    void Start()
    {
        luongMauHienTai = luongMauToiDa;
        thanhmau.capNhatThanhMau(luongMauHienTai,luongMauToiDa);
    }

    private void OnMouseDown(){
        luongMauHienTai -= 2;
        thanhmau.capNhatThanhMau(luongMauHienTai,luongMauToiDa);
        if(luongMauHienTai < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
