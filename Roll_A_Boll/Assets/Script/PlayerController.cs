using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text score;
    public Text win;

    private Rigidbody rb;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        win.text = "";
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
            count += 200;
            SetCountText();
        }
    }
    void SetCountText()
    {
        score.text = "Score : " + count.ToString();
        if(count >= 2600)
        {
            win.text = "You Win!";
            Invoke("ScenLoad", 3f);
        }
    }
    void ScenLoad()
    {
        SceneManager.LoadScene("Level2");
    }
}
