using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public int speed;
    private int count;
    public Text countText;
    public Text winText;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetUpText();
        winText.text = "";
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb2d.AddForce(new Vector2(moveHorizontal, moveVertical) * speed);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetUpText();
        }
    }

    private void SetUpText()
    {
        countText.text = "x " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
