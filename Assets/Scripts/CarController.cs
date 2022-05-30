using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] bool handControl;
    [SerializeField] SensorScript rightSensor;
    [SerializeField] SensorScript leftSensor;
    [SerializeField] SensorScript backSensor;
    [SerializeField] GameController gameController;

    public float maxSpeed;
    public float maxAngle;

    private float _moveSpeed;
    private float _dmoveSpeed;
 
    private float _angle;
    private float _dangle;

    private Rigidbody2D _rigidbody;

    private Vector2 _movedirection;

    // Unity methods
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movedirection = new Vector2(0, 1);
        _moveSpeed = 2;
        _angle = 1;
        _dmoveSpeed = 0.2f;
        _dangle = 0.1f;
    }

    void Update()
    {
        if (handControl)
        {
            ProcessInputs();
        }
    }

    void FixedUpdate()
    {
       // Debug.Log($"From right: {rightSensor.Distance}");
       // Debug.Log($"From left: {leftSensor.Distance}");
        Rotate();
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.tag == "optional wall")
        {
            bool ce = otherObject.GetComponent<HiderScript>().collisions_enabled;
            if (!ce)
            {
                Physics2D.IgnoreCollision(otherObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                return;
            }
        }
        Debug.Log("Collision");
        gameController.GetComponent<GameController>().RestartLevel();
     
    }

    // Processes user input, used only when handControll = true
    private void ProcessInputs() {
        float speed = Input.GetAxisRaw("Vertical");
        float rotation = -1 * Input.GetAxisRaw("Horizontal");

        if (maxSpeed > Math.Abs(_moveSpeed + speed * _dmoveSpeed)){
            _moveSpeed += speed * _dmoveSpeed;
        }
        if (maxAngle > Math.Abs(_angle + rotation * _dangle)){
            _angle += rotation * _dangle;
        }
    }

    private void Move() {
        _rigidbody.velocity = new Vector2(_movedirection.x * _moveSpeed, _movedirection.y * _moveSpeed);
    }

    private Vector2 RotateVector2(Vector2 v, float degrees)
    {
        return Quaternion.Euler(0, 0, degrees) * v;
    }

    private void Rotate()
    {
        _movedirection = RotateVector2(_movedirection, _angle);
        _rigidbody.rotation += _angle;
    }
}
