using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject Platform;
    public GameObject Diamonds;
    public bool gameOver;
    Vector3 lastPosition;
    float size;


	void Start () {
        lastPosition = Platform.transform.position;
        size = Platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
            SpawnPlatform();
	}

	void Update () {
        if (GameManager.instance.gameOver == true)
            CancelInvoke("SpawnPlatform");
	}
    
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f);
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
            SpawnX();
        else if (rand >= 3)
            SpawnZ();
    }

    void SpawnX()
    {
        Vector3 pos = lastPosition;
        pos.x += size;
        Instantiate(Platform, pos, Quaternion.identity);
        lastPosition = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(Diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), Diamonds.transform.rotation);
    }

    void SpawnZ() 
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        Instantiate(Platform, pos, Quaternion.identity);
        lastPosition = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(Diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), Diamonds.transform.rotation);
    }
}
