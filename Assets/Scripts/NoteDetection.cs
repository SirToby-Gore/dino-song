using System.Collections.Generic;
using UnityEngine;

public class NoteDetection : MonoBehaviour
{
    public BoxCollider2D[] headColliders;
    public float BPM = 120f;
    public List<int> time_signature = new List<int> { 4, 4 };

    private Notes[] notes =
    {
        Notes.F, Notes.E, Notes.D, Notes.C,
        Notes.B, Notes.A, Notes.G, Notes.F, Notes.E
    };

    private int[] octaves =
    {
        4,4,4,4,3,3,3,3,3
    };

    private List<ActiveNote> activeNotes = new List<ActiveNote>();


    void OnTriggerEnter2D(Collider2D other)
    {
        float duration = GetDurationFromName(other.gameObject.name);

        if (duration <= 0) return;

        for (int i = 0; i < headColliders.Length; i++)
        {
            if (headColliders[i].IsTouching(other))
            {
                Note newNote = new Note
                (
                    notes[i],
                    duration,
                    octaves[i],
                    Accent.Natural,
                    () => { },
                    80,
                    Instrument.Piano
                );

                float targetDuration =
                    (60f / BPM) *
                    (duration / (float)time_signature[0]) *
                    time_signature[1];

                newNote.PlayNote();

                activeNotes.Add(new ActiveNote(newNote, targetDuration));

                break;
            }
        }
    }


    void Update()
    {
        for (int i = activeNotes.Count - 1; i >= 0; i--)
        {
            activeNotes[i].timer += Time.deltaTime;

            if (activeNotes[i].timer >= activeNotes[i].targetDuration)
            {
                activeNotes[i].note.audioSource.Stop();
                activeNotes.RemoveAt(i);
            }
        }
    }


    float GetDurationFromName(string name)
    {
        if (name == "Semibreve(Clone)") return Duration.SemiBreve;
        if (name == "Dotted Minim(Clone)") return Duration.DottedMinim;
        if (name == "Minim(Clone)") return Duration.Minim;
        if (name == "Crotchet(Clone)") return Duration.Crochet;
        if (name == "Quaver(Clone)") return Duration.Quaver;
        if (name == "Semiquaver(Clone)") return Duration.SemiQuaver;

        return -1f;
    }
}


class ActiveNote
{
    public Note note;
    public float timer;
    public float targetDuration;

    public ActiveNote(Note note, float targetDuration)
    {
        this.note = note;
        this.targetDuration = targetDuration;
        this.timer = 0f;
    }
}