using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpquai : MonoBehaviour
{
    public Image _hpquai;
    public void capNhatThanhMau(float luongMauHienTai, float luongMauToiDa)
    {
        _hpquai.fillAmount = luongMauHienTai/luongMauToiDa;
    }
}
