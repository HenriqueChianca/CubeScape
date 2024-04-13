using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoController : MonoBehaviour
{
    public AudioClip[] pianoSounds;
    private AudioSource audioSource;
    public int KeySoundIndex = 0;

    //PianoPuzzle puzzleInstance = PianoPuzzle.GetInstance();

    void Start()
    {
        // Verifica se o componente AudioSource existe no GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Se não existir, adiciona um novo componente AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayPianoKey()
    {
        // Verifica se o índice KeySoundIndex está dentro dos limites do array pianoSounds
        if (KeySoundIndex >= 0 && KeySoundIndex < pianoSounds.Length)
        {
            // Toca o áudio correspondente ao índice KeySoundIndex
            audioSource.PlayOneShot(pianoSounds[KeySoundIndex]);
            
            PianoPuzzle.GetInstance().AddIntToArray(KeySoundIndex);
            
        }
        else
        {
            Debug.LogError("Índice de som inválido!");
        }
    }
}
