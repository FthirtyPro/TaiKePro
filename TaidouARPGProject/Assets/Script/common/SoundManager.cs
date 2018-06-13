using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

public  static SoundManager _instance;
public  AudioClip[] audioClipArray;
private Dictionary<string, AudioClip >audioDict = new Dictionary<string, AudioClip >();
public AudioSource asoure;
public bool isQuiet =false;

	// Use this for initialization
	void Awake () {
		_instance = this;
	}

	void Start()
	{
		foreach(AudioClip av in audioClipArray)
		{
			audioDict.Add(av.name,av);
		}
	}
	
	// Update is called once per frame
	public void Play(string audioName)
	{
		if(isQuiet)
		return;
		AudioClip ac;
		if(audioDict.TryGetValue(audioName,out ac))
		{
			asoure.PlayOneShot(ac);
		}
	}

		public void Play(string audioName,AudioSource audioSoure)
	{
		if(isQuiet)
		return;
		AudioClip ac;
		if(audioDict.TryGetValue(audioName,out ac))
		{
			asoure.PlayOneShot(ac);
		}
	}
}
