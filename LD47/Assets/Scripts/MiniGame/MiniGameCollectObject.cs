using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameCollectObject : MonoBehaviour
{
    
    [SerializeField]
    private int _taps = 5;
    [Header("Speed")]
    [SerializeField]
    private float _pullSpeed = 5f;
    public float PullSpeed { get => _pullSpeed; }
    [SerializeField]
    private float _minSpeed = 4f;
    [SerializeField]
    private float _maxSpeed = 6f;
    [Header("Effects")]
    [SerializeField]
    private GameObject _tapEffet;
    public GameObject TapEffet { get => _tapEffet; }
    [SerializeField]
    private GameObject _openEffet;
    public GameObject OpenEffet { get => _openEffet; }

    private Rigidbody2D _rigidbody;
    private MiniGameTap _miniGameTap;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _miniGameTap = GameObject.FindObjectOfType<MiniGameTap>();
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

    public void OnPull()
    {
        _miniGameTap.Construct(_taps, this);
    }

    public abstract void OnCollect();

}
