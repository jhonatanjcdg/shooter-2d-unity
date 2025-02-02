# Unity 2D Shooter Game

Welcome to **Unity 2D Shooter Game**! This is a 2D action game developed in Unity where the player faces waves of enemies, each with unique behaviors and abilities. The player must survive and destroy enemies, collecting points and upgrading stats while navigating multiple scenes.

## Features

- **Player Stats System**: Track and upgrade the player's stats, including health, damage, attack speed, and health regeneration. Stats are persistent across scenes.
- **Enemy AI**: Different enemy types with unique behaviors:
  - **Basic Enemy**: Follows and attacks the player, causing damage upon contact.
  - **Flying Enemy**: Has special abilities, including teleportation and temporarily stealing player stats.
- **Combat Mechanics**: The player can attack enemies, deal damage, and gain points upon defeating them.
- **Scene Persistence**: The player’s statistics remain consistent across scenes, allowing for seamless progression between levels.

## Getting Started

### Prerequisites

- Unity 2020.3 or newer.
- Basic knowledge of Unity’s 2D environment and C# scripting.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/jhonatanjcdg/Unity-2D-Shooter-Game.git
   
# Unity Game Project

## Setup Instructions

1. Open the project in Unity.
2. Load the main scene and set up any additional scenes as needed.
3. Ensure player and enemy prefabs are correctly assigned.

---

## Project Structure

### Scripts
- **StatisticsPlayer.cs**: Manages player stats and ensures they persist across scenes.
- **Enemy.cs**: Controls basic enemy behavior, including movement, attacking the player, and handling damage.
- **FlyingAttack.cs**: Adds special behavior for specific enemies, like stat-stealing and teleportation.

### Scenes
- **Levels**: Contains scenes for game progression.

---

## Gameplay

- **Objective**: Survive enemy waves and score points by defeating them.
- **Player Controls**: Move to dodge enemies and attack to defeat them.
- **Enemy Types**:
  - **Basic Enemies**: Deal damage on contact.
  - **Flying Enemies**: Have special attacks and can teleport.

---

## Scripts Overview

### StatisticsPlayer.cs
Manages player stats, including:
- **Health Regeneration**: Automatically restores health over time, up to the maximum.
- **Damage System**: Allows the player to take damage and heal.
- **Point Collection**: Tracks points gained by defeating enemies.
- **Scene Persistence**: Uses `DontDestroyOnLoad` to retain stats across scenes.

### Enemy.cs
Defines basic enemy behaviors:
- **Movement**: Moves toward the player, dealing damage on contact.
- **Damage & Points**: Reduces health if hit by a projectile and drops points upon defeat.
- **Conditional Destruction**: Can self-destruct upon contact with the player.

### FlyingAttack.cs
Enhances specific enemies with special abilities:
- **Teleportation**: Randomly teleports the enemy after an attack.
- **Stat Stealing**: Temporarily reduces player’s attack speed and damage.
- **Health Boost**: Restores a percentage of the enemy’s health based on stolen stats.

---

## Customization

- **Player Stats**: Modify `StatisticsPlayer` values to set initial health, damage, and speed attributes.
- **Enemy Abilities**: Adjust `Enemy` and `FlyingAttack` scripts to vary enemy difficulty and behaviors.
- **Scenes**: Add new scenes and configure player/enemy placements for level progression.

---

## Future Improvements

- **Power-Ups**: Add items that temporarily boost player stats.
- **New Enemy Types**: Implement more varied enemy attacks and patterns.
- **Scoring and Leaderboards**: Track high scores and player rankings.

---

## Contributing

To contribute, fork the repository, make your changes, and submit a pull request.
