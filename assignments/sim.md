# Assignment 5: Simulation Game

**Name your Unity project `sim`**

## Description

Create a **tiny** simulation / realtime strategy game.

## Resources
- [Sample Project from Class](../examples/units/Assets)

## Turning in your assignment
You will be turning in your assignment by pushing both your Unity project to your Github as well as a WebGL build of your game.

**Don't forget your `.gitignore` file!**

### Building your game for the Web
- In Unity, open the Build Settings (File > Build Settings...)
- Click the Add Open Scenes button
- Select "WebGL" and then click the "Switch Platform" button
Remember to modify your player settings (remember to disable compression in the Publishing settings - this is described in more detail on the setup page).
- Click the "Build" button
- When it asks you where you want to put your build, create a folder titled `sim` in your "games" folder located in your main repository for the class (game615-spring2024). Once you do this, it will take several minutes to build your game, and then you can commit and push your build. After five or so minutes it should be playable at: 

```
    http://YOUR_GITHUB_USERNAME.github.io/game615-spring2024/games/sim
```

- If it doesn't work, you may need to take a closer look at the setup instructions.