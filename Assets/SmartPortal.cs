using UnityEngine;
using System.Collections;

public class SmartPortal : MonoBehaviour
{
    [Header("Portal Settings")]
    public Transform destinationPortal; // Сюда перетащите PortalExit
    public float activationDelay = 2f;   // Время в секундах до появления
    public float teleportDelay = 1f;      // Задержка перед телепортацией

    private bool isPortalActive = false;
    private bool isPlayerInside = false;
    private Coroutine activationCoroutine;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPortalActive)
        {
            isPlayerInside = true;
            activationCoroutine = StartCoroutine(ActivatePortalAfterDelay());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            if (activationCoroutine != null)
            {
                StopCoroutine(activationCoroutine);
                activationCoroutine = null;
            }
            DeactivatePortal(); // Убираем портал, если игрок ушёл
        }
    }

    IEnumerator ActivatePortalAfterDelay()
    {
        yield return new WaitForSeconds(activationDelay);
        if (isPlayerInside)
        {
            ActivatePortal();
            StartCoroutine(TeleportPlayerAfterDelay());
        }
    }

    void ActivatePortal()
    {
        isPortalActive = true;
        // Здесь будет код для визуального появления портала
        gameObject.GetComponent<Renderer>().enabled = true; // Пример: включаем визуал
    }

    void DeactivatePortal()
    {
        isPortalActive = false;
        // Здесь будет код для скрытия портала
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator TeleportPlayerAfterDelay()
    {
        yield return new WaitForSeconds(teleportDelay);
        if (isPlayerInside && isPortalActive)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = destinationPortal.position;
            player.transform.rotation = destinationPortal.rotation;
            DeactivatePortal(); // Выключаем портал после использования
        }
    }
}