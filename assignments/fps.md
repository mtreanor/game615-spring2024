# Assignment 2: Funny First Person (Shooter?)

**Name your Unity project `fps`**

Create a small first person game where at least two funny things happen. "Funny" is, of course, subjective, I mean pretty much just mean unexpected or wacky (or whatever you enjoy!). For example, you could round a corner and a bunch of chickens or something could explode everywhere.

In order to do this, you will need to make use of both the "Core Unity Skills" we covered in class, and also make use of the two "External Assets" (ProBuilder and the FirstPersonController Starter Asset)

## Core Unity Skills

- **Prefabs:** In order to instantiate objects in code, you will need to make a prefab. In the class example, this was the "confetto".
- **Instantiating Prefabs:** See AddForce example below.
- **Triggers:** Unity will call a function named "OnTriggerEnter" (if you've defined it), when two objects collide that have the following properties: 1. Both objects have colliders, 2. At least one of the colliders is marked as a trigger, and 3. At least one of the objects has a Rigidbody component. See [CubeScript.cs](https://github.com/mtreanor/game615-spring2024/blob/a417cd2a7028f8152a86dc470c57b0688a974254/examples/fps/Assets/CubeScript.cs#L30) for an example.
- **AddForce:** Not required, but as we are making a first person (fps) game, it would make sense to shoot something, right? You could make is so when the player presses the space bar, you instantiate something with a Rigidbody component, and then shoot it forward. To do this, you would add something like this to the Update function on a script on the player:

```
    if (Input.GetKeyDown(KeyCode.Space)) {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.AddForce(projectile.transform.forward * 500);
    }
```

## External Assets

- **ProBuilder:** ProBuilder is an official add-on for Unity that allows you to enhance your 3D modeling capabilities inside of Unity (without needing to use Maya or Blender). To get it installed, go to `Window->Package Manager`. From there, select Unity Registry from the dropdown in the top left, and then search for ProBuilder. Install it. Once you've done this, you will need to select `Tools->ProBuilder->ProBuilder Window` from the toolbar. Dock this window and you are ready.
- **First Person Controller:** Go [here](https://assetstore.unity.com/packages/essentials/starterassets-firstperson-updates-in-new-charactercontroller-pac-196525) to get a Unity developed first person controller. In order to get this in to your game, you will need to be logged in to both the Unity Asset Store (please don't add other assets at this point), and also be logged in to your Unity Hub application (with the same log in credentials). Use the package manager again, and select "My Assets" from the top left dropdown. It will ask you to import packages, reload using the 'new' input system, and maybe more. Say yes. If it restarts Unity, you may need to go back to the Package Manager and try again to install the First Person Controller.
- **Using the First Person Controller:** In the Unity Library, go to `Assets/StarterAssets/FirstPersonController/Preabs/NestedParent_Unpack` and drag that into the scene. In the hierarchy, right click on the `NestedParent_Unpack` object and select `Prefab->Unpack`. Next, delete the default 'Main Camera' that came with your scene (there's a new Camera in NestedParent_Unpack).

## Turning in your assignment
You will be turning in your assignment by pushing both your Unity project to your Github as well as a WebGL build of your game.

**Don't forget your `.gitignore` file!**

### Building your game for the Web
- In Unity, open the Build Settings (File > Build Settings...)
- Click the Add Open Scenes button
- Select "WebGL" and then click the "Switch Platform" button
Remember to modify your player settings (remember to disable compression in the Publishing settings - this is described in more detail on the setup page).
- Click the "Build" button
- When it asks you where you want to put your build, create a folder titled `fps` in your "games" folder located in your main repository for the class (game615-spring2024). Once you do this, it will take several minutes to build your game, and then you can commit and push your build. After five or so minutes it should be playable at: 

```
    http://YOUR_GITHUB_USERNAME.github.io/game615-spring2024/games/fps
```

- If it doesn't work, you may need to take a closer look at the setup instructions.