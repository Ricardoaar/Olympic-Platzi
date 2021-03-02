using UnityEngine;

public class GhostSpawnSystem : MonoBehaviour
{
    [SerializeField] private ObjectPool ghostPool;
    [SerializeField] private BoxCollider2D limitLeft, limitRight;
    [SerializeField] private GameObject target;
    public static GhostSpawnSystem Instance;


    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    private void Start()
    {
        ActivateGhost();
        ActivateGhost();
        ActivateGhost();
    }

    public Vector3 GetRandomPos(bool max)
    {
        return max
            ? new Vector3(Random.Range(limitRight.bounds.min.x, limitRight.bounds.max.x),
                Random.Range(limitRight.bounds.min.y, limitRight.bounds.max.y))
            : new Vector3(Random.Range(limitLeft.bounds.min.x, limitLeft.bounds.max.x),
                Random.Range(limitLeft.bounds.min.y, limitLeft.bounds.max.y));
    }

    private Random _random;

    private void OnEnable()
    {
        GameManagePlatform.OnReloadGame += TestActive;
        InvokeRepeating(nameof(ActivateGhost), 5, 2);
    }

    private void OnDisable()
    {
        GameManagePlatform.OnReloadGame -= TestActive;
    }

    private void TestActive()
    {
        for (int i = 0; i < 3; i++)
        {
            ActivateGhost();
        }
    }


    private void ActivateGhost()
    {
        var currentGhost = ghostPool.ExtractFromQueue();
        currentGhost.transform.position = GetRandomPos(Random.Range(0, 1.0f) > 0.5f);
        currentGhost.SetActive(true);
    }
}