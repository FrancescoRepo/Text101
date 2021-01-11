using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] private Text textComponent;
    [SerializeField] private State startingState;

    private State state;
    // Start is called before the first frame update
    void Start()
    {
        if (startingState != null)
            state = startingState;

        if(textComponent != null)
            textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextState = state.GetNextState();
        for (int i = 0; i < nextState.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                state = nextState[i];
            }
        }
        textComponent.text = state.GetStateStory();
    }
}
