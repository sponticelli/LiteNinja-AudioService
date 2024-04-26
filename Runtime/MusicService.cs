using DG.Tweening;
using UnityEngine;

namespace LiteNinja.AudioService
{
    /// <summary>
    /// MusicService is a class that implements the IMusicService interface.
    /// </summary>
    /// <remarks>
    /// This class is responsible for playing and stopping music tracks.
    /// It supports playing a track with or without a fade effect, and stopping a track with or without a fade effect.
    /// It manages two AudioSource instances and uses them to play the music tracks.
    /// </remarks>
    public class MusicService : MonoBehaviour, IMusicService
    {
        [SerializeField]
        private MusicSettings _settings;
        
        private AudioSource _audioSource1;
        private AudioSource _audioSource2;
        
        private void Awake()
        {
            CreateAudioSources();
        }

        /// <summary>
        /// Plays the specified AudioClip using the available AudioSource.
        /// </summary>
        /// <param name="clip">The AudioClip to play.</param>
        /// <param name="fade">Optional parameter to apply a fade effect when starting the AudioClip. Default is true.</param>
        public void Play(AudioClip clip, bool fade = true)
        {
            if (ManageAudioSources(clip, out var currentAudioSource, out var nextAudioSource)) return;
            
            Fade(fade ? _settings.FadeDurationBetweenSong : 0, currentAudioSource, nextAudioSource);
        }
        
        /// <summary>
        /// Plays the specified AudioClip with a fade effect that lasts for the specified duration.
        /// </summary>
        /// <param name="clip">The AudioClip to play.</param>
        /// <param name="fadeDuration">The duration of the fade effect when starting the AudioClip.</param>
        public void Play(AudioClip clip, float fadeDuration)
        {
            if (ManageAudioSources(clip, out var currentAudioSource, out var nextAudioSource)) return;

            Fade(fadeDuration, currentAudioSource, nextAudioSource);
        }

        /// <summary>
        /// Stops the currently playing AudioClip. Optionally applies a fade effect.
        /// </summary>
        /// <param name="fade">Whether to apply a fade effect when stopping the AudioClip. Default is true.</param>
        /// <remarks>
        /// This method first identifies the current AudioSource.
        /// If the fade parameter is true and the current AudioSource is playing, it applies a fade out effect to the AudioSource over the duration specified in the settings, and then stops the AudioSource.
        /// If the fade parameter is false, it immediately stops the AudioSource.
        /// </remarks>
        public void Stop(bool fade = true)
        {
            var currentAudioSource = _audioSource1.isPlaying ? _audioSource1 : _audioSource2;
            if (fade)
            {
                if (currentAudioSource.isPlaying)
                {
                    currentAudioSource.DOFade(0, _settings.FadeDurationBetweenSong).OnComplete(() =>
                    {
                        currentAudioSource.Stop();
                    });
                }
            }
            else
            {
                currentAudioSource.Stop();
            }
        }
        
        /// <summary>
        /// Creates and initializes the AudioSource instances for the music service.
        /// </summary>
        /// <remarks>
        /// This method creates two AudioSource instances using the AudioSourcePrefab defined in the MusicSettings.
        /// Both AudioSource instances are parented to the current transform.
        /// The AudioSource instances are set to loop and their initial volume is set to 0.
        /// </remarks>
        private void CreateAudioSources()
        {
            _audioSource1 = Instantiate(_settings.AudioSourcePrefab, transform);
            _audioSource2 = Instantiate(_settings.AudioSourcePrefab, transform);    
            
            _audioSource1.loop = true;
            _audioSource2.loop = true;
            
            _audioSource1.volume = 0;
            _audioSource2.volume = 0;
        }
        
        /// <summary>
        /// Applies a fade effect to the current and next AudioSource instances over the specified duration.
        /// </summary>
        /// <param name="fadeDuration">The duration of the fade effect.</param>
        /// <param name="currentAudioSource">The AudioSource currently playing music.</param>
        /// <param name="nextAudioSource">The AudioSource that will play the next AudioClip.</param>
        /// <remarks>
        /// If the current AudioSource is playing, it applies a fade out effect over the specified duration and then stops the AudioSource.
        /// The next AudioSource is set to start playing with its volume set to 0. It then applies a fade in effect over the specified duration.
        /// </remarks>
        private void Fade(float fadeDuration, AudioSource currentAudioSource, AudioSource nextAudioSource)
        {
            if (currentAudioSource.isPlaying)
            {
                currentAudioSource.DOFade(0, fadeDuration).OnComplete(() =>
                {
                    currentAudioSource.Stop();
                });
            }
            
            nextAudioSource.volume = 0;
            nextAudioSource.Play();
            nextAudioSource.DOFade(1, fadeDuration).OnComplete(() =>
            {
            });
        }
        
        /// <summary>
        /// Manages the AudioSource instances for playing music.
        /// </summary>
        /// <param name="clip">The AudioClip to play.</param>
        /// <param name="currentAudioSource">The AudioSource currently playing music.</param>
        /// <param name="nextAudioSource">The AudioSource that will play the next AudioClip.</param>
        /// <returns>True if the current AudioSource is already playing the same AudioClip, otherwise false.</returns>
        /// <remarks>
        /// This method first identifies the current AudioSource and the next AudioSource.
        /// The next AudioSource is determined based on which AudioSource is currently playing.
        /// The method then assigns the provided AudioClip to the next AudioSource.
        /// If the current AudioSource is already playing the same AudioClip, the method returns true, indicating that no further action is needed.
        /// </remarks>
        private bool ManageAudioSources(AudioClip clip, out AudioSource currentAudioSource, out AudioSource nextAudioSource)
        {
            // Find free audio source
            currentAudioSource = _audioSource1.isPlaying ? _audioSource1 : _audioSource2;
            nextAudioSource = currentAudioSource == _audioSource1 ? _audioSource2 : _audioSource1;
            nextAudioSource.clip = clip;

            // If the current audio source is playing the same clip, do nothing
            return currentAudioSource.isPlaying && currentAudioSource.clip == nextAudioSource.clip;
        }
    }
}