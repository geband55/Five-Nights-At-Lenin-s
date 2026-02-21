using UnityEngine;

public class player : MonoBehaviour
{
    public AudioSource Sound;   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Sound != null)
            {
                Sound.Play();
            }
        }
    }
}
