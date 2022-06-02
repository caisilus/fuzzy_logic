using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] bool handControl;

    // Sensors
    [SerializeField] private SensorScript rightSensor;
    [SerializeField] private SensorScript leftSensor;
    [SerializeField] private SensorScript backSensor;
    private FinishSensor _finishSensor;

    // For ending the game
    [SerializeField] ButtonsScript gameController;

    // User controlled parameters
    [SerializeField] private float maxSpeed;
    [SerializeField] float maxAngle;
    [SerializeField] float maxdv;

    // Car parameters to determine by AI
    private float _moveSpeed;
    private float _dmoveSpeed;
 
    private float _angle;

    // For car movement
    private Rigidbody2D _rigidbody;

    private Vector2 _movedirection;


    private FuzzyAI ai;

    // Unity methods
    void Start()
    {
        _finishSensor = GetComponent<FinishSensor>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _movedirection = new Vector2(transform.up.x, transform.up.y);
        _moveSpeed = 0.0f;
        _angle = 0f;
        //_dmoveSpeed = 0.3f;
        maxdv = maxSpeed / 8.0f;
        _dmoveSpeed = maxdv;

        AiHub aihub = new AiHub();
        ai = aihub.getAI();
    }

    // Movement
    void FixedUpdate()
    {
        Rotate();
        Move();
    }

    // Input
    void Update()
    {
        if (handControl)
        {
            ProcessInputs();
            GetDetectorsData();
        }
        else {
            float[] input = GetDetectorsData();
            float[] outut = ai.step(input);

            if (Time.timeScale > 0)
                Debug.Log($"Output V {outut[0]}; Output A {outut[1]}");
            float rotation = outut[1];
            float new_dv = outut[0];
            _dmoveSpeed = new_dv * maxdv;
            if (Math.Abs(_moveSpeed + _dmoveSpeed) <= maxSpeed)
            {
                _moveSpeed = _moveSpeed + _dmoveSpeed;
            }
            else
            {
                _moveSpeed = Math.Sign(_moveSpeed) * maxSpeed;
            }
            _angle = rotation * maxAngle;
        }

    }

    private float[] GetDetectorsData(){
        float speed = _moveSpeed / maxSpeed;
        float angle = _angle / maxAngle;
        float rsData = rightSensor.Distance / rightSensor.MaxDistance;
        float lsData = leftSensor.Distance / leftSensor.MaxDistance;
        float bsData = backSensor.Distance / backSensor.MaxDistance;
        float disttofinish = _finishSensor.Distance;
        float angletofinish = _finishSensor.Angle / 180.0f;

        //TODO добавить растояние до цели
        float[] res = new float[]{speed, angle, rsData, lsData, bsData, disttofinish, angletofinish};
        //if (Time.timeScale > 0f)
            ///Debug.Log($"Velocity {speed}; Angle: {angle}; RSensor: {rsData}; LSensor: {lsData}; BSensor: {bsData}, Dist: {disttofinish} Angle_toFin {angletofinish}");
        return res;
    }

    private void ProcessInputs() {
        float speed = Input.GetAxis("Vertical");
        float rotation = -1 * Input.GetAxis("Horizontal");

        if (maxSpeed > Math.Abs(_moveSpeed + speed * _dmoveSpeed)){
            _moveSpeed += speed * _dmoveSpeed;
        }
        _angle = Math.Min(maxAngle, rotation * maxAngle);
    }

    private void Move() {
        //_rigidbody.velocity = new Vector2(_movedirection.x * _moveSpeed, _movedirection.y * _moveSpeed);
        _rigidbody.velocity = _movedirection * _moveSpeed;
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

    // Collisions
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
        gameController.RestartTime();

    }

    public bool IsTurnedBack()
    {
        return _moveSpeed < 0;
    }

    // User defined properties
    public float MaxSpeed
    {
        get { return maxSpeed; }

        set {
            Debug.Log("Setter!");
            maxSpeed = Math.Abs(value);
            maxdv = maxSpeed / 8.0f;
        }
    }

    public float MaxAngle
    {
        get { return maxAngle; }

        set 
        {
            if (value < 0 || value > 180)
                return;
            maxAngle = value;
        }
    }
}
