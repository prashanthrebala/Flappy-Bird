using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Vector3 velocity;
    public float gravity;
    public float strength;
    private int spriteIndex;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            velocity = Vector3.up * strength;
        }   
        velocity.y += gravity * Time.deltaTime;
        this.transform.position += velocity * Time.deltaTime;
        if(velocity.y < -4.5) { // down
            this.transform.rotation = Quaternion.Euler(0, 0, -25);
        } else if (velocity.y > 0) { // up
            this.transform.rotation = Quaternion.Euler(0, 0, 25);
        } else {
            this.transform.rotation = Quaternion.identity;
        }
    }

    private void AnimateSprite() {
        spriteIndex++;
        if(spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        GameManager gameManager = FindObjectOfType<GameManager>();

        if(collider.gameObject.tag == "Obstacle") {
            gameManager.GameOver();
        } else if (collider.gameObject.tag == "ScoreZone") {
            gameManager.IncreaseScore();
        }
    }

}
