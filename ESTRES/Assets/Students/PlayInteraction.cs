using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInteraction : MonoBehaviour
{
    public Image fondo;
    public GameObject buttonA;
    public GameObject buttonB;
    public Text pregunta;
    public Text characterName;

    public TreeDialogue currentDialogue;
    public Interaction currentInteraction;
    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue() {
        currentDialogue.Start();
        SetInteraction(currentDialogue.getNext());
    }

    public void AnswerQuestion(int answer) {
        if(currentInteraction.Assert(answer)) {
            // Aqui hacer si contesto bien la pregunta
        } else {
            // Aqui si contesto mal la pregunta
        }
        currentDialogue.doAnswer(answer);

        SetInteraction(currentDialogue.getNext());

        if(currentDialogue.Finished()) {
            GameControl.instance.ExitDialogue();
            this.gameObject.SetActive(false);
        }

    }

    public void SetInteraction(Interaction interaction) {
        if(interaction != null) {
            fondo.sprite = interaction.background;
            currentInteraction = interaction;

            pregunta.text = interaction.text;
            characterName.text = interaction.characterName;

            // Setup the botones
            if(interaction.answers.Length == 1) {
                buttonB.SetActive(false);
            } else {
                buttonB.SetActive(true);
            }

            for(int i = 0; i < interaction.answers.Length; i++) {
                GameObject button;
                if(i == 0)
                    button = buttonA;
                else
                    button = buttonB;

                button.GetComponentInChildren<Text>().text = interaction.answers[i];
            }
        }
    }
}
