using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeDialogue", menuName = "Students/TreeDialogue")]
public class TreeDialogue : ScriptableObject, Dialogue
{
    public Interaction head;
    public Interaction current;

    public void Start() {
        current = head;
    }

    public void doAnswer(int answer) {
        current = current.GetNext(answer);

    }

    public Interaction getNext() {
        return current;
    }

    public bool Finished() {
        if(current == null)
            return true;

        return false;
    }
}
