using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "interaccion", menuName = "Students/Interaction")]
public class Interaction : ScriptableObject
{
    public Context context;
    public string text;
    public string playerTect;
    public string[] answers;
    public Interaction[] answersI;
    public int rightAnswer;
    public bool Assert(int answer) {
        if(answer == rightAnswer)
            return true;
        else
            return false;
    }

    public Interaction GetNext(int answer) {
        if(answersI.Length == 0) {
            return null;
        } else if(answersI.Length == 1) {
            return answersI[0];
        } else {
            return answersI[answer];
        }
    }
}
