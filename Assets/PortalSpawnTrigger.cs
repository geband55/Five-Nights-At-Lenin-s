using UnityEngine;

public class PortalSpawnTrigger : MonoBehaviour
{
    [Header("Портал")]
    public GameObject portal;

    [Header("Задержка появления")]
    public float spawnDelay = 5f;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated)
            return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            Invoke(nameof(SpawnPortal), spawnDelay);
        }
    }

    void SpawnPortal()
    {
        portal.SetActive(true);
    }
}