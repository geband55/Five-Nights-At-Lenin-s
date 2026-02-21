using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Note : MonoBehaviour
{
    public string noteText;
    public GameObject noteUIPanel;
    public TMP_Text noteUIText;

    private bool playerInRange = false;
    private bool noteOpen = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            noteOpen = !noteOpen;
            noteUIPanel.SetActive(noteOpen);
            noteUIText.text = noteText;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            noteUIPanel.SetActive(false);
            noteOpen = false;
        }
    }
}
