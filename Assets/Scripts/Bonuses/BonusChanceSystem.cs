using UnityEngine;

public class BonusChanceSystem
{
    protected float probabilitty;
    protected float ratioExtern;

    public float Probabilitty 
    {
        get { return probabilitty; }
        set { probabilitty = value; } 
    }

    public float ComputeRatio(float value)
    {
        ratioExtern = Random.Range(0, value);
        return ratioExtern;
    }
}
