using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MeditationScript UIRef;

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
        TwentyTwo, TwentyThree, TwentyFour, TwentyFive, TwentySix, TwentySeven, TwentyEight, TwentyNine, Thirty,
        ThirtyOne, ThirtyTwo, ThirtyThree, ThirtyFour, ThirtyFive, ThirtySix, ThirtySeven, ThirtyEight, ThirtyNine,
        Forty, FortyOne, FortyTwo, FortyThree, FortyFour, FortyFive, FortySix, FortySeven, FortyEight, FortyNine, Fifty, FiftyOne, End
    }

    public GameState experienceSection;

    // Start is called before the first frame update
    private void Start()
    {
        //experienceSection = GameState.Welcome; // set the state to be welcome, this can be commented out to test other states.
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
                //EventManager.bekkiIsCool?.Invoke();
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

            case GameState.TwentyEight:

                stateHandler(((int)GameState.TwentyEight));
                StartCoroutine(changeState(((int)GameState.TwentyEight)));
                break;

            case GameState.TwentyNine:

                stateHandler(((int)GameState.TwentyNine));
                StartCoroutine(changeState(((int)GameState.TwentyNine)));
                break;

            case GameState.Thirty:

                stateHandler(((int)GameState.Thirty));
                StartCoroutine(changeState(((int)GameState.Thirty)));
                break;

            case GameState.ThirtyOne:

                stateHandler(((int)GameState.ThirtyOne));
                StartCoroutine(changeState(((int)GameState.ThirtyOne)));
                break;

            case GameState.ThirtyTwo:

                stateHandler(((int)GameState.ThirtyTwo));
                StartCoroutine(changeState(((int)GameState.ThirtyTwo)));
                break;

            case GameState.ThirtyThree:

                stateHandler(((int)GameState.ThirtyThree));
                StartCoroutine(changeState(((int)GameState.ThirtyThree)));
                break;

            case GameState.ThirtyFour:

                stateHandler(((int)GameState.ThirtyFour));
                StartCoroutine(changeState(((int)GameState.ThirtyFour)));
                break;

            case GameState.ThirtyFive:

                stateHandler(((int)GameState.ThirtyFive));
                StartCoroutine(changeState(((int)GameState.ThirtyFive)));
                break;

            case GameState.ThirtySix:

                stateHandler(((int)GameState.ThirtySix));
                StartCoroutine(changeState(((int)GameState.ThirtySix)));
                break;

            case GameState.ThirtySeven:

                stateHandler(((int)GameState.ThirtySeven));
                StartCoroutine(changeState(((int)GameState.ThirtySeven)));
                break;

            case GameState.ThirtyEight:

                stateHandler(((int)GameState.ThirtyEight));
                StartCoroutine(changeState(((int)GameState.ThirtyEight)));
                break;

            case GameState.ThirtyNine:

                stateHandler(((int)GameState.ThirtyNine));
                StartCoroutine(changeState(((int)GameState.ThirtyNine)));
                break;

            case GameState.Forty:

                stateHandler(((int)GameState.Forty));
                StartCoroutine(changeState(((int)GameState.Forty)));
                break;

            case GameState.FortyOne:

                stateHandler(((int)GameState.FortyOne));
                StartCoroutine(changeState(((int)GameState.FortyOne)));
                break;

            case GameState.FortyTwo:

                stateHandler(((int)GameState.FortyTwo));
                StartCoroutine(changeState(((int)GameState.FortyTwo)));
                break;

            case GameState.FortyThree:

                stateHandler(((int)GameState.FortyThree));
                StartCoroutine(changeState(((int)GameState.FortyThree)));
                break;

            case GameState.FortyFour:

                stateHandler(((int)GameState.FortyFour));
                StartCoroutine(changeState(((int)GameState.FortyFour)));
                break;

            case GameState.FortyFive:

                stateHandler(((int)GameState.FortyFive));
                StartCoroutine(changeState(((int)GameState.FortyFive)));
                break;

            case GameState.FortySix:

                stateHandler(((int)GameState.FortySix));
                StartCoroutine(changeState(((int)GameState.FortySix)));
                break;

            case GameState.FortySeven:

                stateHandler(((int)GameState.FortySeven));
                StartCoroutine(changeState(((int)GameState.FortySeven)));
                break;

            case GameState.FortyEight:

                stateHandler(((int)GameState.FortyEight));
                StartCoroutine(changeState(((int)GameState.FortyEight)));
                break;

            case GameState.FortyNine:

                stateHandler(((int)GameState.FortyNine));
                StartCoroutine(changeState(((int)GameState.FortyNine)));
                break;

            case GameState.Fifty:

                stateHandler(((int)GameState.Fifty));
                StartCoroutine(changeState(((int)GameState.Fifty)));
                break;

            case GameState.FiftyOne:

                stateHandler(((int)GameState.FiftyOne));
                StartCoroutine(changeState(((int)GameState.FiftyOne)));
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
        //UIRef.UIHandler(state);
    }

    public void CallVO(int line)
    {
        EventManager.voEvent(line);
    }
}