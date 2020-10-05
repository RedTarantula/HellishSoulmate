using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameThrower : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _projectilePrefab = default;
    [SerializeField]
    private GameObject _holdSprite = default;

    private MiniGameProjectile _projectileCreated;
    private bool _canFire;

    private Camera _mainCamera;
    private MiniGameController _controller;

    public bool IsActive;

    void Awake()
    {
        _mainCamera = Camera.main;
        _canFire = true;
    }
    
    void Start()
    {
        _controller = MiniGameController.Instance;
    }

    void Update()
    {
        if (!IsActive) return;
        if (!_controller.GameIsRunning) return;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    void Fire()
    {
        if (!_canFire) return;

        Vector3 clickPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0f;
        if (clickPosition.y < transform.position.y) return;

        Vector3 direction = (clickPosition - transform.position).normalized;
        _projectileCreated = Instantiate(_projectilePrefab, transform.position, Quaternion.identity).GetComponent<MiniGameProjectile>();
        _projectileCreated.Throw(direction);
        _projectileCreated.OnDestroy += HandleProjectileDestroy;

        _canFire = false;
        _holdSprite.SetActive(false);
    }

    void HandleProjectileDestroy()
    {
        _canFire = true;
        _holdSprite.SetActive(true);
    }

}
