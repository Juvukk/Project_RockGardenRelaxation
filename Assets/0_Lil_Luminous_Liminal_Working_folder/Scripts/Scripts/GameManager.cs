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
        //Start,
        Welcome, Begin, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven,

        Twelve, Thirteen, Fourteen, Fifteen, Sixteen, Seventeen, Eighteen, Nineteen, Twenty, TwentyOne, TwentyTwo, End
    }

    public GameState experienceSection;

    // Start is called before the first frame update
    private void Start()
    {
        // experienceSection = GameState.Start;
        experienceSection = GameState.Welcome;
    }

    // Update is called once per frame
    private void Update()
    {
        RunExperience();
    }

    public void RunExperience()
    {
        //if (experienceSection == GameState.Start)
        //{
        //    if (getInput.TriggerPulled == true && experienceBegun == false)
        //    {
        //        experienceBegun = true;
        //        experienceSection = GameState.Welcome;
        //        State();
        //    }
        //}
        //else
        if (!stateHasRun)
        {
            stateHasRun = true;
            State();
        }
    }

    public void State()
    {
        switch (experienceSection)
        {
            //case GameState.Start:

            //    stateHandler(((int)GameState.Start));//

            //    break;

            case GameState.Welcome:
                Debug.LogError("welcomeShould be running");
                stateHandler(((int)GameState.Welcome));//
                StartCoroutine(changeState(((int)GameState.Welcome)));

                break;

            case GameState.Begin:

                stateHandler(((int)GameState.Begin));//
                StartCoroutine(changeState(((int)GameState.Begin)));

                break;

            case GameState.One:

                stateHandler(((int)GameState.One));//
                StartCoroutine(changeState(((int)GameState.One)));

                break;

            case GameState.Two:

                stateHandler(((int)GameState.Two));//
                StartCoroutine(changeState(((int)GameState.Two)));
                break;

            case GameState.Three:

                stateHandler(((int)GameState.Three));
                StartCoroutine(changeState(((int)GameState.Three)));

                break;

            case GameState.Four:

                stateHandler(((int)GameState.Four));//
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

                stateHandler(((int)GameState.Eight)); //
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

                break;

            case GameState.Twelve:

                stateHandler(((int)GameState.Twelve)); //

                break;

            case GameState.Thirteen:

                stateHandler(((int)GameState.Thirteen)); //

                break;

            case GameState.Fourteen:

                stateHandler(((int)GameState.Fourteen)); //

                break;

            case GameState.Fifteen:

                stateHandler(((int)GameState.Fifteen)); //

                break;

            case GameState.Sixteen:

                stateHandler(((int)GameState.Sixteen)); //

                break;

            case GameState.Seventeen:

                stateHandler(((int)GameState.Seventeen));

                break;

            case GameState.Eighteen:

                stateHandler(((int)GameState.Eighteen));

                break;

            case GameState.Nineteen:

                stateHandler(((int)GameState.Nineteen));

                break;

            case GameState.Twenty:

                stateHandler(((int)GameState.Twenty));

                break;

            case GameState.TwentyOne:

                stateHandler(((int)GameState.TwentyOne));
                break;

            case GameState.TwentyTwo:

                stateHandler(((int)GameState.TwentyTwo));
                break;

            case GameState.End:
                // end the experience
                break;
        }
    }

    public IEnumerator changeState(int state)
    {
        // Debug.Log("Change State");
        yield return new WaitForSeconds(durationOfSection[state]);
        stateNumber++;
        experienceSection = GameState.Welcome + stateNumber;
        stateHasRun = false;
        yield return null;
    }

    public void stateHandler(int state)
    {
        CallVO(state);
        UIRef.UIHandler(state);
    }

    public void CallVO(int line)
    {
        EventManager.voEvent(line);
    }
}