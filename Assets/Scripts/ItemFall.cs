using System.Collections;
using UnityEngine;

public class ItemFall : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;
    [SerializeField] private Transform _maxSpawnPos;
    [SerializeField] private Transform _minSpawnPos;
    [SerializeField] private float _timeToSpawn = 3f;

    private int _randomItems;
    private Vector2 _randomPosition;

    public Score _scoreScr;
    public Movement _movementScr;

    private void Start()
    {
        StartCoroutine(IntervalSpawn());
    }

    private void Update()
    {
        switch (_scoreScr._score)
        {
            case 10:
                _timeToSpawn = 2.5f;
                break;
            case 25:
                _timeToSpawn = 2f;
                break;
            case 40:
                _timeToSpawn = 1.45f;
                _movementScr._speed = 0.8f;
                break;
            case 60:
                _timeToSpawn = 1.25f;                
                break;           
        }
        if(_scoreScr._score >= 80)
        {
            _movementScr._speed = 0.8f;
            _timeToSpawn = 0.9f;
        }
    }
 
    private void SpawnItem()
    {
        _randomItems = Random.Range(0, _items.Length);
        _randomPosition.x = Random.Range(_minSpawnPos.position.x, _maxSpawnPos.position.x);
        _randomPosition.y = 14;
        Instantiate(_items[_randomItems], _randomPosition, transform.rotation);
    }

    private void RepeatSpawn()
    {
        StartCoroutine(IntervalSpawn());
    }

    private IEnumerator IntervalSpawn()
    {
        yield return new WaitForSeconds(_timeToSpawn);
        SpawnItem();
        RepeatSpawn();
    }
}










