using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    #region Runner

    [Header("Runner")]
    public float targetGameVelocity;
    public float initGameVelocity;
    public float initTimeForInput;
    public float initObstacleCreationRate;
    public float minObstacleVel;
    public float maxObstacleVel;
    public int counterOfDodgeClear;
    #endregion
}
