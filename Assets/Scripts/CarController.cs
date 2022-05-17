using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public bool handControl;

    public float maxSpeed;
    public float moveSpeed;
    public float dmoveSpeed;

    public float maxAngle;
    public float angle;
    public float dangle;

    public Rigidbody2D rb;
    public GameObject gameController;

    

    private Vector2 movedirection;

    // Start is called before the first frame update
    void Start()
    {
        movedirection = new Vector2(0, 1);
    }

    void ProcessInputs() {
        float speed = Input.GetAxisRaw("Vertical");
        float rotation = -1 * Input.GetAxisRaw("Horizontal");

        if (maxSpeed > Math.Abs(moveSpeed + speed * dmoveSpeed)){
            moveSpeed += speed * dmoveSpeed;
        }
        if (maxAngle > Math.Abs(angle + rotation * dangle)){
            angle += rotation * dangle;
        }
    }

    void Move() {
        rb.velocity = new Vector2(movedirection.x * moveSpeed, movedirection.y * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (handControl){
            ProcessInputs();
        }
    }

    private void FixedUpdate() {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        movedirection = RotateVector2(movedirection, angle);
        rb.rotation += angle;
    }

    public Vector2 RotateVector2(Vector2 v, float degrees)
    {
        return Quaternion.Euler(0, 0, degrees) * v;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "wall"){
            Debug.Log("Collision");
            gameController.GetComponent<GameController>().RestartLevel();
        }
    }


}
