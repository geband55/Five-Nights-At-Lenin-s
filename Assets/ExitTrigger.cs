using UnityEngine;
using TMPro;

public class ExitTrigger : MonoBehaviour
{
    public TextMeshProUGUI instructionText; 
    private bool playerInside = false;

    void Start()
    {
        instructionText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            instructionText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            instructionText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit(); // Quits the game (works in build, not in editor)

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in editor
            #endif
        }
    }
}
