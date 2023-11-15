using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] GameObject objectPrefab;

    [SerializeField] float spawnRate = 1;

    [SerializeField] int numberOfObjectsToSpawn;

     void Start()
    {
        StartCoroutine(Spawn()); //para iniciar la corutina del Ienumerator

        //Parar coroutine 1 o todas
        /*StopCoroutine(Spawn());
        StopAllCoroutines(Spawn());*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Spawn()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++) //control cuantos objetos spawneas
        {
            Instantiate(objectPrefab, transform.position, transform.rotation); //activar coroutine
            yield return new WaitForSeconds(spawnRate); //para detener la corotine
        }
    }

}
