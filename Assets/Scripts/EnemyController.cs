using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private LevelController _levelController;
    [SerializeField] private Transform _ball;
    [HideInInspector] public bool IsCatchingBall;
    private float _speed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _levelController = GameObject.FindWithTag("LvlController").GetComponent<LevelController>();
        IsCatchingBall = false;
        SetSpeed(1);
    }

    private void FixedUpdate()
    {
        if (IsCatchingBall)
            CatchBall();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            _levelController.UpdateLvl();
    }

    private void CatchBall()
    {
        if (transform.position.z - _ball.position.z > 0)
        {
            _rigidbody.AddForce(Vector3.back * _speed);
        }
        else
        {
            _rigidbody.AddForce(Vector3.forward * _speed);
        }
    }

    public void SetSpeed(int level)
    {
        _speed = level * 17f;
    }
}
