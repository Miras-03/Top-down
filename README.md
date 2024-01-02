# Top-down
Top-down game which is made from Unity learn course

A top-down game with the objective of throwing food to hungry animals - who are stampeding towards you - before they can run past you.

Recap:

Functionality:
* The player can move left and right based on the user’s left and right key presses
* The player will not be able to leave the play area on either side
* The player can press the Spacebar to launch a projectile prefab,
* Projectile and Animals are removed from the scene if they leave the screen
* Animal selection and spawn location are randomized
* Animals spawn on a timed interval and walk down the screen 
* When animals get past the player, it triggers a “Game Over” message
* If a projectile collides with an animal, both objects are removed

Concepts & Skills:
* Random generation
* Local vs Global variables
* Perspective vs Isometric projections
* InvokeRepeating() to repeat code
* Colliders and Triggers 
* Override functions
