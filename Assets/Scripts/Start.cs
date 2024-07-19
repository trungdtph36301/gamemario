using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
     public void map(){
        SceneManager.LoadScene(2);
    }
    public void thoat(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void exit(){
        Application.Quit();
    }
    public void ReloadManChoi(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    
}
