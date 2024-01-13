# ShooterDemo

Open the scene from the build setting.
Created windows biuld also if you want to play directly.
All assets use in project are free from asset store and packagemanager.
Audio's might have copyright issue(use them for fun/personal).

1. For the float effect, I created an animation clip and used it. In addition to the animation, I created a script to handle the position and rotation using DOTween. To check that, disable the animator component in the float prefab and enable the OnEnableHandler component in the child.
2. I created the glow effect using a material and post-processing. It is not as accurate as I expected, but it is nearly the same. For the fire effect, I used a fire particle system and a tree asset from the asset store. First, I added the tree and then added the fire as a child. Then, in the particle system, I enabled the shape property and set it to mesh renderer. Then, I assigned the tree mesh.
3. I created the shooting demo using the new input system demo and modified it to match our requirements. I used the arrow and bow for shooting. The bow has an animation and I downloaded it from the asset store.
4. When the arrow collides with an enemy or an object, it shows the VFX of blood and plays a clip.
5. I used a navmesh agent for the enemy and added a patrolling concept. It follows the player if it comes in its range.