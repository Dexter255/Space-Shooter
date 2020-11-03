using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Movement();
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
        else if(transform.position.y < -5.7f)
            transform.position = new Vector3(transform.position.x, 7.65f, 0);
    }
}
