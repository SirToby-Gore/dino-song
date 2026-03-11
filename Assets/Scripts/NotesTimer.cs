using System.Collections.Generic;
using UnityEngine;

public class NotesTimer : MonoBehaviour
{
    public float BPM = 120f;
    public float note_timer = 0f;
    public bool playing_sound = false;
    public List<int> time_signature = new List<int> { 4, 4 };

    float targetDuration;

    Note currentNote;   // store the note

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentNote = new Note
            (
                Notes.C,
                4f,
                6,
                Accent.Natural,
                () => { },
                100,
                Instrument.Piano
            );

            targetDuration = (60f / BPM) * (currentNote.duration / (float)time_signature[0]) * time_signature[1];

            note_timer = 0f;
            playing_sound = true;

            currentNote.PlayNote();
        }

        if (playing_sound)
        {
            note_timer += Time.deltaTime;

            Debug.Log(Mathf.Round(note_timer));

            if (note_timer >= targetDuration)
            {
                playing_sound = false;
                currentNote.audioSource.Stop(); // stop the sound
            }
        }
    }
}