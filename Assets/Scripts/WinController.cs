using UnityEngine;

public class WinController : MonoBehaviour
{
    public PlayerController playerController;

    private Vector3 startPosition;
    private bool opened = false;

    public float openHeight = 9f;


    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (playerController == null) return;

        if (playerController.llaves >= 3 && !opened)
        {
            opened = true;
        }

        if (opened)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                startPosition + Vector3.up * openHeight,
                5f * Time.deltaTime
            );
        }
        else
        {
            transform.position = startPosition;
        }


    }

    public void ResetBarrier()
    {
        opened = false;
        transform.position = startPosition;
    }
}
