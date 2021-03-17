using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private LevelController _levelController;
    [SerializeField] private ParticleSystem _crushEffect;

    private void Start()
    {
        _levelController = GameObject.FindWithTag("LvlController").GetComponent<LevelController>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(_crushEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            _levelController.HitTarget();
        }
    }

    public void SetActive()
    {
        gameObject.SetActive(true);
    }
}
