using UnityEngine;

public class GhostSpawnSystem : ExtraAction
{
    [SerializeField] private ObjectPool ghostPool;
    [SerializeField] private BoxCollider2D limitLeft, limitRight;
    public static GhostSpawnSystem Instance;

    [SerializeField, Range(5, 15)] private int maxEnemiesInScene;
    private int _currentEnemiesInScene;
    private float _currentTime;

    private float _timeBetweenGhost;
    [SerializeField, Range(0, 5)] private float minTimeBetweenGhost, maxTimeBetweenGhost;
    private bool _canCreateGhost;

    private void Update()
    {
        if (!_canCreateGhost) return;

        if (_currentEnemiesInScene < maxEnemiesInScene && _currentTime > _timeBetweenGhost)
        {
            _timeBetweenGhost = Random.Range(minTimeBetweenGhost, maxTimeBetweenGhost);
            _currentTime = 0;
            ActivateGhost(Random.Range(2, 5));
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }

    private void Awake()
    {
        //   _canCreateGhost = false;
        _currentTime = -2;
        _currentEnemiesInScene = 0;
        _timeBetweenGhost = 2;
        _canCreateGhost = false;
        Instance = Instance == null ? this : Instance;
    }


    public Vector3 GetRandomPos(bool max)
    {
        return max
            ? new Vector3(Random.Range(limitRight.bounds.min.x, limitRight.bounds.max.x),
                Random.Range(limitRight.bounds.min.y, limitRight.bounds.max.y))
            : new Vector3(Random.Range(limitLeft.bounds.min.x, limitLeft.bounds.max.x),
                Random.Range(limitLeft.bounds.min.y, limitLeft.bounds.max.y));
    }


    private void OnEnable()
    {
        GameManagePlatform.OnReloadGame += RestartGhostSpawner;
        PlatPlayerInteractive.OnDamage += CanCreateGhost;
        GameManagePlatform.OnWinScene += CanCreateGhost;
    }

    private void CanCreateGhost()
    {
        _canCreateGhost = !_canCreateGhost;
    }

    private void OnDisable()
    {
        GameManagePlatform.OnReloadGame -= RestartGhostSpawner;
        PlatPlayerInteractive.OnDamage -= CanCreateGhost;
        GameManagePlatform.OnWinScene -= CanCreateGhost;
    }


    private void RestartGhostSpawner()
    {
        CanCreateGhost();
        _currentTime = -2;
        _currentEnemiesInScene = 0;
        _timeBetweenGhost = 2;
    }


    private void ActivateGhost(int quantity)
    {
        if (_currentEnemiesInScene + quantity > maxEnemiesInScene)
        {
            quantity = maxEnemiesInScene - _currentEnemiesInScene;
        }

        _currentEnemiesInScene += quantity;

        for (int i = 0; i < quantity; i++)
        {
            var currentGhost = ghostPool.ExtractFromQueue();
            currentGhost.transform.position = GetRandomPos(Random.Range(0, 1.0f) > 0.5f);
            currentGhost.SetActive(true);
        }
    }


    public void OnGhostDisable(GameObject ghost)
    {
        if (_currentEnemiesInScene > 0)
        {
            _currentEnemiesInScene -= 1;
        }

        ghost.transform.SetParent(transform);
        ghost.gameObject.SetActive(false);
        ghostPool.EnqueueObj(ghost);
    }

    public override void DoAction()
    {
        _canCreateGhost = true;
    }
}