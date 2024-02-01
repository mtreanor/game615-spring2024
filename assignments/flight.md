# Assignment 3: Flight Simulator

**Name your Unity project `flight`**

## Description
Create a very basic flight simulator where the player attempts to collect objects spread around the sky as they fly over a terrain. The number of items that have been collected should be displayed on the screen. In addition to the plane movement and collection, you need to **complete at least two of the following challenges**.

## Challenges
- Make the plane enjoyable to control. The [example code](https://github.com/mtreanor/game615-spring2024/blob/main/examples/flight/Assets/PlaneScript.cs) feels terrible to control. Spend time analyzing better flight simulators, and incorporate additional factors to the rotation and movement code to make it better.
- Display a timer on the screen. If the player fails to collect all the collectable items before it reaches zero, destroy the player and display a "You Lose" message of some sort.
- Make it so the plane can create and launch items forward towards some target (i.e. it can shoot stuff). Something should happen when the launched item collides with the other object (e.g. score should increase or something).
- Make the plane always be slowing down, and have the speed pick up when it collides with one of the collectable items. This can be done by making the speed variable always be decreasing a small amount in Update, and then increase it when the player collides with the item.
- Make it so the plane will crash if it runs into anything other than the collectable items. When the plane crashes, it should return to its starting position.

## Turning in your assignment
You will be turning in your assignment by pushing both your Unity project to your Github as well as a WebGL build of your game.

**Don't forget your `.gitignore` file!**

### Building your game for the Web
- In Unity, open the Build Settings (File > Build Settings...)
- Click the Add Open Scenes button
- Select "WebGL" and then click the "Switch Platform" button
Remember to modify your player settings (remember to disable compression in the Publishing settings - this is described in more detail on the setup page).
- Click the "Build" button
- When it asks you where you want to put your build, create a folder titled `flight` in your "games" folder located in your main repository for the class (game615-spring2024). Once you do this, it will take several minutes to build your game, and then you can commit and push your build. After five or so minutes it should be playable at: 

```
    http://YOUR_GITHUB_USERNAME.github.io/game615-spring2024/games/flight
```

- If it doesn't work, you may need to take a closer look at the setup instructions.