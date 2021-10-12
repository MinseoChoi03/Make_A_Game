using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1.5f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    bool m_IsPlayerAtExit;
    float m_Timer;
    bool m_IsPlayerCaught;
    bool m_HasAudioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //캐릭터가 탈출범위에 진입했는지 확인
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if (m_Timer > fadeDuration + displayImageDuration) //이미지 fade 후, 약간의 시간 지난 뒤 종료
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
                Application.Quit();
            }
        }
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
}
