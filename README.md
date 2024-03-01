# Combustion Motors in GearBlocks!
This is a GearBlocks mod that aims to add combustion parts into the game. Piston parts simulate the thrust of an actual piston by applying downward thrust based on timing and the angle of the crank shaft.

## How to install
**Please refer to the GearLib documentation on how to setup BepInEx for your GearBlocks for modding.**

GearLib documentation here: https://github.com/KaBooMa/GearLib

Simply download the latest release and extract the CombustionMotors folder into your BepInEx/plugins folder.

## Tips
- Ensure you toggle off "Prevent interpenetration when attaching parts" when assembling your engine. Due to part collisions, this is a requirement at this time.
- Change Update Rate to 400 for a smoother running engine. It's more demanding on your PC, but allows the physics to keep up better!
- All parts of your engine MUST be attached fully for it to run. If anything is missing, it will by default not fire.
- Putting together an engine requires the following:
- - Engine Block
- - Crankshaft
- - Conrod
- - Piston
- - Cylinder
- - Cylinder Head
- - ECU
- Configure your timing and fire offset within the Cylinder Head.
- Adjust multiple variables for the engine and how it runs within your ECU.

## Credits
All models are maintained by SilverThorn (Thank you Silver ❤️!)\
Big thank you to Thebutheads, Pyro and MATT in the Discord for help getting the calculations dialed in for realism!!\
Lots of love to Unslinga for assistance with optimizing behaviours for better performance!!