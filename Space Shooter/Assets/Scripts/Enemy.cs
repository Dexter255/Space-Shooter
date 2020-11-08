using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5.8f)
            transform.position = new Vector3(Random.Range(-12.0f, 12.0f), 5.7f, 0);
            //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player != null)
                player.Damage();
            Destroy(gameObject);
        }
        else if(collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
