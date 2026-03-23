using UnityEngine;
using System.Collections;

public class PlayerAwarenessControler : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

    private IEnumerator Start()
    {
        while (_player == null)
        {
            var p = FindObjectOfType<PlayerMovement>();
            if (p != null)
                _player = p.transform;

            yield return null; // wait a frame
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else 
        { 
            AwareOfPlayer = false;
        }
    }
}
