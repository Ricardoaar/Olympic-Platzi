using UnityEngine;


public enum Difficult
{
    easy,
    hard
}

[CreateAssetMenu(fileName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    #region General

    [Header("General")] public Difficult difficult;

    #endregion

    #region Runner

    [Header("Runner")]
    public float targetGameVelocity;
    public float initGameVelocity;
    public float initObstacleCreationRate;
    public float minObstacleVel;
    public float maxObstacleVel;
    public int counterOfDodgeClear;
    public int limitForButtons;
    #endregion

    [Header("Platform")] public int maxGhostInScene;
    public float ghostVelocity;
}