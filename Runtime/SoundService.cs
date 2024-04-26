using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LiteNinja.AudioService
{
    /// <summary>
    /// SoundService is a class that implements the ISoundService interface.
    /// </summary>
    /// <remarks>
    /// This class is responsible for playing sound effects at a specific position with a given volume and pitch.
    /// It manages a pool of AudioSource instances and uses them to play the sound effects.
    /// </remarks>
    public class SoundService : MonoBehaviour, ISoundService
    {
        [SerializeField]
        private SoundSettings _settings;
        
        private List<AudioSource> _audioSources;
        
        private void  Awake()
        {
            CreateAudioSources();
        }
        
        public void Play(AudioClip clip, Vector3 position = default, float volume = 1, float pitch = 1)
        {
            var audioSource = GetAudioSource();
            if (audioSource == null) return;
            
            audioSource.transform.position = position;
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.Play();
        }

        /// <summary>
        /// Creates and initializes the list of AudioSource instances.
        /// </summary>
        /// <remarks>
        /// This method creates a new list of AudioSource instances and populates it with AudioSource instances.
        /// The number of AudioSource instances created is determined by the StartingAudioSources property of the SoundSettings object.
        /// Each AudioSource instance is created by calling the CreateAudioSource method.
        /// </remarks>
        private void CreateAudioSources()
        {
            _audioSources = new List<AudioSource>();
            for (var i = 0; i < _settings.StartingAudioSources; i++)
            {
                _audioSources.Add(CreateAudioSource());
            }
        }

        /// <summary>
        /// Creates a new AudioSource instance.
        /// </summary>
        /// <remarks>
        /// This method instantiates a new AudioSource from the AudioSourcePrefab defined in the SoundSettings.
        /// The AudioSource is parented to the current transform and its name is set to "AudioSource_" followed by the current count of AudioSource instances.
        /// The AudioSource is set to not play on awake.
        /// </remarks>
        /// <returns>The newly created AudioSource instance.</returns>
        private AudioSource CreateAudioSource()
        {
            var audioSource = Instantiate(_settings.AudioSourcePrefab, transform);
            audioSource.gameObject.name = $"AudioSource_{_audioSources.Count}";
            audioSource.playOnAwake = false;
            return audioSource;
        }
        
        /// <summary>
        /// Retrieves an available AudioSource instance.
        /// </summary>
        /// <remarks>
        /// This method first tries to find an AudioSource that is not currently playing. If it finds one, it returns it.
        /// If it doesn't find one and the settings allow for adding more AudioSources, it creates a new AudioSource, adds it to the list, and returns it.
        /// If it doesn't find one and the settings do not allow for adding more AudioSources, it returns null.
        /// </remarks>
        private AudioSource GetAudioSource()
        {
            var audioSource = _audioSources.FirstOrDefault(audioSource => !audioSource.isPlaying);
            if (audioSource != null) return audioSource;
            if (!_settings.CanAddAudioSources) return null;

            audioSource = CreateAudioSource();
            _audioSources.Add(audioSource);
            return audioSource;
        }

    }
}