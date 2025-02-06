using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
    public AudioSource buttonSound;
    public AudioClip buttonSoundClip;

    private void Start()
    {
        buttonSound.volume = 0.4f;
    }

    public void StartGameplay()
    {
        buttonSound.PlayOneShot(buttonSoundClip);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
