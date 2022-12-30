using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MusicOfGame : MonoBehaviour
{
	public static MusicOfGame MusicObject { get; private set; }

	private void Awake()
	{
        if (!MusicObject)
        {
			MusicObject = this;
			DontDestroyOnLoad(target: this);
        }
        else
        {
			Destroy(gameObject);
        }
	}
}
