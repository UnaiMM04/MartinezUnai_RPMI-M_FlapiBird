using UnityEngine;

public class Spawner : MonoBehaviour
{
    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 pos = new Vector3(10f, randomY, 0f);
        Instantiate(pipePrefab, pos, Quaternion.identity);
        Invoke("SpawnPipe", 2f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
