using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private bool _attachedToWood;
    private FruitManager _fruitManager;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _fruitManager = FindObjectOfType<FruitManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wood")) 
        {
            _rigidbody2D.velocity = Vector3.zero;
            transform.parent = collision.transform;
            _attachedToWood = true;
        }
        if (collision.gameObject.CompareTag("Fruit")) 
        {
            Destroy(collision.gameObject);
            _fruitManager.FruitsDestroyed();
        }
        if (collision.gameObject.CompareTag("Gun")) 
        {
            if (collision.gameObject.GetComponent<Knife>()._attachedToWood == true) 
            {
                _rigidbody2D.velocity = Vector3.zero;
                transform.parent = null;
                float bounceForce = 20;
                _rigidbody2D.velocity = Vector3.down + Vector3.left * bounceForce;
            }
        }
    }
    
}
