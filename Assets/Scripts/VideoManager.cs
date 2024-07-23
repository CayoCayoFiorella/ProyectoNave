using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nombreDeLaSiguienteEscena;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += FinVideo;
    }
    void Update()
    {
        // Verifica si se presiona la tecla de espacio para saltar el video
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FinVideo(videoPlayer);
        }
    }

    // Update is called once per frame
    void FinVideo(VideoPlayer vp) 
    {
        SceneManager.LoadScene(nombreDeLaSiguienteEscena);
    }
}
