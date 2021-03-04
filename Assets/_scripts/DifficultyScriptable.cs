using UnityEngine;


public enum Difficult
{
    easy,
    hard
}

[CreateAssetMenu(fileName = "Difficulty")]
public class DifficultyScriptable : ScriptableObject
{
    #region General

    [Header("General")] public Difficult difficult;

    #endregion

    #region Runner

    [Header("Runner")] public float targetGameVelocity;
    public float initTimeForInput;
    public float initObstacleCreationRate;
    public float minObstacleVel;
    public float maxObstacleVel;

    #endregion

    [Header("Platform")] public int maxGhostInScene;
    public float ghostVelocity;
}