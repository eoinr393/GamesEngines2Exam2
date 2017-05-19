using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {

    public float polen = 10;
    float beeCount = 0;
    public GameObject bee;
    bool canSpawn = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (polen >= 5 && beeCount < 10 && canSpawn)
        {
            Debug.Log("able to spawn bee");
            polen -= 5;
            beeCount++;
            canSpawn = false;
            StartCoroutine(SpawnBee());
            // yield return new StartCoroutine(SpawnBee);
        }
    }

   /* IEnumerator CheckSpawn()
    {
       
        
    }*/
    IEnumerator SpawnBee()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Spawning Bee");
        Vector3 beepos = transform.position + (Random.insideUnitSphere * (transform.localScale.x + 2));
        beepos.y = transform.position.y + bee.transform.localScale.y / 2 + 0.02f; ;
        Instantiate(bee, beepos, transform.rotation) ;

        canSpawn = true;

    }
}
