using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{

    public GameObject key1;
    public GameObject key2;


    void Start()
    {
        int random = Random.Range(0, 2); // picks a random number 

        if (random == 0) 
        {
            key1.SetActive(true);
            key2.SetActive(false);
        }
        else
        {
            key1.SetActive(false);
            key2.SetActive(true);
        }
    }
}
