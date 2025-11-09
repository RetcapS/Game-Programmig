using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class PlayerSc : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.25f;
    private float _canFire = -1f;
    [SerializeField] private int _lives = 3;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] bool isTripleShotActive = false;    //
    [SerializeField] GameObject tripleLaserPrefab;

    private const float Y_MIN = -3.8f, Y_MAX = 0f, X_MIN = -11.3f, X_MAX = 11.3f;

    void Awake()
    {
        if (_spawnManager == null)
            _spawnManager = FindFirstObjectByType<SpawnManager>();
    }

    void Start()
    {
        transform.position = new Vector3(-2, 0, 0);
    }

    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
            FireLaser();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        transform.Translate(dir * _speed * Time.deltaTime);

        float y = Mathf.Clamp(transform.position.y, Y_MIN, Y_MAX);
        float x = transform.position.x;
        if (x > X_MAX) x = X_MIN;
        else if (x < X_MIN) x = X_MAX;

        transform.position = new Vector3(x, y, 0);
    }

   void FireLaser()
{
    _canFire = Time.time + _fireRate;  

    if (isTripleShotActive)
    {
        Instantiate(tripleLaserPrefab, transform.position + Vector3.up * 0.8f, Quaternion.identity);  // Üçlü atış
    }
    else
    {
        Instantiate(_laserPrefab, transform.position + Vector3.up * 0.8f, Quaternion.identity);  // Tek atış
    }
}
    public void Damage()
    {
        _lives--;
        if (_lives < 1)
        {
            _spawnManager?.StopSpawning();
            Destroy(gameObject);
        }
    }
    public void TripleShootActive() //
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotCancelRoutuine());
    }
    IEnumerator TripleShotCancelRoutuine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }
   
}