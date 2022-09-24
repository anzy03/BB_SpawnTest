using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy spawnPrefab;
    [SerializeField] private List<EnemyAttributes> SpawnableEnemies;

    private void Start()
    {
        SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        var enemyType = GetRandomEnemyType();
        if (enemyType == null) return;
        Debug.Log($"{gameObject.name} = {enemyType.name}");
        var spawnObj = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        spawnObj.SetEnemyType(enemyType);

    }
    private EnemyAttributes GetRandomEnemyType()
    {
        var rand = Random.Range(0.001f, 1.001f); //Gets a random value between 0 and 1
        //Gets the EnemyAttribute with spawnRate nearest to the rand.
        return SpawnableEnemies.Aggregate((x, y)
            => Mathf.Abs(x.SpawnRate - rand) < Mathf.Abs(y.SpawnRate - rand) ? x : y);
    }
}
