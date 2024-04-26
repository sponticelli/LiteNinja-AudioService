using UnityEngine;
using UnityEngine.Audio;

namespace LiteNinja.AudioService
{
    /// <summary>
    /// This class is used to set the value of a specific parameter in an AudioMixer.
    /// </summary>
    /// <remarks>
    /// The AudioMixer allows for the management and control of multiple audio sources within a scene.
    /// The parameter to be controlled is specified by the string '_parameterName'.
    /// </remarks>
    public class SetAudioMixerVariable : MonoBehaviour
    {
        /// <summary>
        /// The AudioMixer that contains the parameter to be controlled.
        /// </summary>
        [SerializeField] private AudioMixer _audioMixer;

        /// <summary>
        /// The name of the parameter within the AudioMixer to be controlled.
        /// </summary>
        [SerializeField] private string _parameterName;
    
        /// <summary>
        /// Sets the value of the specified parameter in the AudioMixer.
        /// </summary>
        /// <param name="volume">The value to set the parameter to.</param>
        public void SetValue(float volume)
        {
            _audioMixer.SetFloat(_parameterName, volume);
        }
    }
}