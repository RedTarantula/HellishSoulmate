using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnItem
{
    public GameObject Prefab;
    public int Chance;
}

public class MiniGameController : MonoBehaviour
{
    
    private static MiniGameController sInstance;
    public static MiniGameController Instance { get => sInstance; }
    
    public delegate void EndGameHandler();
    public delegate void StarGameHandler();
    public event EndGameHandler OnEndGame;
    public event StarGameHandler OnStarGame;

    [SerializeField]
    private Stats _stats = default;

    [SerializeField]
    private float _gameTime = 30f;
    public float GameTime { get => _gameTime; }

    [Header("Spawn")]
    [SerializeField]
    private float _spawnDelay = .5f;
    [SerializeField]
    private List<SpawnItem> _spawnObjects = default;
    [SerializeField]
    private Vector2 _spawnPointRight = default;
    [SerializeField]
    private Vector2 _spawnPointLeft = default;

    private AudioSource _audioSource;

    private int _score;
    public int Score { get => _score; }

    private int _presents;
    public int Presents { get => _presents; }

    public int Tickets { get => Mathf.RoundToInt((_score / 5f) * (_presents + 1)); }

    private bool _gameIsRunning;
    public bool GameIsRunning { get => _gameIsRunning; }

    void Awake()
    {
        sInstance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        _gameIsRunning = true;
        OnStarGame?.Invoke();
        StartCoroutine(SpawnCoroutine());
    }

    void EndGame()
    {
        _gameIsRunning = false;
        _stats.tickets += Tickets;
        OnEndGame?.Invoke();
        StopAllCoroutines();
        StartCoroutine(MuteSoundCoroutine());
    }

    IEnumerator MuteSoundCoroutine()
    {
        float value = _audioSource.volume;
        while (value >= 0f)
        {
            value -= Time.deltaTime;
            _audioSource.volume = value;
            yield return null;
        }
        _audioSource.Stop();
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
            GameObject spawnPrefab = GetSpawnPrefab();
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
    

	/// <summary>Get an item from the drop table.</summary>
	/// <returns>Returns the item prefab OR null if none is dropped.</returns>
    public GameObject GetSpawnPrefab()
    {
        int itemsAmountSum = 0;
        foreach (SpawnItem item in _spawnObjects)
        {
            itemsAmountSum += item.Chance;
        }

        int dropAmount = Random.Range(0, itemsAmountSum);
        foreach (SpawnItem item in _spawnObjects)
        {
            if(dropAmount <= item.Chance)
            {
                return item.Prefab;
            }

            dropAmount -= item.Chance;
        }

        return null;
    }

    public void AddScore(int score)
    {
        _score += score;
    }

    public void AddPresents(int presents)
    {
        _presents += presents;
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
