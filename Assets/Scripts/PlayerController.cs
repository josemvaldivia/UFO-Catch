using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreText;
    public Text winText;

    private int score;
    private string scoreFormat;
    private int winScore;

    void Start()
    {
        score = 0;
        scoreFormat = scoreText.text;
        SetScoreText();
        winText.gameObject.SetActive(false);
        winScore = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector2(moveHorizontal, moveVertical);
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(movement * speed);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
            if (score >= winScore)
            {
                winText.gameObject.SetActive(true);
            }
        }
    }

    void SetScoreText()
    {
        scoreText.text = string.Format(scoreFormat, score);
    }
}
