using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource
{
    public GameObject gameObj;
    public SoundSource(AudioClip a)
    {
        
    }
}

public class SoundScript : MonoBehaviour {

    public static SoundScript Instance;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        thisAudio = GetComponent<AudioSource>();
    }

    public float globalBasicVol = 0.8f;
    public AudioClip[] stageBGM;
    public AudioClip titleBGM;
    public AudioClip interBGM;
    public AudioClip levelUpClip;
    public float termBetweenMusic = 0.5f;
    public float fadeOutTime = 0.7f;
    public bool EffectSoundOn = true;
    public bool BGMOn = true;
    public AudioSource thisAudio;

    private bool playbool;


	// Use this for initialization
	void Start () {
        thisAudio.volume = globalBasicVol;
	}

    public AudioClip GetAudio()
    {
        switch(GameManager.Instance.ChangeScene)
        {
            case GameScene.Title:
                return titleBGM;
            case GameScene.InterMission:
                return interBGM;
                case GameScene.Stage:
                return stageBGM[Random.Range(0, stageBGM.Length)];
        }

        return stageBGM[0];
    }

    public void SoundTurnOnOff(bool on)
    {
        thisAudio.mute = !on;
        BGMOn = on;
        EffectSoundOn = on;
    }

    public void ChangeVolume(float vol)
    {
        globalBasicVol = vol;
        thisAudio.volume = vol;
    }

    public void PlayMusic(AudioClip clip, bool loop)
    {
        StartCoroutine(PlayNextBGM(clip, loop));
    }

    public void StopMusic()
    {
        StartCoroutine(StopPlay());
    }

    public void PlayProperMusic()
    {
        StartCoroutine(PlayNextBGM(GetAudio(), true));
    }

    public IEnumerator PlayNextBGM(AudioClip clipReceived, bool loo)
    {
        if(thisAudio.clip == clipReceived)
        {
            yield return null;
        }
        else{
            thisAudio.clip = clipReceived;
            yield return new WaitForSeconds(termBetweenMusic);
            if (thisAudio.isPlaying)
                yield return StartCoroutine(FadeOutSound(fadeOutTime));

            thisAudio.Stop();
            thisAudio.volume = globalBasicVol;
            thisAudio.loop = loo;
            thisAudio.Play();
            playbool = false;
        }
    }

    IEnumerator StopPlay()
    {
        if (thisAudio.isPlaying)
            yield return StartCoroutine(FadeOutSound(fadeOutTime));

        thisAudio.Stop();
        thisAudio.Volume = globalBasicVol;
        playbool = true;
    }
	
    IEnumerator FadeOutSound(float seconds)
    {
        float vol = GetComponent<AudioSource>().volume;
        float startTime = Time.time;
        float endTime = Time.time + seconds;
        while (thisAudio.volume >= 0.1f)
        {
            thisAudio.volume = Mathf.Lerp(vol, 0.0f, (Time.time - startTime) / (endTime - startTime));
            yield return null;
        }
    }

    public void Play(AudioClip a)
    {
        if (EffectSoundOn)
        {
            SoundSource S = new SoundSource(a);
        }
    }

	// Update is called once per frame
	void Update () {
        if(!GetComponent<AudioSource>().isPlaying && !playbool && GetAudio() != null)
        {
            playbool = true;
            StartCoroutine(PlayNextBGM(GetAudio(), true));
        }
	}
}

