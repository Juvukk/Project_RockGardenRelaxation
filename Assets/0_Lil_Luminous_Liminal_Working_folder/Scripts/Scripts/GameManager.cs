using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MeditationScript UIRef;
    [SerializeField] private InputTracker getInput;
    private float timer;
    [SerializeField] private int stateNumber = 0;
    [SerializeField] private float[] durationOfSection;
    [SerializeField] private bool stateHasRun = false;
    [SerializeField] private bool experienceBegun = false;

    public enum GameState
    {
        //We can Rename these to help identify each section.
        Welcome, Begin, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven, Twelve,

        Thirteen, Fourteen, Fifthteen, Sixteen, Seventeen, Eightteen, Nineteen, Twenty, TwentyOne,
        TwentyTwo, TwentyThree, TwentyFour, TwentyFive, TwentySix, TwentySeven, End
    }

    public GameState experienceSection;

    // Start is called before the first frame update
    private void Start()
    {
        experienceSection = GameState.Welcome; // set the state to be welcome, this can be commented out to test other states.
    }

    private void Update()
    {
        RunExperience();
    }

    public void RunExperience()
    {
        if (!stateHasRun) // make sure the section only runs once.
        {
            stateHasRun = true;
            State();
        }
    }

    public void State() // check what state we are in
    {
        switch (experienceSection)
        {
            // each "state" is an int so we pass that number to state handler and the change state.
            case GameState.Welcome: // if you hover you mouse over "welcome" you'll see that it = 0

                stateHandler(((int)GameState.Welcome));
                StartCoroutine(changeState(((int)GameState.Welcome)));

                break;

            case GameState.Begin:

                stateHandler(((int)GameState.Begin));//
                StartCoroutine(changeState(((int)GameState.Begin)));

                break;

            case GameState.Two:

                stateHandler(((int)GameState.Two));//
                StartCoroutine(changeState(((int)GameState.Two)));

                break;

            case GameState.Three:

                stateHandler(((int)GameState.Three));//
                StartCoroutine(changeState(((int)GameState.Three)));
                break;

            case GameState.Four:

                stateHandler(((int)GameState.Four));
                StartCoroutine(changeState(((int)GameState.Four)));

                break;

            case GameState.Five:

                stateHandler(((int)GameState.Five));//
                StartCoroutine(changeState(((int)GameState.Five)));
                break;

            case GameState.Six:

                stateHandler(((int)GameState.Six));//
                StartCoroutine(changeState(((int)GameState.Six)));

                break;

            case GameState.Seven:

                stateHandler(((int)GameState.Seven));//
                StartCoroutine(changeState(((int)GameState.Seven)));

                break;

            case GameState.Eight:

                stateHandler(((int)GameState.Eight));//
                StartCoroutine(changeState(((int)GameState.Eight)));
                break;

            case GameState.Nine:

                stateHandler(((int)GameState.Nine)); //
                StartCoroutine(changeState(((int)GameState.Nine)));

                break;

            case GameState.Ten:

                stateHandler(((int)GameState.Ten)); //
                StartCoroutine(changeState(((int)GameState.Ten)));
                break;

            case GameState.Eleven:

                stateHandler(((int)GameState.Eleven)); //
                StartCoroutine(changeState(((int)GameState.Eleven)));
                break;

            case GameState.Twelve:

                stateHandler(((int)GameState.Twelve)); //
                StartCoroutine(changeState(((int)GameState.Twelve)));
                break;

            case GameState.Thirteen://

                stateHandler(((int)GameState.Thirteen));
                StartCoroutine(changeState(((int)GameState.Thirteen)));
                break;

            case GameState.Fourteen://

                stateHandler(((int)GameState.Fourteen));
                StartCoroutine(changeState(((int)GameState.Fourteen)));

                break;

            case GameState.Fifthteen://

                stateHandler(((int)GameState.Fifthteen));
                StartCoroutine(changeState(((int)GameState.Fifthteen)));
                break;

            case GameState.Sixteen://

                stateHandler(((int)GameState.Sixteen));
                StartCoroutine(changeState(((int)GameState.Sixteen)));
                break;

            case GameState.Seventeen://

                stateHandler(((int)GameState.Seventeen));
                StartCoroutine(changeState(((int)GameState.Seventeen)));
                break;

            case GameState.Eightteen://

                stateHandler(((int)GameState.Eightteen));
                StartCoroutine(changeState(((int)GameState.Eightteen)));
                break;

            case GameState.Nineteen://

                stateHandler(((int)GameState.Nineteen));
                StartCoroutine(changeState(((int)GameState.Nineteen)));
                break;

            case GameState.Twenty://

                stateHandler(((int)GameState.Twenty));
                StartCoroutine(changeState(((int)GameState.Twenty)));
                break;

            case GameState.TwentyOne://

                stateHandler(((int)GameState.TwentyOne));
                StartCoroutine(changeState(((int)GameState.TwentyOne)));
                break;

            case GameState.TwentyTwo://

                stateHandler(((int)GameState.TwentyTwo));
                StartCoroutine(changeState(((int)GameState.TwentyTwo)));
                break;

            case GameState.TwentyThree://

                stateHandler(((int)GameState.TwentyThree));
                StartCoroutine(changeState(((int)GameState.TwentyThree)));
                break;

            case GameState.TwentyFour://

                stateHandler(((int)GameState.TwentyFour));
                StartCoroutine(changeState(((int)GameState.TwentyFour)));
                break;

            case GameState.TwentyFive://

                stateHandler(((int)GameState.TwentyFive));
                StartCoroutine(changeState(((int)GameState.TwentyFive)));
                break;

            case GameState.TwentySix://

                stateHandler(((int)GameState.TwentySix));
                StartCoroutine(changeState(((int)GameState.TwentySix)));
                break;

            case GameState.TwentySeven://

                stateHandler(((int)GameState.TwentySeven));
                StartCoroutine(changeState(((int)GameState.TwentySeven)));
                break;

            case GameState.End:
                // end the experience
                break;
        }
    }

    public IEnumerator changeState(int state)
    {
        // Debug.Log("Change State");
        yield return new WaitForSeconds(durationOfSection[state]); // wait for however long we set in the "duration of section" passing in the int of the state
        // once we have finished the state increase state number to move the next section
        stateNumber = stateNumber + 1;
        experienceSection = GameState.Welcome + stateNumber;
        stateHasRun = false; // allow the next state to run.
        yield return null; // end the coroutine.
    }

    public void stateHandler(int state) // at the start of each section send through the state number to get the correct UI and Voice line.
    {
        CallVO(state);
        UIRef.UIHandler(state);
    }

    public void CallVO(int line)
    {
        EventManager.voEvent(line);
    }
}