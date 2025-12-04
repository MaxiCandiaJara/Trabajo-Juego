using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
public class RespawnController : MonoBehaviour
{

    public PlayerController me;
    public Transform t;

    bool inrespawn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
void Update() { 
    if (me.death == true && inrespawn == false){ 
        inrespawn = true;
        StartCoroutine(Esperar()); 
    } 
} 

IEnumerator Esperar() { 
    yield return new WaitForSeconds(3f); 
    Spawn(); 
} 

public void Spawn() { 
    

    transform.position = t.position;
    me.Revivir();
    inrespawn = false;

}

}
