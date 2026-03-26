using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public GameObject KeyPrefab;

    void Start()
    {
        SpawnKey();
    }

    void SpawnKey() 
    {
        Transform chosenPoint;

        if (Random.value < 0.5f)
        {
            chosenPoint = spawnpoint1;
        }
        else
        {
            chosenPoint = spawnpoint2;

        }

        Instantiate(KeyPrefab, chosenPoint.position, Quaternion.identity);
    }
}
