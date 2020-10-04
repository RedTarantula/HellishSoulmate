using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    
    private static MiniGameController sInstance;
    public static MiniGameController Instance { get => sInstance; }
    
    public delegate void EndGameHandler();
    public delegate void StarGameHandler();
    public event EndGameHandler OnEndGame;
    public event StarGameHandler OnStarGame;

    [SerializeField]
    private float _gameTime = 30f;
    public float GameTime { get => _gameTime; }

    [Header("Spawn")]
    [SerializeField]
    private float _spawnDelay = .5f;
    [SerializeField]
    private List<GameObject> _spawnObjects = default;
    [SerializeField]
    private Vector2 _spawnPointRight = default;
    [SerializeField]
    private Vector2 _spawnPointLeft = default;

    private int _score;
    public int Score { get => _score; }

    private bool _gameIsRunning;
    public bool GameIsRunning { get => _gameIsRunning; }

    void Awake()
    {
        sInstance = this;
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        _gameIsRunning = true;
        OnStarGame?.Invoke();
        StartCoroutine(SpawnCoroutine());
    }

    void EndGame()
    {
        _gameIsRunning = false;
        OnEndGame?.Invoke();
        StopAllCoroutines();
    }

    void Update()
    {
        if (_gameIsRunning)
        {
            _gameTime -= Time.deltaTime;
            if (_gameTime <= 0f)
            {
                EndGame();
            }
        }
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            GameObject spawnPrefab = _spawnObjects[Random.Range(0, _spawnObjects.Count)];
            Vector3 spawnPoint;
            if (Random.value > 0.5f) spawnPoint = _spawnPointRight;
            else spawnPoint = _spawnPointLeft;
            Vector3 direction = new Vector3(Mathf.Sign(-spawnPoint.x), 0f, 0f);

            spawnPoint.y += Random.Range(-3f, 5f);
            
            MiniGameCollectObject collect = Instantiate(spawnPrefab, spawnPoint, Quaternion.identity).GetComponent<MiniGameCollectObject>();
            collect.Construct(direction);
            
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    public void AddScore(int score)
    {
        _score += score;
    }

    public void RemoveTime(float time)
    {
        _gameTime -= time;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_spawnPointRight, Vector3.one);
        Gizmos.DrawWireCube(_spawnPointLeft, Vector3.one);
    }

}
