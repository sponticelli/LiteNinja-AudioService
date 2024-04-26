using UnityEngine;

namespace LiteNinja.AudioService
{
    /// <summary>
    /// Defines a sound clip for the audio service.
    /// </summary>
    /// <remarks>
    /// This class is a ScriptableObject, which means it's a data container that you can use to save large amounts of data, independent of class instances.
    /// One of the main use cases of ScriptableObjects is to reduce your Project’s memory usage by avoiding copies of values.
    /// </remarks>
    [CreateAssetMenu(menuName = "LiteNinja/Audio/Sound Clip Definition", fileName = "Sound", order = 0)]
    public class SoundClipDefinition : ScriptableObject
    {
        /// <summary>
        /// The name of the sound clip.
        /// </summary>
        public string Name;

        /// <summary>
        /// The AudioClip associated with the sound clip.
        /// </summary>
        public AudioClip Clip;
    }
}