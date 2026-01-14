using UnityEngine;
using System.Collections.Generic;

public class PlaylistManager : MonoBehaviour
{
    public List<AudioClip> playlist; // Tu wrzucisz swoje pliki mp3
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (playlist.Count > 0)
        {
            PlayTrack(currentTrackIndex);
        }
    }

    void Update()
    {
        // Sprawdza, czy muzyka przesta³a graæ
        if (!audioSource.isPlaying)
        {
            NextTrack();
        }
    }

    void PlayTrack(int index)
    {
        audioSource.clip = playlist[index];
        audioSource.Play();
    }

    void NextTrack()
    {
        // Zwiêksza indeks i wraca do 0, jeœli to by³ ostatni utwór (tworzy pêtlê listy)
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
        PlayTrack(currentTrackIndex);
    }
}