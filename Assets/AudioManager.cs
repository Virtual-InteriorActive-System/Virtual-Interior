
using UnityEngine.Audio;
using System; 
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Sound [] sounds;
    public int count = 0; 

	void Awake () {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
           
        }
		
	}
	private void OnCollisionEnter(Collision collision)
	{
        if(count == 3)
        {
            count = 0; 
        }
        if (count == 0)
        {
            Play("song");
            count++;
            Debug.Log(count);
        }               
        else if(count == 1){
            Stop("song");
            Play("song2");
            count++;
        }
        else if(count == 2){
            Stop("song2");
            Play("song3");
                count++;
        }
	}


	public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play(); 
	}
    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
   
}
