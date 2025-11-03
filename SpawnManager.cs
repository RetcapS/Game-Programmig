using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private float _spawnRate = 3f;
    private bool _stopSpawning = false;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, _spawnRate);
    }

    void SpawnEnemy()
    {
        if (_stopSpawning) return;
        float x = Random.Range(-8f, 8f);
        GameObject enemy = Instantiate(_enemyPrefab, new Vector3(x, 7f, 0), Quaternion.identity);
        enemy.transform.parent = _enemyContainer.transform;
    }

    public void StopSpawning()
    {
        _stopSpawning = true;
        CancelInvoke(nameof(SpawnEnemy));
    }
}