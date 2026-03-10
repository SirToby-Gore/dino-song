using UnityEngine;
using System;
using System.Threading.Tasks;

// Enums in C# are typically integers. 
// We'll use a helper to get the float values for Duration.
public enum Notes { A, B, C, D, E, F, G }
public enum Accent { Sharp, Flat, Natural }
public enum Instrument { Piano }

public static class Duration 
{
    public const float SemiQuaver = 0.25f;
    public const float Quaver = 0.5f;
    public const float Crochet = 1f;
    public const float Minim = 2f;
    public const float DottedMinim = 3f;
    public const float SemiBreve = 4f;
}

public class Note
{
    public Notes note;
    public float duration;
    public int octave;
    public Accent accent;
    public Action action;
    public float dynamic; // 0 to 100
    public Instrument instrument;

    private Destroyer destroyer;
    private AudioSource audioSource;
    private GameObject tempObject;

    public Note(Notes note, float duration, int octave, Accent accent, Action action, float dynamic, Instrument instrument)
    {
        this.note = note;
        this.duration = duration;
        this.octave = octave;
        this.accent = accent;
        this.action = action;
        this.dynamic = dynamic;
        this.instrument = instrument;

        // In Unity, we need a GameObject to hold the AudioSource
        tempObject = new GameObject("TempNote_" + note.ToString());
        audioSource = tempObject.AddComponent<AudioSource>();
        destroyer = tempObject.AddComponent<Destroyer>();
        
        // Load the clip from the "Resources" folder
        AudioClip clip = Resources.Load<AudioClip>(GetFilePath());
        if (clip != null)
        {
            audioSource.clip = clip;
        }
        else
        {
            Debug.LogError($"Audio clip not found at: {GetFilePath()}");
        }
    }

    // Static async method to play and cleanup
    public static async Task PlayNote(Notes note, float duration, int octave, Accent accent, Action action, float dynamic, Instrument instrument)
    {
        Note tempNote = new Note(note, duration, octave, accent, action, dynamic, instrument);
        
        tempNote.PlayNote();

        // Wait for the duration of the clip
        if (tempNote.audioSource.clip != null)
        {
            int delayMs = Mathf.CeilToInt(tempNote.audioSource.clip.length * 1000);
            await Task.Delay(delayMs);
        }
    }

    public string GetFilePath()
    {
        string mp3Name = "";

        switch (this.note)
        {
            case Notes.A:
                mp3Name = accent == Accent.Natural ? "a" : (accent == Accent.Flat ? "g_sharp" : "a_sharp");
                break;
            case Notes.B:
                mp3Name = accent == Accent.Natural ? "b" : (accent == Accent.Flat ? "a_sharp" : "c");
                break;
            case Notes.C:
                mp3Name = accent == Accent.Natural ? "c" : (accent == Accent.Flat ? "b" : "c_sharp");
                break;
            case Notes.D:
                mp3Name = accent == Accent.Natural ? "d" : (accent == Accent.Flat ? "c_sharp" : "d_sharp");
                break;
            case Notes.E:
                mp3Name = accent == Accent.Natural ? "e" : (accent == Accent.Flat ? "d_sharp" : "f");
                break;
            case Notes.F:
                mp3Name = accent == Accent.Natural ? "f" : (accent == Accent.Flat ? "e" : "f_sharp");
                break;
            case Notes.G:
                mp3Name = accent == Accent.Natural ? "g" : (accent == Accent.Flat ? "f_sharp" : "g_sharp");
                break;
        }
        return $"Instruments/{instrument.ToString().ToLower()}/octave_{octave}/{mp3Name}";
    }

    public void PlayNote()
    {
        if (audioSource.clip == null) return;
        
        audioSource.volume = dynamic / 100f;
        audioSource.Play();
    }

    public void PlayNoteAndAction()
    {
        PlayNote();
        action?.Invoke();
    }
}