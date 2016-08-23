using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text scoreText;
    public Text winText;

    private Rigidbody2D rb2d;
    private int count;
    private int totalPickUpElements;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        totalPickUpElements = GameObject.FindGameObjectsWithTag("PickUp").Length;
        count = 0;
        winText.text = "";
        SetScoreText();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb2d.AddForce(new Vector2(moveHorizontal, moveVertical)  * speed);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + count;
        if (count == totalPickUpElements)
        {
            winText.text = "You Win!";
        }
    }
}
