using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TimeManager : MonoBehaviour
{
    public static DayCycle TimeofDay;
    [Header("DEBUG")]
    [SerializeField] private TMP_Text _dayText;
    private void Awake()
    {
        TimeofDay = (DayCycle)Random.Range(0, 3);
        SetDebugVaules();
    }
    private void SetDebugVaules()
    {
        _dayText.text = $"Time:{TimeofDay}";
    }
}

public enum DayCycle: int
{
    Morning = 0,
    Afternoon = 1,
    Night = 2,
}