using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float movementSpeed;

    void Update() {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        if(transform.position.x < -24) {
            Destroy(gameObject);
        }
    }

}
