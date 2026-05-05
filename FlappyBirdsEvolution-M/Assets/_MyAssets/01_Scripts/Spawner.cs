using UnityEngine;

public class Spawner : MonoBehaviour
{
    float maxY = 2f;
    float minY = 0f;
    [SerializeField] private GameObject prefabToSpawn;
    

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 pos = new Vector3(3f, randomY, 0f);
        Instantiate(prefabToSpawn, pos, Quaternion.identity);
        Invoke("SpawnPipe", 2f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

   
   
}
