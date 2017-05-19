using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour {

    public GameObject resporcePrefab;

    public float radius = 50;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnResources());
	}

    Vector3 NextFlowerPos()
    {
        //fix so flowers dont spawn inside the hive

        float x;
        float z;

        if (Random.Range(0, 2) < 1)
             x = Random.Range(-radius, -10f);
        else
            x = Random.Range(10, radius);
        if (Random.Range(0, 2) < 1)
            z = Random.Range(-radius, -10f);
        else
            z = Random.Range(10, radius);

        return transform.position + new Vector3(x, -0.5f, z);
    }

    System.Collections.IEnumerator SpawnResources()
    {
        while (true)
        {
            GameObject[] flowers = GameObject.FindGameObjectsWithTag("flower");
            if (flowers.Length < 10)
            {
                GameObject flower = GameObject.Instantiate<GameObject>(resporcePrefab);
                flower.transform.position = NextFlowerPos();
                flower.transform.parent = this.transform;
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
