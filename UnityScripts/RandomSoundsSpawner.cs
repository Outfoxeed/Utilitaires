using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundsSpawner : MonoBehaviour
{
    public static RandomSoundsSpawner instance;

    [Header("Sounds And Places")]
    [SerializeField] List<SoundAndPlace> soundsAndPlaces;
    [Header("Interval of time between two sounds")]
    [SerializeField] Vector2 IntervalMinMax;
    [Header("AudioSource Transforms")]
    [SerializeField] List<AudioSourceAndPlace> sourcesAndPlaces;

    private float timeToPlay;
    private SoundAndSource nextSoundAndSource;

    #region Monobehaviour Methods
    private void Awake()
    {
        instance = this;
        if(IntervalMinMax == null)
        {
            Debug.LogError(this.ToString() + " : IntervalMinMax is not defined");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChooseSoundTimeAndSource();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > timeToPlay)
        {
            nextSoundAndSource.source.Play();

            ChooseSoundTimeAndSource();
        }
    }
    #endregion

    #region Methods to choose the sound, the source and the time to play the sound
    private void ChooseSoundTimeAndSource()
    {
        // Define the timeToPlay var
        DefineTimeToPlay();

        // Choose the audio clip and the source to play it
        nextSoundAndSource = ChooseSoundAndSource();
        nextSoundAndSource.source.clip = nextSoundAndSource.sound;
    }
    private void DefineTimeToPlay()
    {
        timeToPlay = Random.Range(IntervalMinMax.x, IntervalMinMax.y) + Time.timeSinceLevelLoad;
    }
    private SoundAndSource ChooseSoundAndSource()
    {
        int index = Random.Range(0, soundsAndPlaces.Count);
        SoundAndPlace soundAndPlace = soundsAndPlaces[index];
        AudioClip sound = soundAndPlace.sound;

        List<AudioSourceAndPlace> availableSources = new List<AudioSourceAndPlace>();
        for(int i = 0; i < sourcesAndPlaces.Count; i++)
        {
            if(sourcesAndPlaces[i].place.ToString() == soundAndPlace.place.ToString())
            {
                availableSources.Add(sourcesAndPlaces[i]);
            }
        }
        
        if(availableSources.Count == 0) { Debug.LogError("No available AudioSource for this SoundAndPlace"); return null; }
        index = Random.Range(0, availableSources.Count);
        AudioSourceAndPlace sourceAndPlace = availableSources[index];
        AudioSource source = sourceAndPlace.source;

        return new SoundAndSource(sound, source);
    }
    #endregion
}


public class Place
{
    public enum TypeOfPlace { stairs, corridor, door, livingRoom, cellar, attic, bathroom};
}
[System.Serializable] public class SoundAndPlace : Place
{
    public AudioClip sound;
    public TypeOfPlace place;

    public SoundAndPlace(AudioClip sound, TypeOfPlace place)
    {
        this.sound = sound;
        this.place = place;
    }
}

[System.Serializable] public class AudioSourceAndPlace : Place
{
    public AudioSource source;
    public TypeOfPlace place;

    public AudioSourceAndPlace(AudioSource source, TypeOfPlace place)
    {
        this.source = source;
        this.place = place;
    }
}

public class SoundAndSource
{
    public AudioClip sound;
    public AudioSource source;

    public SoundAndSource(AudioClip sound, AudioSource source)
    {
        this.sound = sound;
        this.source = source;
    }
}