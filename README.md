# Music Game

## Summary

This level-based arcade video game uses the soundtracks BPM (beat/min) as a queue to perform actions. The player must avoid a sequence of obstacles by being restricted to 1 action per beat. Keeping up with the tempo key to completing the level. 

## Preview
<p align="center">
  <b> 70 bpm level</b>  
</p>

https://user-images.githubusercontent.com/65002959/213263703-2ff70cea-5871-4310-98f3-2324255faada.mp4


## Current Mode of Operation
  - ### Ground
    - Rotating cylinder as floor
    - Spawns collumns of cubes outside of the level delimitation, each cube parented to the floor on collision and inheriting its rotation. Cubes are set on a thread to delete after a few seconds once outside of camera view.
  - ### Background
    - Each pillar reacts differently to the musics audio data
    - Audio intensity inflection point used on each pillar to create different visual effects based on music segments. 
    - Colors change gradually over time, rate depending on clip loudness.
  - ### Ship
    - Player can move once signaled that a new beat has occured
    - UI indicator to indicate when player can move
  - ### Obstacles
    - Itterates through list of predefined obstacle positions on every beat and spawns them at the appropriate location
    - Offset calculated in order for player to move when between two obstacles
 



## Spaceship Modeling

Blender            |  Unity
:-------------------------:|:-------------------------:
![spacship](https://user-images.githubusercontent.com/65002959/212741716-a2da58d6-fe0e-488c-adb7-3b8a9387d891.PNG)  |  ![spaceship unity](https://user-images.githubusercontent.com/65002959/212741725-ecd3b70b-db8b-4db5-893d-cf55f268e3c0.PNG)






