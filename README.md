# Nuclear-Game

This repository contains the code for my nuclear game made in unity. This repo will only contain the code, and there fore I have uploaded an video of the gameplay. 

**IDEA:**
All the credit for this idea has to be given to this youtube video about the nuclear reactor in chernobyl: https://www.youtube.com/watch?v=P3oKNE72EzU&list=LL&index=32
At the time of watching that video I had no idea what I wanted to code next and after seeing that video I had an idea to create an game where you had the same set up
as in the video but you could control the rods moving and how fast the water re appears. So on this project every visual and idealogigal credit has to go to the creator of that video: Higgsino physics.
But the code is fully created by me. This project was the first time ever using Unity and C#, luckily I seemed to catch on quick. 
In this game the player can control the water flow by clicking the arrow button on the screen, this will slow down or increase the time in witch the water will cooldown. The slower it coolsdown
The likelier it is to boild and there for not destroy neutrons. Players can also control the controlrods that destroy the neurtrons when colliding with them. The player can choose which rods to control
byclicking the switches on the bottom of the screen and then lower or raise the rods by using the up and down arrow keys. The player can also stop the rods by pressing the left arrow key.


This project has alot of small codes that interact with each other, partly through unity engine that connects the oublic parts of the codes. This project has alot of moving parts and different mechanics that
caused me to try and keep the code as optimized as possible while still trying to make the game as big as possible to better simulate a real nuclear reactin. I also tried to write the code so it would be easier to test
utilizing public parameters I could change from the unity engine

Here I will very briefly try to describe the different codes I created:
  sceneManagerScript.cs
    -This script handels the scene canhging. In this game htere is only one change from the strat screen to the game itself
  spawner.cs
    -This scrip is ran when strating the game. This script is responsiple for spawnign all the object to the screen that are needed in the beginning. After that this script is no more used
  uranium.cs 
    -THis scrips controls the uranium elemnts on the screen. The uranium elements will spontaniously fire neutron into random directions and compust into U235 object.
  U235Script.cs
    -This script controls the u235 object in the game. If a neutron collides with u235 element this object will be destroyed and it will spawn two new neutrons and a uranium object
  waterSCript.cs
    -This will control the water block under every uranium objec. These blokcs will spontaniously destroy the neutrons, but will also "heat" up and change color when neutron passes though them. WIll eventually boil is water flow not big enough
  flowGaugeScrips.cs
    - This control the "water flow" aka how fast the water script changes the color of the water blocks. It is controlled but player by clicking buttons
    These buttons have scripts flwoDownScript and FlowUpScript. 
absorbSccript.cs
  -This script control the control rods that the player can move up and dow using the arrow keys. 
  
