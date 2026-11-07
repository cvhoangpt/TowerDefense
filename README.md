# Tower Defense

A 3D tower defense game built with Unity. Enemies march along a fixed path toward your base — build, upgrade and sell turrets along the way to stop them before they get through.

The game has **3 levels** of increasing difficulty, **3 turret types** (each with an upgraded version) and **4 enemy types**, including a boss.

## Getting started

### Requirements
- **Unity 2019.4.11f1** (install via Unity Hub; other 2019.4 LTS versions will likely work but are untested)
- An IDE with Unity support: Visual Studio 2019 (with the Unity workload) or JetBrains Rider

### Open the project
```bash
git clone https://github.com/cvhoangpt/TowerDefense.git
```
1. In Unity Hub, click **Add** and select the `TowerDefenseSimple/` folder (not the repository root).
2. Open it with Unity 2019.4.11f1. The first import takes a few minutes.
3. Open `Assets/Scenes/MainMenu.unity` and press **Play**.

### Build
**File → Build Settings**. The scenes are already registered in this order:

| # | Scene |
|---|---|
| 0 | `MainMenu` |
| 1 | `LevelSelect` |
| 2 | `Level01` |
| 3 | `Level02` |
| 4 | `Level03` |

## How to play

Enemies spawn in waves and follow the road. Each enemy that reaches the end costs you **1 life**. Lose all **20 lives** and the game is over; survive every wave to win the level.

1. Pick a turret from the shop.
2. Click an empty build node to place it (the node changes color if you can't afford it).
3. Click an existing turret to **upgrade** or **sell** it.
4. Killing enemies earns money — spend it on more and better turrets.

The next wave starts 8 seconds after the previous wave has been completely cleared.

### Controls

| Action | Input |
|---|---|
| Move camera | `W` `A` `S` `D` or move the mouse to the screen edge |
| Zoom | Mouse scroll wheel |
| Build / select turret | Left click on a node |
| Pause | `Esc` or `P` |

## Turrets

| Turret | Cost | Upgrade | Range | Attack |
|---|---|---|---|---|
| **Standard Turret** | $100 | $50 | 20 → 30 | Fast single-target bullets (25 → 30 dmg, 2 → 2.5 shots/s) |
| **Missile Launcher** | $300 | $200 | 30 → 40 | Slow homing missiles with area damage (50 → 60 dmg, radius 8 → 10) |
| **Laser Beamer** | $200 | $100 | 15 → 25 | Continuous beam (35 → 40 dmg/s) that slows the target by 50% → 80% |

Values are shown as *base → upgraded*. Each turret can be upgraded once. Selling refunds **50%** of everything spent on that turret.

Turrets automatically target the nearest enemy within range.

## Enemies

| Enemy | Health | Speed | Reward |
|---|---|---|---|
| Simple | 350 | 10 | $20 |
| Fast | 100 | 20 | $15 |
| Tough | 5,500 | 5 | $50 |
| Boss | 10,000 | 3 | $100 |

## Levels

| Level | Starting money | Waves |
|---|---|---|
| Level 01 | $350 | 3 |
| Level 02 | $400 | 5 |
| Level 03 | $500 | 8 |

Only Level 01 is available at first; finishing a level unlocks the next one. Progress is saved locally (`PlayerPrefs` key `levelReached`).

## Project structure

```
TowerDefenseSimple/
├── Assets/
│   ├── Scenes/       MainMenu, LevelSelect, Level01–03
│   ├── Scripts/      All gameplay code (C#)
│   ├── Prefabs/      Turrets, bullets, missiles, effects
│   ├── Enemies/      Enemy prefabs, materials and death effects
│   ├── Animation/    UI animations (menus, game over, ...)
│   ├── Imports/      Third-party models, textures and audio
│   └── ...
├── Packages/         Unity package manifest
└── ProjectSettings/
```

### Scripts overview

| Area | Scripts | Responsibility |
|---|---|---|
| Game state | `GameManager`, `PlayerStats` | Win / lose conditions, money, lives, rounds survived |
| Building | `Shop`, `BuildManager`, `Node`, `NodeUI`, `TurretBlueprint` | Selecting turrets, placing them on nodes, upgrade / sell menu |
| Combat | `Turret`, `Bullet` | Target acquisition, bullets, missiles (area damage) and lasers |
| Enemies | `Enemy`, `EnemyMovement`, `Waypoints` | Health, slow effect, rewards, following the path |
| Waves | `WaveSpawner`, `Wave` | Spawning up to 3 enemy groups per wave, level completion |
| UI & flow | `MainMenu`, `LevelSelector`, `PauseMenu`, `GameOver`, `CompleteLevel`, `SceneFader`, `MoneyUI`, `LivesUI`, `RoundsServived` | Menus, level unlocking, scene transitions, HUD |
| Camera | `CameraController` | Pan and zoom |

### Customizing a level
Most tuning is done in the Inspector, no code changes needed:
- **Waves** — select the object with the `WaveSpawner` component in a level scene (usually `GameMaster`) and edit the `Waves` array (enemy prefab, count and spawn rate for up to 3 groups per wave).
- **Enemy path** — move, add or reorder the children of the `Waypoints` object; enemies visit them in hierarchy order.
- **Starting money / lives** — `PlayerStats` component in each level scene (usually on `GameMaster`).
- **Turret prices** — `Shop` object in each level scene.

## Credits

- Turret models: [Tower Defense Assets](https://devassets.com/assets/tower-defense-assets/)
- Terrain and props: free assets from the [Unity Asset Store](https://assetstore.unity.com/)
- Sound: royalty-free sounds from YouTube and the [Unity Asset Store](https://assetstore.unity.com/)
