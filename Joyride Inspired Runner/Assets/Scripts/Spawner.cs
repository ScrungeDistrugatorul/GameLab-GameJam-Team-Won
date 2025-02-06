using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    
    public float spawnTime;
    public float[] rotationValues;
    
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
        else if (spawnObj.CompareTag("Enemy"))
        {
            float scale = Random.Range(0.5f, 1f);
            float rotation = Random.Range(rotationValues[0], rotationValues[2]);
            GameObject cube = Instantiate(spawnObj, 
                new Vector3(transform.position.x, (transform.position.y + Random.Range(-4,4)),transform.position.z+5), 
                Quaternion.identity);
            cube.transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, rotation);
            cube.transform.localScale = new Vector3(scale, scale, transform.localScale.z);
            Debug.Log(cube.transform.localScale);
        }
        else if (spawnObj.CompareTag("Gun") || spawnObj.CompareTag("Shield"))
        {
            Instantiate(spawnObj, 
                new Vector3(transform.position.x, (transform.position.y + Random.Range(-3,3)),transform.position.z+5), 
                Quaternion.identity);
        }
        else if (spawnObj.CompareTag("CeilingEnemy"))
        {
            Instantiate(spawnObj, 
                new Vector3(transform.position.x, (transform.position.y + 3.5f),transform.position.z+5), 
                Quaternion.identity);
        }
    }
}
