using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectDescription : MonoBehaviour
{
    public string description;
    public TextMeshProUGUI descriptionText;
    private float displayDistance = 1.2f;
    public GameObject backgroundObject;

    private Transform player;
    private bool isPlayerNear = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        descriptionText.text = ""; 
        backgroundObject.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        isPlayerNear = distance <= displayDistance;
        

        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {   
            Debug.Log(distance);
            descriptionText.text = description;
            backgroundObject.SetActive(true);
        }
        else if (!isPlayerNear || Input.GetKeyDown(KeyCode.Escape))
        {
            descriptionText.text = "";
            backgroundObject.SetActive(false);
        }
    }
}
