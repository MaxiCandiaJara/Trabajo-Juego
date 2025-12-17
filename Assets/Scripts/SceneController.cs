using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{   

    public string scena;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
           Cargar(scena);

        }
    }


    public void Cargar(String Escena)
    {
        
        SceneManager.LoadScene(Escena);
    }

    public void Salir()
    {
        
        Application.Quit();

    }
}
