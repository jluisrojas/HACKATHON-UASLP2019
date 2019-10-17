using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Dialogue
{
     void Start();
     void doAnswer(int answer);
     Interaction getNext();
     bool Finished();
}
