using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameProjectile : MonoBehaviour
{
    
    public delegate void DestroyHandler();
    public event DestroyHandler OnDestroy;

    [SerializeField]
    private float _moveSpeed = 5f;
    private Rigidbody2D _rigidbody;
    private LineRenderer _lineRenderer;

    private MiniGameCollectObject _collectObject;
    private Vector3 _originPosition;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _lineRenderer.SetPosition(0, transform.position);
        _originPosition = transform.position;
    }

    void Update()
    {
        _lineRenderer.SetPosition(1, transform.position);
        if (_collectObject)
        {
            transform.position = Vector3.MoveTowards(transform.position, _originPosition, _collectObject.PullSpeed * Time.deltaTime);
            if (transform.position == _originPosition)
            {
                Destroy();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MiniGameCollectObject collectObject = collider.GetComponent<MiniGameCollectObject>();
        if (collectObject)
        {
            Destroy(_rigidbody);
            Destroy(GetComponent<Collider2D>());

            _collectObject = collectObject;
            _collectObject.OnGrab();
            _collectObject.transform.parent = transform;
        }
        else
        {
            Destroy();
        }
    }

    void Destroy()
    {
        if (_collectObject) _collectObject.OnPull();
        _collectObject = null;
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }

    public void Throw(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        _rigidbody.velocity = direction * _moveSpeed;
    }

}
