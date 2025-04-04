using NAudio.Wave;
using System;

public class MusicPlayer
{
    bool stop = false;
    private WaveOutEvent outputDevice;
    private AudioFileReader audioFile;

    // Constructor to initialize the music player
    public MusicPlayer()
    {
        outputDevice = new WaveOutEvent();
    }

    // Play music and loop indefinitely
    public void PlayMusic(string filePath)
    {
        StopMusic(); // Stop any current music before starting new music
        stop = false;
        audioFile = new AudioFileReader(filePath);
        outputDevice.Init(audioFile);
        outputDevice.PlaybackStopped += OnPlaybackStopped; // Handle when playback stops

        outputDevice.Play();
    }

    // Stop the music playback
    public void StopMusic()
    {
        if (outputDevice != null)
        {
            stop = true;
            outputDevice.Stop();
            outputDevice.Dispose();

            // Dispose of the previous audio file to free up resources
            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
        }
    }

    // Event handler that triggers when playback stops
    private void OnPlaybackStopped(object sender, StoppedEventArgs e)
    {
        // Restart the music automatically if it stops (looping)
        if (audioFile != null && stop ==false)
        {
            audioFile.Position = 0; // Reset to the beginning
            outputDevice.Play(); // Play the music again
        }
    }
}
