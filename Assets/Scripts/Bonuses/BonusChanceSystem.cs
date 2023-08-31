using UnityEngine;

public class BonusChanceSystem : MonoBehaviour 
{

    [SerializeField] protected float _amount;
    [SerializeField] protected float _probabilitty;
    [SerializeField] protected float _ratioExtern;

    protected Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    public float Probabilitty 
    {
        get { return _probabilitty; }
        set { _probabilitty = value; } 
    }

    public float ComputeRatio(float value)
    {
        _ratioExtern = Random.Range(0, value);
        return _ratioExtern;
    }
}
