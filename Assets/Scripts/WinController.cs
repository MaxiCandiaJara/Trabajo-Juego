using UnityEngine;

public class WinController : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.llaves >= 3)
        {
            transform.position += Vector3.up * 5f * Time.deltaTime;
        }
    }
}
