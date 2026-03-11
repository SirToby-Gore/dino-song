using System.Collections.Generic;
using UnityEngine;

public class NotesTimer : MonoBehaviour
{
    public float BPM = 120f;
    public float note_timer = 0f;
    public bool playing_sound = false;
    public List<int> time_signature = new List<int> { 4, 4 };

    float targetDuration;
    Note note_name;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            note_name = new Note
            (
                Notes.F,
                4f,
                4,
                Accent.Natural,
                () => { },
                100,
                Instrument.Piano
            );

            targetDuration = (60f / BPM) * (note_name.duration / (float)time_signature[0]) * time_signature[1];

            note_timer = 0f;
            playing_sound = true;
            Debug.Log(note_name.audioSource.clip.length);

            note_name.PlayNote();
        }

        if (playing_sound)
        {
            note_timer += Time.deltaTime;

            if (note_timer >= targetDuration)
            {
                playing_sound = false;
                note_name.StopNote(); // stop audio
            }
        }
    }
}