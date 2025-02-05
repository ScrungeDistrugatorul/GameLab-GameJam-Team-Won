using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    
    public float spawnTime;
    
    private float _timeBetweenSpawns;
    
    public Transform target;
    public float offsetX;
    
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        TimeForSpawning();
        transform.position = new Vector3(target.position.x + offsetX, transform.position.y, transform.position.z);
    }

    void TimeForSpawning()
    {
        _timeBetweenSpawns += Time.deltaTime;

        if (_timeBetweenSpawns >= spawnTime)
        {
            Spawn();
            _timeBetweenSpawns = 0f;
        }
    }

    void Spawn()
    {
        GameObject spawnObj = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        if (spawnObj.CompareTag("GroundedEnemy"))
        {
            Instantiate(spawnObj, 
                new Vector3(transform.position.x, (transform.position.y - 3.5f),transform.position.z+5), 
                Quaternion.identity);
        }
        else
        {
            GameObject cube = Instantiate(spawnObj, 
                new Vector3(transform.position.x, (transform.position.y + Random.Range(-4,4)),transform.position.z+5), 
                Quaternion.identity);
            cube.transform.localScale = new Vector3(Random.Range(1f,2f), Random.Range(1f,2f), transform.localScale.z);
            cube.transform.localRotation = Quaternion.Euler(Random.Range(0f,90f), Random.Range(0f,90f), transform.eulerAngles.z);
        }
    }
}
