using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lon : MonoBehaviour
{
    public float left, right;
    private bool isRight;
    public float speed = 1;
    public float trai_phai;
    public hpquai Hpquai;
    public float luongMauHienTai;
    public float luongMauToiDa = 8;
    // Start is called before the first frame update
    void Start()
    {
         luongMauHienTai = luongMauToiDa;
         Hpquai.capNhatThanhMau(luongMauHienTai,luongMauToiDa);
    }

    // Update is called once per frame
    void Update()
    {
        var NamX =  transform.position.x;
        if(NamX < left) {
            isRight = true;
            flip();
        }

        if(NamX > right) {
            isRight = false;
            flip();
        }
        if(isRight) {
            transform.Translate(new Vector3(Time.deltaTime * speed, 0,0));
        } else{
            transform.Translate(-new Vector3(Time.deltaTime * speed,0,0));
        }
        
    }
    void flip()
    {
        
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = kich_thuoc.x * -1;
            transform.localScale = kich_thuoc;
    }

    private void OnTriggerEnter2D(Collider2D heo)
    {
        if (heo.gameObject.tag == "tren")
        {
            luongMauHienTai -= 2;
            Hpquai.capNhatThanhMau(luongMauHienTai, luongMauToiDa);
            if (luongMauHienTai <= 0)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
