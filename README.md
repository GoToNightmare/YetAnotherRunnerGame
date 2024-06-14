# This is an exaple FizzBuzz runner game prototype, WIP
Unity version 2020.3.40f1  
Hours spent: 6


## Programming patterns:  
Used:  
 - Event bus: `GameEventBus`  
 - Reactive: `GameReactivePropertyOldAndNew`  
 - State machine: `StateHandler`  

To add:  
 - Pooling for instantiating map objects  
 - Factory for obstacles  
 - Strategy for game logic systems  



## How it should work. Ideas  
 - Game would use custom Update for gameplay logic and state machine states, so pause would only stop game world  
 - Movement should use `MapElement` nodes. When player turn left or right, it should swap next traget node to the corresponding node from different path and slowly chance position over dt  
 - Unity physics or custom spatial hasing to detect collision with obstacles  
 - Red vignette and other effects based on game events  




## Used  
 - Addressables  
 - Unitask  



## TODO  
 - Addressables.ReleaseInstance  
 - Scriptable objects for differnt game rules/spawn chances  
 - Map generation with rotated map pieces  
 - Player controller, tap/swipe  
 - Camera  
 - Ingame UI  
 - Obstacles  
 - Pickable items/coins  
 - Serialization
 - Various models/animations/sprites
