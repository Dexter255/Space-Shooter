using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.2f;
    private float _nextFire = 0.0f;
    [SerializeField] private int _lives = 3;
    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
            Debug.Log("Spawn Manager is NULL");
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
            FireLaser();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0);
        transform.Translate(movement * _speed * Time.deltaTime);

        if (transform.position.x < -13.3f)
            transform.position = new Vector3(13.3f, transform.position.y, 0);
        else if (transform.position.x > 13.3f)
            transform.position = new Vector3(-13.3f, transform.position.y, 0);

        if (transform.position.y > 7.65f)
            transform.position = new Vector3(transform.position.x, -5.7f, 0);
        else if (transform.position.y < -5.7f)
            transform.position = new Vector3(transform.position.x, 7.65f, 0);
    }

    private void FireLaser()
    {
        _nextFire = Time.time + _fireRate;

        Vector3 position = new Vector3(transform.position.x, transform.position.y + 1, 0);
        Instantiate(_laserPrefab, position, Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }
}
