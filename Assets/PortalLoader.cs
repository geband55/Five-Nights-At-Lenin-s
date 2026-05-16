using UnityEngine;
using UnityEngine.Video;

public class PortalLoader : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private Renderer rend;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        rend = GetComponent<Renderer>();

        // Скрываем материал пока видео не готово
        rend.enabled = false;

        // Начинаем подготовку видео
        videoPlayer.Prepare();

        videoPlayer.prepareCompleted += OnVideoPrepared;
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        // Показываем портал когда видео готово
        rend.enabled = true;

        vp.Play();
    }
}