using UnityEngine;

public class GameEnds : MonoBehaviour
{

    public GameObject panel;
    public MusicController musica;
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
            
            panel.SetActive(true);
            musica.PausarMusica();

        }


    }
}
