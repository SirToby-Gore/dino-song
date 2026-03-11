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
        if (Input.GetKeyDown(KeyCode.T))
        {
            Note note = new Note(
                Notes.C,
                Duration.Crochet,
                4,
                Accent.Natural,
                player.Jump,
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Note note = new Note(
                Notes.C,
                Duration.Crochet,
                4,
                Accent.Natural,
                player.ChangeDirection,
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Note note = new Note(
                Notes.C,
                Duration.Crochet,
                4,
                Accent.Natural,
                player.Crouch,
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Note note = new Note(
                Notes.C,
                Duration.Crochet,
                4,
                Accent.Natural,
                player.Dash,
                80,
                Instrument.Piano
            );

            note.PlayNoteAndAction();
        }
    }
}