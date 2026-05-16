using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInteraction : MonoBehaviour
{
    [Header("Настройки")]
    public float interactionRange = 5f;

    [Header("Клавиши")]
    public KeyCode teleportKey = KeyCode.E;
    public KeyCode quitKey = KeyCode.F;

    [Header("Телепорт")]
    public Transform teleportPoint;

    [Header("UI")]
    public GameObject hintPanel;

    private Camera playerCamera;
    private bool isLooking;

    void Start()
    {
        playerCamera = Camera.main;

        if (hintPanel)
            hintPanel.SetActive(false);
    }

    void Update()
    {
        CheckLook();

        if (isLooking)
        {
            if (hintPanel && !hintPanel.activeSelf)
                hintPanel.SetActive(true);

            if (Input.GetKeyDown(teleportKey))
            {
                TeleportPlayer();
            }

            if (Input.GetKeyDown(quitKey))
            {
                QuitGame();
            }
        }
        else
        {
            if (hintPanel && hintPanel.activeSelf)
                hintPanel.SetActive(false);
        }
    }

    void CheckLook()
    {
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            isLooking =
                hit.collider.gameObject == gameObject ||
                hit.collider.transform.IsChildOf(transform);
        }
        else
        {
            isLooking = false;
        }
    }

    void TeleportPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player && teleportPoint)
        {
            CharacterController cc =
                player.GetComponent<CharacterController>();

            // временно выключаем controller
            if (cc) cc.enabled = false;

            player.transform.position = teleportPoint.position;

            if (cc) cc.enabled = true;
        }
    }

    void QuitGame()
    {
        Debug.Log("Игра завершена");

        // Для билда
        Application.Quit();

        // Для редактора Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}