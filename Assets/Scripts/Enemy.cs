using System.Globalization;
using TMPro;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    private EnemyAttributes _enemyAttributes;
    private Renderer _renderer;
    
    [Header("DEBUG")]
    [SerializeField] private TMP_Text _typeText;
    [SerializeField] private TMP_Text _classText;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _spawnRateText;
    
    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
    }
    
    public void SetEnemyType(EnemyAttributes enemyAttributes)
    {
        _enemyAttributes = enemyAttributes;
        SetDebugValues(_enemyAttributes);
    }
    private void SetDebugValues(EnemyAttributes enemyAttributes)
    {
        _renderer.material.color = _enemyAttributes.EnemyColor;
        _typeText.text = _enemyAttributes.Type.ToString();
        _classText.text = _enemyAttributes.Class.ToString();
        _attackText.text = _enemyAttributes.AttackPower.ToString();
        _healthText.text = _enemyAttributes.Health.ToString();
        _speedText.text = _enemyAttributes.Speed.ToString();
        _spawnRateText.text = _enemyAttributes.SpawnRate.ToString(CultureInfo.InvariantCulture);
    }
}
