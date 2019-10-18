using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = this.GetComponent<Animation>();
    }

    public void StartFade() {
        animation["FadeAnim"].wrapMode = WrapMode.Once;
        animation.Play("FadeAnim");
    }
}
