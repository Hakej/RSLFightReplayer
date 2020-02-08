# RSLFightReplayer
Automatical fight replayer for RAID: Shadow Legends on PC

## What is needed?
1. You need to run Bluestacks as a maximized non-fullscreen application in 1600x900.
2. Your desktop resolution has to be 1920x1080.
3. You need to add "Tap spot" in Bluestacks on a Replay Button place and bind it to R button on the keyboard.
Program was not tested on any other emulator.

## How does it work?
For now, program takes a screenshot every second and checks if there are 3 buttons in the bottom right corner (Replay/Edit Team/Next). If it finds these, it simply simulates R button keyboard input. It will do that every second as long as it sees these 3 buttons. After that, it adds 1 to fight counter. It will repeat that until fight counter matches the number of your input.

## Future plans
Probably make detection more dynamic, i.e. check whole screen instead of a specific place on the screen for those 3 buttons or any other indication of a victory. That would result in less restricted rules like emulator/desktop resolution.
