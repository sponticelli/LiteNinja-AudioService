using UnityEngine;

namespace LiteNinja.AudioService
{
    /// <summary>
    /// ISoundService is an interface that defines the contract for a sound service.
    /// </summary>
    /// <remarks>
    /// The sound service is responsible for playing sound effects at a specific position with a given volume and pitch.
    /// </remarks>
    public interface ISoundService
    {
        /// <summary>
        /// Plays the specified AudioClip at the specified position. Optionally adjusts the volume and pitch.
        /// </summary>
        /// <param name="clip">The AudioClip to play.</param>
        /// <param name="position">The position where the sound should be played.</param>
        /// <param name="volume">The volume of the sound. Default is 1f.</param>
        /// <param name="pitch">The pitch of the sound. Default is 1f.</param>
        void Play(AudioClip clip, Vector3 position = default, float volume = 1f, float pitch = 1f);
    }
}