using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioClip musicClip;
    public AudioSource musicSource;
    public bool loopMusic = true;

    private bool isMusicPlaying = true;

    [SerializeField]
    private bool useSlider = true;

    [SerializeField]
    private Slider volumeSlider;

    void Start()
    {
        // Assign the audio clip and audio source components
        musicSource.clip = musicClip;
        musicSource.loop = loopMusic;

        // Play the music
        musicSource.Play();

        // Set the volume slider value to maximum if it exists
        if (useSlider && volumeSlider != null)
        {
            volumeSlider.value = volumeSlider.maxValue;
        }
    }

    void Update()
    {
        // Stop or start the music if the M key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isMusicPlaying)
            {
                musicSource.Pause();
                isMusicPlaying = false;
            }
            else
            {
                musicSource.Play();
                isMusicPlaying = true;
            }
        }

        // Set the volume of the music source based on the slider value
        if (useSlider && volumeSlider != null)
        {
            musicSource.volume = volumeSlider.value;
        }
    }
}