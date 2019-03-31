using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Cameras
    [SerializeField] public Camera fpCamera;
    [SerializeField] public Camera mainCamera;


    //UI Components
    [SerializeField] GameObject bgPanel;
    [SerializeField] public TextMeshProUGUI displayedDialogue;
    [SerializeField] public TextMeshProUGUI whoTalkingName;
    [SerializeField] public Text pressEnterText;    

    [SerializeField] AudioSource tapNoise;    

    bool isSkipped = false;
    float delay = 0.01f;

    [SerializeField] State startingState;
    State state;

    void Start()
    {
        state = startingState;
        bgPanel.SetActive(false);
        mainCamera.enabled = true;
        fpCamera.enabled = false;
    }
    
    void Update()
    {
        //When enter is pressed and main camera enabled, switch cameras
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (mainCamera.enabled == true)
            {
                whoTalkingName.text = state.getWhoIsTalking();
                bgPanel.SetActive(true);
                StartCoroutine(ShowText());
                fpCamera.enabled = true;
                mainCamera.enabled = false;
                pressEnterText.text = "";
            }
            else //when enter key pressed while text being typed, skip typing animation
            {
                if (displayedDialogue.text != state.getDialogueText())
                {
                    isSkipped = true;
                    displayedDialogue.text = state.getDialogueText();
                }
                else 
                { //when end of current dialogue state and more dialogue states, move to next dialogue state                 
                    if (state.getNextStates()[0] != startingState)
                    {
                        StartCoroutine(ShowText());
                        Debug.Log("Next state");
                    }
                    else //when enter key pressed when in first person camera and no more dialogue, exit dialogue
                    {
                        fpCamera.enabled = false;
                        mainCamera.enabled = true;
                        bgPanel.SetActive(false);
                        pressEnterText.text = "Press Enter ( ↵ ) to talk";
                    }
                    state = state.getNextStates()[0];
                    whoTalkingName.text = state.getWhoIsTalking();
                }
            }
        }
    }

    //for putting text on screen one character at a time
    //(IEnumerator is needed for the WaitForSeconds() function
    IEnumerator ShowText()
    {
        tapNoise.Play();
        string currentText = "";
        int i = 0;
        while (i < (state.getDialogueText().Length + 1) && bgPanel.activeSelf && isSkipped == false)
        {            
            currentText = state.getDialogueText().Substring(0, i);
            displayedDialogue.text = currentText;
            
            yield return new WaitForSeconds(delay);
            i++;
        }
        isSkipped = false;
        tapNoise.Stop();
    }    

    //Accessors and mutators for changing delay (needed for implementing choice of typing speed later)
    public void setDelay(float newDelay)
    {
        delay = newDelay;
    }

    public float getDelay()
    {
        return delay;
    }
}