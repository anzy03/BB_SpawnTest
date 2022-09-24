using System;
using UnityEngine;
using Random = UnityEngine.Random;
[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyType")]
public class EnemyAttributes : ScriptableObject
{
    public EnemyType Type;
    public EnemyClass Class;
    public int AttackPower;
    public int Health;
    public int Speed;
    public float SpawnRate;
    public Color EnemyColor;

    private void Awake()
    {
        ModifyValuesBasedOnTime(TimeManager.TimeofDay);
    }
    private void ModifyValuesBasedOnTime(DayCycle time)
    {
        switch (time)
        {
            case DayCycle.Morning:
                {
                    if (Class == EnemyClass.Archers) SpawnRate += Random.Range(0.2f, 0.4f);
                    if (Type == EnemyType.Brown) SpawnRate -= Random.Range(0.1f, 0.3f);
                }
                break;
            case DayCycle.Afternoon:
                {
                    switch (Class)
                    {
                        case EnemyClass.Assassins:
                            SpawnRate = 0.0f;
                            break;
                        case EnemyClass.Grunt:
                            AttackPower += 1;
                            break;
                        default:
                            SpawnRate += Random.Range(-0.2f, 0.2f);
                            break;
                    }
                }
                break;
            case DayCycle.Night:
                {
                    if (Class == EnemyClass.Assassins) Speed += Random.Range(0, 2);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(time), time, null);
        }
    }
}

public enum EnemyClass : byte
{
    Grunt = 0,
    Archers = 2,
    Assassins = 3,
}
public enum EnemyType : byte
{
    Red = 0,
    Brown = 2,
    Blue = 3,
    Green = 4,
    Yellow = 5,
}
