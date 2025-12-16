using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    
    public float speed;
    public float jump;

    public Rigidbody2D rb;
    public Animator an;

    public AudioSource au;
    public AudioClip[] effects;

    float x;
    bool grounded = false;
    bool inpunch = false;
    public bool death = false;
    int vidas = 5;
    public int llaves = 0;

    List<GameObject> allKeys = new List<GameObject>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        an.GetComponent<Animator>();
        au.GetComponent<AudioSource>();

        GameObject[] keysInScene = GameObject.FindGameObjectsWithTag("Key");
        allKeys.AddRange(keysInScene);
    }


    // Update is called once per frame
    void Update()
    {   
        if (!death){

            x = Input.GetAxis("Horizontal");
            Mover();
            Animar();
        }




    }



    void Mover()
    {

        if (!inpunch){
            if (grounded)
            {
            rb.linearVelocityX = x * speed;
            }
            if (!grounded)
            {
            rb.linearVelocityX = x * (speed/1.5f);
            }
        }
  

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if(grounded)
            {
                rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                an.SetTrigger("Jump");
                AudioClip efecto = BuscarCancion("Jump");

                au.clip = efecto;
                au.Play();
            }

        }

    }

    void Animar()
    {   
        an.SetBool("Grounded", grounded);
        an.SetFloat("AirSpeedY", rb.linearVelocityY);

        if(x > 0)
        {     
            transform.localScale = new Vector3(1,1,1);
        }

        if(x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        if(x != 0)
        {
            an.SetInteger("AnimState", 1);  
        } 

        if(x == 0)     
        {
            an.SetInteger("AnimState", 0);
        }

        if (vidas <= 0 && death == false)
        {   
            
            AudioClip efecto = BuscarCancion("Death");

            au.clip = efecto;
            au.Play();
            
            death = true;
            an.SetTrigger("Death");

            rb.linearVelocity = new Vector2(0,0);

        }

        

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Floor")
        {
            grounded = true;
        }

        if (collision.tag == "Key")
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<Collider2D>().enabled = false;

            llaves += 1;
            Debug.Log("Llaves actuales: " + llaves);

            AudioClip efecto = BuscarCancion("Key");
            au.clip = efecto;
            au.Play();
        }




    }
    
    private AudioClip BuscarCancion(string nombreCancion)
    {
        foreach (AudioClip cancion in effects)
        {
            if (cancion != null && cancion.name.Equals(nombreCancion, System.StringComparison.OrdinalIgnoreCase))
            {
                return cancion;
            }
        }
        return null;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Floor")
        {
            grounded = false;
        }
    }


    public void Golpe()
    {   
        if(!death){

            AudioClip efecto = BuscarCancion("Pain");
            au.clip = efecto;
            au.Play();

            an.SetTrigger("Hurt");
            inpunch = true;
            vidas -= 1;
            Invoke("Recuperarse", 0.25f);
        }
    


    }

    void Recuperarse()
    {
        
        inpunch = false;

    }

    public void Revivir()
    {
        vidas = 5;
        llaves = 0;
        death = false;
        grounded = false;

        an.SetTrigger("Respawn");

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0;

        foreach (GameObject key in allKeys)
        {
            if (key != null)
            {
                key.GetComponent<SpriteRenderer>().enabled = true;
                key.GetComponent<Collider2D>().enabled = true;
            }
        }

        WinController barrier = FindFirstObjectByType<WinController>();
        if (barrier != null)
        {
            barrier.ResetBarrier();
        }

        Debug.Log("Revivir ejecutado");
    }


}

