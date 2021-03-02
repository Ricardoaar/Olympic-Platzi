using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public static class Util
{
    /// <summary>
    /// Encuentra el valor de un angulo a partir de un Vector
    /// </summary>
    /// <param name="lAngle"></param>
    /// <returns></returns>
    public static Vector3 GetVectorFromAngle(float lAngle)
    {
        var angleRad = lAngle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    /// <summary>
    /// Retorna el angulo de un vector
    /// </summary>
    /// <param name="lVector"></param>
    /// <returns></returns>
    public static float GetAngleFromVector(Vector3 lVector)
    {
        lVector = lVector.normalized;
        var n = Mathf.Atan2(lVector.y, lVector.x) * Mathf.Rad2Deg;
        n += n < 0 ? 360 : 0;
        return n;
    }

    /// <summary>
    /// A faster fibonacci recursive function
    /// </summary>
    /// <param name="n">Fibonacci number to get</param>
    /// <returns> f(n) </returns>
    public static int Fibonacci(int n)
    {
        switch (n)
        {
            case 0:
                return 0;
            case 1:
            case 2:
                return 1;
        }

        if (n % 2 == 0) return Fibonacci(n / 2) * (Fibonacci(n / 2 + 1) + Fibonacci(n / 2 - 1));

        int n1, n2;
        n1 = Fibonacci((n + 1) / 2);
        n2 = Fibonacci((n - 1) / 2);

        return n1 * n1 + n2 * n2;
    }

    /// <summary>
    /// Convert a linear value to a logarithmic.
    /// </summary>
    /// <param name="value">Linear value to convert.</param>
    /// <returns>Logarithmic value.</returns>
    public static float LinearToLogarithmic(float value) => Mathf.Log10(value) * 20;

    // ReSharper disable once UnusedMember.Local
    public static float GetAngleFromTwoVectors(Vector3 origin, Vector3 destiny)

    {
        var x = Mathf.Abs(origin.x - destiny.x);

        var y = Mathf.Abs(origin.x - destiny.x);

        return Mathf.Atan2(x, y);
    }


    #region Color Effect

    public static Color InterpolateFade(bool goOn, SpriteRenderer spriteFade, float fadeDifference = 0.01f)
    {
        return new Color(spriteFade.color.r, spriteFade.color.g, spriteFade.color.b,
            spriteFade.color.a + (goOn ? fadeDifference : -fadeDifference));
    }

    public static Color InterpolateFade(bool goOn, Image imageFade, float fadeDifference = 0.01f)
    {
        return new Color(imageFade.color.r, imageFade.color.g, imageFade.color.b,
            imageFade.color.a + (goOn ? fadeDifference : -fadeDifference));
    }

    #endregion
}