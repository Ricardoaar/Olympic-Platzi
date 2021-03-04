using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TextCategory", menuName = "Configuration/TextCategory", order = 0)]
public class TextCategoryConfiguration : ScriptableObject
{
    public TxtCategory Category;
    public float smallSize;
    public float mediumSize;
    public float bigSize;

    public float GetCurrentSize(TxtSize newTxtSize)
    {
        switch (newTxtSize)
        {
            case TxtSize.Small:
                return smallSize;
            case TxtSize.Medium:
                return mediumSize;
            case TxtSize.Big:
                return bigSize;
            default:
                throw new ArgumentOutOfRangeException(nameof(newTxtSize), newTxtSize, null);
        }
    }
}