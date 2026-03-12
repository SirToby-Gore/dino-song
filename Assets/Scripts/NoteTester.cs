// Temp File for testing of actions.

using UnityEngine;

public class NoteTester : MonoBehaviour
{

    public PlayerMovement player;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            Note note = new Note
            (
                Notes.B,
                Duration.Crochet,
                3,
                Accent.Natural,
                player.Jump,
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Note note = new Note(
                Notes.D,
                Duration.Crochet,
                4,
                Accent.Sharp,
                player.ChangeDirection,
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Note note = new Note(
                Notes.F,
                Duration.Crochet,
                4,
                Accent.Sharp,
                player.Crouch,
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Note note = new Note(
                Notes.E,
                Duration.Crochet,
                4,
                Accent.Natural,
                player.Dash,
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Note note = new Note(
                Notes.G,
                Duration.Crochet,
                4,
                Accent.Natural,
                () => { },
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }
    }
}