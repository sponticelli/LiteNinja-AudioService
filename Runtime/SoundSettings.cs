using UnityEngine;

namespace LiteNinja.AudioService
{
    /// <summary>
    /// Defines the settings for the sound service.
    /// </summary>
    /// <remarks>
    /// This class is a ScriptableObject, which means it's a data container that you can use to save large amounts of data, independent of class instances.
    /// One of the main use cases of ScriptableObjects is to reduce your Project’s memory usage by avoiding copies of values.
    /// </remarks>
    [CreateAssetMenu(menuName = "LiteNinja/Audio/Sound Settings", fileName = "SoundSettings", order = 0)]
    public class SoundSettings : ScriptableObject
    {
        /// <summary>
        /// The initial number of AudioSource instances to be created by the sound service.
        /// </summary>
        [SerializeField] private int _startingAudioSources = 5;

        /// <summary>
        /// Whether the sound service can add more AudioSource instances if needed.
        /// </summary>
        [SerializeField] private bool _canAddAudioSources = true;

        /// <summary>
        /// The AudioSource prefab to be used by the sound service.
        /// </summary>
        [SerializeField] private AudioSource _audioSourcePrefab;

        /// <summary>
        /// Gets the initial number of AudioSource instances to be created by the sound service.
        /// </summary>
        public int StartingAudioSources => _startingAudioSources;

        /// <summary>
        /// Gets whether the sound service can add more AudioSource instances if needed.
        /// </summary>
        public bool CanAddAudioSources => _canAddAudioSources;

        /// <summary>
        /// Gets the AudioSource prefab to be used by the sound service.
        /// </summary>
        public AudioSource AudioSourcePrefab => _audioSourcePrefab;
    }
}