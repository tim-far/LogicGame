

<Project LogicGame>

Use Case Specification: <Use-Case load level>


1.                 load level


1.1               Brief Description

User selects the level that's being played. 

2.                  Flow of Events
2.1               Basic Flow
* the user clicks on a level which is listed on the level select screen
* the chosen level will be initialized based on the unique ID shown in the level selector
* after that the level selector will check if the level is already unlocked
* if it is not unlocked the user cannot play and the game stays in the level selector
* if it is unlocked the game will load the level from file
* the level is done initializing by loading the gates and connections and the UI will switch to the level screen


2.1.1 Activity Diagram

![](activity%20diagram%20load%20level.jpg)

2.1.2 Mock Up

![](mock%20up%20select%20level.jpg)

2.2               Alternative Flows

n/a

3.                  Special Requirements

n/a
 

4.                  Preconditions


4.1               Level selector
 
The game has to be launched. 


5.                  Postconditions


5.1             Play level
 
Take a look at the play level Use Case Specification to get more information. 

6.                  Extension Points

n/a

7. Function Points


![](FP%20for%20UC%20load%20level.png)


![](FP%20for%20entire%20Project.png)

(Complexity Adjustment Table stays for every use case the same)

![](Result%20FP%20for%20UC%20load%20level.png)


 