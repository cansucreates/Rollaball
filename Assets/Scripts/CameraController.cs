using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; // The distance between the player and the camera


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position; // camera position - player position
    }

    void LateUpdate() // LateUpdate is called after all Update functions have been called
    {
        transform.position = player.transform.position + offset; // camera position = player position + offset
    }
}
