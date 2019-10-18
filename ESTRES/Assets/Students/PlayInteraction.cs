using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInteraction : MonoBehaviour
{
    public Image fondo;
    public Image gauge;
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
        Student student = GameControl.instance.player.GetComponent<Player>().student;
        if(currentInteraction.context != Context.Dialogo) {
            if(currentInteraction.Assert(answer)) {
                if(student.level > 0) {
                    student.level --;
                }
            } else {
                if(student.level < student.gauges.Length - 1)
                    student.level++;
            }
        }
        bool final = currentInteraction.final;
        currentDialogue.doAnswer(answer);

        SetInteraction(currentDialogue.getNext());

        if(currentDialogue.Finished()) {
            StartCoroutine(ExitDialogueCourutine(student, final));
        }

    }

    IEnumerator ExitDialogueCourutine(Student student, bool final) {
        GameControl.instance.fade.StartFade();
        yield return new WaitForSeconds(0.5f);
        if(final) {
                Player player = GameControl.instance.player.GetComponent<Player>();
                float percent = (float)student.level / student.gauges.Length;
                //Debug.Log(percent);
                int score = (int)((1.0f - percent) * 100f);
                student.dialogueButton.SetActive(false);
                student.gameObject.SetActive(false);
                player.student = null;
                player.ninosAyudados ++;
                player.score += score;
            }
            GameControl.instance.ExitDialogue();
            this.gameObject.SetActive(false);
    }

    public void SetInteraction(Interaction interaction) {
        if(interaction != null) {
            Student student = GameControl.instance.player.GetComponent<Player>().student;
            if(student != null) {
                gauge.sprite = student.gauges[student.level];
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
}
