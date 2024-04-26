# LiteNinja Audio Service

LiteNinja Audio Service is a C# library that provides a simple and efficient way to manage and play audio in your Unity3D application. It includes two main services: `IMusicService` and `ISoundService`.

## Dependencies
- DOTween (for Music fade in/out)

## Getting Started

To use the LiteNinja Audio Service, you first need to install it. You can do this by adding it as a dependency in your project.

## Dependencies

- DOTween

## Usage

### Music Service

The `IMusicService` interface provides methods for playing and stopping music tracks. It supports playing a track with or without a fade effect, and stopping a track with or without a fade effect.

Here's an example of how to use the `IMusicService`:

```csharp
IMusicService musicService = ... // Get the music service instance
AudioClip clip = ... // Get the AudioClip to play

// Play the AudioClip with a fade effect
musicService.Play(clip, true);

// Stop the currently playing AudioClip with a fade effect
musicService.Stop(true);
```

### Sound Service

The `ISoundService` interface provides methods for playing sound effects at a specific position with a given volume and pitch.

Here's an example of how to use the `ISoundService`:

```csharp
ISoundService soundService = ... // Get the sound service instance
AudioClip clip = ... // Get the AudioClip to play
Vector3 position = ... // The position where the sound should be played

// Play the AudioClip at the specified position with a volume of 1 and a pitch of 1
soundService.Play(clip, position, 1f, 1f);
```

## Error Handling

If there's an error while using the services, the library will throw an exception. You can catch these exceptions and handle them in a way that makes sense for your application.

## Further Reading

For more detailed information about the classes and methods in the LiteNinja Audio Service, please refer to the inline documentation in the source code.