# Architectural XR Walkthrough

## Description
Unity architectural/environment walkthrough developed for Computacao Grafica coursework in 2025. The project uses Unity, URP, and OpenXR-style configuration to explore an imported architectural scene with first-person movement, generated mesh collision, doors, ambient audio zones, footsteps, and UI area labels.

## Tech Stack
- Unity 3D
- C#
- Universal Render Pipeline (URP)
- OpenXR / XR configuration
- Imported architectural 3D models
- Audio zones and collision systems

## Highlights
- Player movement and mouse-look controls.
- Door interaction controllers with audio feedback.
- Generated mesh collider system for imported architecture.
- Ambient audio switching between internal/external zones.
- Footstep audio and zone announcement UI.
- Heavy architectural and environment assets tracked through Git LFS patterns.

## Structure
- `CG2/Assets/Scripts/` contains the custom C# scripts.
- `CG2/Assets/Scenes/` contains Unity scenes.
- `CG2/Packages/` and `CG2/ProjectSettings/` contain Unity project configuration.
- The older root-level Unity attempt is ignored; `CG2` is the clean project root for GitHub.

## How to Run
Open `CG2` with Unity and run the configured scene.
