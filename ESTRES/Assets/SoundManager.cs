using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource audioSrc;
    // Start is called before the first frame update
    void Awake()
    {
        audioSrc = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLoop(int clip) {
        if(clip >= 0  && clip < clips.Length) {
            audioSrc.loop = true;
            audioSrc.PlayOneShot(clips[clip]);
        }
    }

    public void StopLoop() {
        audioSrc.Pause();
    }
}
