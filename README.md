# ML-Smart-Enemy
Smart Enemy is a school project for the course Introduction to Neural Networks. The idea was an enemy that track player down and if enemy catch then wins.

## How to Run
1. Go to Unity's ml-agents repository and download it.
2. This project is made with ml-agents release v0.5.
3. After cloning repository project only needs UnitySDK folder.
4. Copy ml-agents\UnitySDK folder, paste in ML-Smart-Enemy\Assests folder.
5. Open project in Unity. It's ready.

## What I Learn
* Create simple brains and tweek them with different configs.
* Train Agents with different brains in Academy.
* Observation Vector principles.

### How I Trained Brains
I used Reinforcement Learning to train my agents.
* Reward : +1
* Penalty : 0

#### Reward Condition
If Enemy Agent touches Player(Target) Agent then it is rewarded by +1.

#### Penalty Condition
If Enemy Agent falls down from platform then scene reloads.
