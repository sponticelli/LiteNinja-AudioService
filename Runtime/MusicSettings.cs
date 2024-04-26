using UnityEngine;

namespace LiteNinja.AudioService
{
    /// <summary>
    /// Defines the settings for the music service.
    /// </summary>
    /// <remarks>
    /// This class is a ScriptableObject, which means it's a data container that you can use to save large amounts of data, independent of class instances.
    /// One of the main use cases of ScriptableObjects is to reduce your Project’s memory usage by avoiding copies of values.
    /// </remarks>
    [CreateAssetMenu(menuName = "LiteNinja/Audio/Music Settings", fileName = "MusicSettings", order = 0)]
    public class MusicSettings : ScriptableObject
    {
        /// <summary>
        /// The AudioSource prefab to be used by the music service.
        /// </summary>
        [SerializeField] private AudioSource _audioSourcePrefab;

        /// <summary>
        /// The duration of the fade effect between songs.
        /// </summary>
        [SerializeField] private float _fadeDurationBetweenSong = 1f;

        /// <summary>
        /// Gets the duration of the fade effect between songs.
        /// </summary>
        public float FadeDurationBetweenSong => _fadeDurationBetweenSong;

        /// <summary>
        /// Gets the AudioSource prefab to be used by the music service.
        /// </summary>
        public AudioSource AudioSourcePrefab => _audioSourcePrefab;
    }
}