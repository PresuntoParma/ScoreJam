using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public float spawnX;
    public float spawnMaxY;
    public float spawnMinY;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int randomX = Random.Range(-10, 11);
        float posX = randomX > 0 ? -1 : 1;

        Instantiate(enemyPrefab, new Vector2(spawnX * posX, Random.Range(spawnMinY, spawnMaxY + 0.1f)), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 2.1f));
        StartCoroutine(SpawnEnemy());
    }
}
