using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KnifeThrower : MonoBehaviour
{
    public float ThrowForce;
    public GameObject KnifePrefab;
    public GameManager GameManager;

    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private GameObject _knife;
    private List<GameObject> _knives = new List<GameObject>();
    private List<GameObject> _spawnedKnives = new List<GameObject>();


    private void Start()
    {
        _transform = GetComponent<Transform>();
        _knife = Instantiate(KnifePrefab, _transform);

    }
    private void Update()
    {
        KnifeThrowLogic();
    }
    public void KnifeThrowLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newKnife = Instantiate(KnifePrefab, _transform);
            newKnife.transform.parent = null;
            Rigidbody2D newKnifeRB = newKnife.GetComponent<Rigidbody2D>();
            newKnifeRB.velocity = Vector3.up * ThrowForce;

            GameManager.OnKnifeThrown(newKnife);
        }
    }
    
}