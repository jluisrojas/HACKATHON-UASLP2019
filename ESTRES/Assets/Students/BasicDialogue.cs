using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDialogue : ScriptableObject, Dialogue
{
    Interaction[] interactions;
    int index = 0;

    public void Start() {
        index = 0;
    }

    public void doAnswer(int answer) {
        index++;
    }

    public Interaction getNext() {
        Interaction res = interactions[index];
        return res;
    }

    public bool Finished() {
        if(index == interactions.Length)
            return true;
        else
            return false;
    }
}
