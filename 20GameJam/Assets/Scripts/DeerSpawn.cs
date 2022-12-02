using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSpawn : MonoBehaviour
{

    public GameObject Deer;
    private IEnumerator coroutine;
    public bool Canspawn;
    public int Spawnamount;
    public int SpawnamountObstacle;
    private int index;

    public List<GameObject> obstacle;

    // Start is called before the first frame update
    void Start()
    {
        Spawnamount = Random.Range(50, 100);
        SpawnamountObstacle = Random.Range(500, 750);
        StartCoroutine(spawnobs());
        
        spawnDeer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Canspawn)
        {
            coroutine = spawnDeer();
            StartCoroutine(coroutine);
            Canspawn = false;
        }
        
    }

   
    
    public IEnumerator spawnDeer()
    {
        WaitForSeconds wait = new WaitForSeconds(0f);
        for (int i = 0; i < Spawnamount; i++)
        {
            Bounds bounds = GetComponent<Collider>().bounds;
            float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
            float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
            GameObject newDeer = GameObject.Instantiate(Deer);
            newDeer.transform.position = bounds.center + new Vector3(offsetX, offsetY, offsetZ);
            yield return wait;


        }

    }
    
    
    public IEnumerator spawnobs()
    {
        WaitForSeconds wait = new WaitForSeconds(0.0f);
        
        
        
        for (int i = 0; i < SpawnamountObstacle; i++)
        {
            Bounds bounds = GetComponent<Collider>().bounds;
            float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
            float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
            index = Random.Range(0, obstacle.Count);
            GameObject newDeer = Instantiate(obstacle[index]);
            newDeer.transform.position = bounds.center + new Vector3(offsetX, offsetY, offsetZ);
            yield return wait;


        }

    }
}

