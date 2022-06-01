using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NPCCarController : MonoBehaviour
{
    [SerializeField] bool superMegaSpeed;
    [SerializeField] bool leftMoveDir;
    [SerializeField] float maxSpeed;

    static private float xBorderRadius = 50;

    private float _moveSpeed;

    private Rigidbody2D _rigidbody;

    private Vector2 _movedirection;

    // Unity methods
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //setMoveDir(leftMoveDir);
        _moveSpeed = UnityEngine.Random.Range(2, maxSpeed);
        if (superMegaSpeed)
        {
            _moveSpeed = 10;
        }
        Debug.Log("AI car moveSpeed = " + _moveSpeed);
    }

    public void setMoveDir(bool isLeft)
    {
        if (isLeft)
        {
            _movedirection = new Vector2(-1, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            _movedirection = new Vector2(1, 0);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
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
    }

    void FixedUpdate()
    {
        if (Math.Abs(transform.localPosition.x) > xBorderRadius)
        {
            Destroy(gameObject);
        }
        Move();
    }

    private void Move() {
        _rigidbody.velocity = new Vector2(_movedirection.x * _moveSpeed, _movedirection.y * _moveSpeed);
    }

}
