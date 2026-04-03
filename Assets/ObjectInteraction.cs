using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    [Header("Настройки")]
    public float interactionRange = 5f;
    public KeyCode interactKey = KeyCode.E;
    public LayerMask layerMask = -1; // какие слои учитывать

    [Header("UI элементы")]
    public GameObject hintPanel;
    public GameObject infoPanel;

    private bool isLooking = false;
    private bool isInfoOpen = false;
    private Camera playerCamera;

    // Таймер для удержания состояния "смотрит"
    private float lookTimer = 0f;
    private const float LOOK_HOLD_TIME = 0.2f; // секунд, после потери луча

    void Start()
    {
        playerCamera = Camera.main;
        if (hintPanel) hintPanel.SetActive(false);
        if (infoPanel) infoPanel.SetActive(false);
    }

    void Update()
    {
        CheckLookWithStability();

        // Показываем/скрываем подсказку
        if (isLooking && !isInfoOpen)
        {
            if (hintPanel && !hintPanel.activeSelf)
                hintPanel.SetActive(true);
        }
        else
        {
            if (hintPanel && hintPanel.activeSelf && !isInfoOpen)
                hintPanel.SetActive(false);
        }

        if (Input.GetKeyDown(interactKey))
        {
            if (isLooking && !isInfoOpen)
                OpenInfo();
            else if (isInfoOpen)
                CloseInfo();
        }
    }

    void CheckLookWithStability()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // Используем SphereCast для устойчивости
        if (Physics.SphereCast(ray, 0.2f, out hit, interactionRange, layerMask))
        {
            if (hit.collider.gameObject == gameObject || hit.collider.transform.IsChildOf(transform))
            {
                lookTimer = LOOK_HOLD_TIME;
                isLooking = true;
                return;
            }
        }

        // Уменьшаем таймер и выключаем, если время вышло
        lookTimer -= Time.deltaTime;
        if (lookTimer <= 0f)
            isLooking = false;
    }

    void OpenInfo()
    {
        isInfoOpen = true;
        if (infoPanel) infoPanel.SetActive(true);
        if (hintPanel) hintPanel.SetActive(false);
    }

    void CloseInfo()
    {
        isInfoOpen = false;
        if (infoPanel) infoPanel.SetActive(false);
        // подсказка появится снова, если игрок смотрит
    }
}