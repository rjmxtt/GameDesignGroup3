using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(3, 3)] [SerializeField] string dialogueText;
    [SerializeField] string whoIsTalking;

    [SerializeField] State[] nextStates;

    public string getDialogueText()
    {
        return dialogueText;
    }

    public string getWhoIsTalking()
    {
        return whoIsTalking;
    }

    public State[] getNextStates()
    {
        return nextStates;
    }
}
