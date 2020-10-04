using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameCollectObject : MonoBehaviour
{
    
    [SerializeField]
    private float _pullSpeed = 5f;
    public float PullSpeed { get => _pullSpeed; }
    [SerializeField]
    private float _minSpeed = 4f;
    [SerializeField]
    private float _maxSpeed = 6f;

    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Construct(Vector3 direction)
    {
        _rigidbody.velocity = direction * Random.Range(_minSpeed, _maxSpeed);
    }

    public virtual void OnGrab()
    {
        Destroy(_rigidbody);
        Destroy(GetComponent<Collider2D>());
    }

    public abstract void OnCollect();

}
