using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BobController : MonoBehaviour, IPlayer
{
    public event Action OnKilled;

    [Header("Settings")]

    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _jumpButton;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpMax;
    [SerializeField] private float _dumpingSpeed;

    private int _jumpCount;
    private int _totalScore;

    [Header("Components")]

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteBob;
    [SerializeField] private Camera _camera;

    private void TotalScore()
    { 
        _totalScore = Mathf.Max(_totalScore, (int)gameObject.GetComponent<BobController>().transform.position.y);
        Debug.Log("Score " + _totalScore);
    }


    void Start()
    {
        
    }

    void Update()
    {
        TotalScore();
        Move();
        Jump();        
    }

    private void FixedUpdate()
    {
        _camera.transform.position = Vector3.Lerp(new Vector3(_camera.transform.position.x, _camera.transform.position.y, -10), transform.position, Time.deltaTime * _dumpingSpeed);
    }


    public void MakeDamage()
    {
        _rb.AddForce(Vector2.up * _jumpForce);
        GetComponent<Collider2D>().isTrigger = true;
        enabled = false;


        OnKilled?.Invoke();
    }


    private void Move()
    {
        float inputDir = Input.GetAxis("Horizontal");

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + inputDir, transform.position.y), Time.deltaTime * _moveSpeed);

        if (inputDir < 0)
        { 
            _spriteBob.flipX = true;
        }
        else if (inputDir > 0)
        {
            _spriteBob.flipX = false;
        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(_jumpButton) && _jumpCount < _jumpMax)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
            _jumpCount++;
        }
        if (_jumpCount != 0)
        {
            _animator.SetFloat("MoveSpeed", 0f);   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _jumpCount = 0;
    }
}
