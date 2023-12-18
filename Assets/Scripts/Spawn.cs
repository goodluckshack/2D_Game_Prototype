using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private int _platformsCount;
    [SerializeField] private float _spawnDelay;

    [SerializeField] private int _trapPlatformsCount;
    [SerializeField] private float _spawnTrapPlatformsDelay;


    [SerializeField] private Platform _platform;
    [SerializeField] private Platform _trapPlatform;


    private IEnumerator SpawnPlatforms(float spawnDelay)
    {
        for (int i = 0; i < _platformsCount; i++)
        {
            var platform = Instantiate(_platform);
            platform.transform.position = new Vector2(Random.Range(-3f, 3f), 10);
            yield return new WaitForSeconds(spawnDelay);

        }
    }

    private IEnumerator SpawnTrapPlatforms(float spawnTrapPlatfromsDelay)
    {
        for (int i = 0; i < _trapPlatformsCount; i++)
        {
            var trapPlatform = Instantiate(_trapPlatform);
            trapPlatform.transform.position = new Vector2(Random.Range(-3f, 3f), 10);
            yield return new WaitForSeconds(spawnTrapPlatfromsDelay);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlatforms(_spawnDelay));
        StartCoroutine(SpawnTrapPlatforms(_spawnTrapPlatformsDelay));
    }
}
