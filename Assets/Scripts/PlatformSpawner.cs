using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    private int lastPlatformIndex;

    void Start()
    {
        for(int i = 0; i < 30; i++)
        {
            CreatePlatform(i*4);
        }
        StartCoroutine(PlatformSpawnTimer());
    }

    public void CreatePlatform(int height)
    {
        float x = Random.Range(-5, 5);
        Instantiate(platform, new Vector2(x, height), Quaternion.identity);
        lastPlatformIndex++;
    }

    IEnumerator PlatformSpawnTimer()
    {
        while (true)
        {
            CreatePlatform(lastPlatformIndex*4);
            yield return new WaitForSeconds(0.8f);
        }
    }
}
