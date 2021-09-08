using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text ScoreTxt;
    public Canvas next;
    public RawImage star1, star2, star3;

    private Rigidbody rb;
    private float count;
    private float score;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        next.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            score += 200;
            SetCountText();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            score -= 100;
            SetCountText();
        }
    }
    void SetCountText()
    {
        ScoreTxt.text = "Score : " + score.ToString();
        if(count >= 13)
        {
            next.gameObject.SetActive(true); 
            StarPainted();
            Time.timeScale = 0;
        }
    }
    void StarPainted()
    {
        if(score >= 2600)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
        }
        if (score <= 2500 )
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(false);
        }
        if (score <= 1900)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
        if (score <= 1300)
        {
            star1.gameObject.SetActive(false);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
    }
}
