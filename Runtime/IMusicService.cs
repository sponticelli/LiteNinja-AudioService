using UnityEngine;

namespace LiteNinja.AudioService
{
    /// <summary>
    /// IMusicService is an interface that defines the contract for a music service.
    /// </summary>
    /// <remarks>
    /// The music service is responsible for playing and stopping music tracks.
    /// It supports playing a track with or without a fade effect, and stopping a track with or without a fade effect.
    /// </remarks>
    public interface IMusicService
    {
        /// <summary>
        /// Plays the specified AudioClip. Optionally applies a fade effect.
        /// </summary>
        /// <param name="clip">The AudioClip to play.</param>
        /// <param name="fade">Whether to apply a fade effect when starting the AudioClip. Default is true.</param>
        void Play(AudioClip clip, bool fade = true);

        /// <summary>
        /// Plays the specified AudioClip with a fade effect that lasts for the specified duration.
        /// </summary>
        /// <param name="clip">The AudioClip to play.</param>
        /// <param name="fadeDuration">The duration of the fade effect when starting the AudioClip.</param>
        void Play(AudioClip clip, float fadeDuration);

        /// <summary>
        /// Stops the currently playing AudioClip. Optionally applies a fade effect.
        /// </summary>
        /// <param name="fade">Whether to apply a fade effect when stopping the AudioClip. Default is true.</param>
        void Stop(bool fade = true);
    }
}