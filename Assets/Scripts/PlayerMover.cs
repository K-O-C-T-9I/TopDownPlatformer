using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const int SPEED_COEFICIENT = 50;
    private const string HORIZONTAL_AXE = "Horizontal";
    private const string VERTICAL_AXE = "Vertical";

    [SerializeField] private int _moveSpeed = 2;
    [SerializeField] private int _dashForced = 2000;

    private Rigidbody2D _rigidbody;
    private float _directionHorizontal;
    private float _directionVertical;
    private bool _isDash = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _directionHorizontal = Input.GetAxis(HORIZONTAL_AXE);

        _directionVertical = Input.GetAxis(VERTICAL_AXE);

        if ((_directionHorizontal != 0 || _directionVertical != 0) && Input.GetKeyDown(KeyCode.Space))
        {
            _isDash = true;
        }
    }


    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_directionHorizontal * SPEED_COEFICIENT * Time.fixedDeltaTime * _moveSpeed, _directionVertical * SPEED_COEFICIENT * Time.fixedDeltaTime * _moveSpeed);

        if (_isDash == true)
        {
            _rigidbody.AddForce(new Vector2(_dashForced * _directionHorizontal, _dashForced * _directionVertical));
            _isDash = false;
        }
    }
}
