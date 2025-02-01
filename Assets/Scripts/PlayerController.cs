using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody component of the player
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    private int count;
    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); // Create a movement vector
        rb.AddForce(movement * speed);
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false); // Deactivate the pickup object
            count++;
            SetCountText();
        }   
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>(); // Get the movement vector from the input
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();

        if (count >= 9) {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Game Over!";
        }
    }

}
