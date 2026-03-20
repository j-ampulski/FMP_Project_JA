using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private bool canFollow = false;

    private void OnEnable()
    {
        GameController.OnPlayerSpawned += HandlePlayerSpawned;
    }

    private void OnDisable()
    {
        GameController.OnPlayerSpawned -= HandlePlayerSpawned;
    }

    private void HandlePlayerSpawned(GameObject playerObj)
    {
        player = playerObj.transform;
        StartCoroutine(StartFollowingAfterDelay(2f));
    }

    private IEnumerator StartFollowingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canFollow = true;
    }

    private void LateUpdate()
    {
        if (!canFollow || player == null) return;

        transform.position = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );
    }
}

