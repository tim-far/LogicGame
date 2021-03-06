
# Software Requirements Specification



# 1. Introduction


##   1.1 Purpose

This Software Requirements Specification was created to collect and organize the requirements for the LogicGame Android App. It includes a thorough description of the expected functionality for the project, as well as the nonfunctional requirements. These are crucial for the purposes of establishing the understanding between the suppliers of the software and the customers, as well as minimizing the risks connected to the misinterpreting customer&#39;s expectations. The document will furthermore provide the basis for costs-estimation and later validation of the results achieved.


##   1.2 Scope

This SRS applies to the entire LogicGame project. The LogicGame is a free android game. In the game you will have to give power to the logical gates inlets of the circuit. The gates have different logic functions behind them. There are for examples OR, AND and NAND gates. If you give power to the wrong inlet of the gates or even give power to the wrong gates, the light bulb won&#39;t lit. The goal is to make the light bulb lit. So you will have to understand how the different gates work and use that knowledge to solve the levels.


##   1.3 Definitions, Acronyms, and Abbreviations


| **Abbrevation**                     | Definition                               |
|-------------------------------------|------------------------------------------|
| SRS                                 | Software Requirements Specification      |
| UC                                  | Use Case                                 |
| n/a                                 | not applicable                           |
| tbd                                 | to be determined                         |
| MTTR                                | Mean Time To Repair                      |
| FAQ                                 | Frequently asked Questions               |
| Software Requirements Specification | a document, which captures the complete software requirements for the system, or a portion of the system. |
| Use Case                            | a list of actions or event steps, typically defining the interactions between a role (known in the Unified Modeling Language as an actor) and a system, to achieve a goal. |
| Mean Time to Repair                 | How long is the system allowed to be out of operation after it has failed? |

## 1.4 References

| **Title** | **Date** |
| --- | --- |
| [LogicGame Blog](https://logicgame775066249.wordpress.com/) | 17.10.2019 |
| [YouTrack](https://logicgame.myjetbrains.com/youtrack/dashboard?id=c5f49a91-56ed-41ee-a5d4-c1443ead1f98) | 17.10.2019 |
| [Github](https://github.com/tim-far/LogicGame) | 17.10.2019 |


##   1.5 Overview

The following chapters are about our vision and perspective, the software requirements, the demands we have and the technical realization of this project.

# 2 Overall Description


##   2.1 Vision

Check out our blog and read our first blog post to get to know more about our vison. [https://logicgame775066249.wordpress.com/2019/10/02/introduction-of-our-idea/](https://logicgame775066249.wordpress.com/2019/10/02/introduction-of-our-idea/)

##   2.2 Use Case Diagram
https://github.com/tim-far/LogicGame/blob/master/Documentation/Use%20Case%20Diagram.PNG
![](Use%20Case%20Diagram.PNG)

## 2.3 Used tools (and team roles)

[https://logicgame775066249.wordpress.com/2019/10/15/tools-and-team-roles/](https://logicgame775066249.wordpress.com/2019/10/15/tools-and-team-roles/)

# 3 Specific Requirements


##   3.1 Functionality

### 3.1.1 load level use case

We described that use case in a use case specification document. You can access it here: [https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20load%20level.md](https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20load%20level.md)

###  3.1.2 draw level use case

For this use case we also created a use case specification document. You can access it here: [https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20draw%20level.md](https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20draw%20level.md)

###  3.1.3 draw level selector use case

For this use case we also created a use case specification document. You can access it here: [https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20draw%20level%20selector.md](https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20draw%20level%20selector.md)

###  3.1.4 exit game use case

For this use case we also created a use case specification document. You can access it here:
[https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20exit%20game.md](https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20exit%20game.md)

###  3.1.5 main menu use case

For this use case we also created a use case specification document. You can access it here:
[https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20main%20menu.md](https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20main%20menu.md)

###  3.1.6 play level use case

For this use case we also created a use case specification document. You can access it here:
[https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20play%20level.md](https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20play%20level.md)

##   3.2 Usability

We plan on designing the user interface as intuitive and self-explanatory as possible to make the user feel as comfortable as possible playing the game. Help documents will not be necessary.

### 3.2.1 No training time needed

Our goal is that a user installs the android application, opens it, gets a small introduction screen and is able to use all features without any explanation or help.

### 3.2.1 Familiar feeling

Developing an android game with Unity makes the player have familiar experiences with the controls as in other games of the same genre.


##   3.3 Reliability

The availability of our game is at 100% as we are not using a server-client architecture. The game is installed local on the phone&#39;s storage. After the installation there is no connection to the internet needed.

If a bug is discovered, we will fix it and load the new version of the game into the app store. People who already have the game on their phone will receive an update from the app store. Sometimes the game will require an update due to new android versions. Depending on how successful the game is, we will continuously adjust it to the new android version.


##  3.4 Performance

The game should be running in real time without any delays. Playing a game that&#39;s &quot;laggy&quot; isn&#39;t fun. There might be old phones though, which have issues with the performance since their hardware is too slow. The average android phone should be able to run the game without any performance issues, since we keep the graphics simple and there are no fast moving objects in the game. In order to have a good gaming experience the phone should be able to run the game with at least 30 frames per second.

## 3.5 Supportability

The game is created with Unity, which should make it easy to adjust it to new Android versions. In the Android app store, it&#39;s possible to report bugs. Once we receive those, we will fix the bug and upload the new version of the game into the app store. We will talk more about standards once we know what standards we are using.

## 3.6 Design Constraints

We wrote a blog post about that. You can access it here: [https://logicgame775066249.wordpress.com/2019/10/15/tools-and-team-roles/](https://logicgame775066249.wordpress.com/2019/10/15/tools-and-team-roles/)

## 3.7 On-line User Documentation and Help System Requirements

not applicable (n/a)

## 3.8 Purchased Components

not applicable (n/a)

## 3.9 Interfaces

### 3.9.1 User Interfaces

- **Game start screen** showing the name of the game and a logo while launching the game
- **Level select screen** showing all available levels which can be selected to play them
- **Current Level** showing the current level that is played

### 3.9.2 Hardware Interfaces

to be determined

### 3.9.3 Software Interfaces

LogicGame should be running on all android devices with Android version 6.0 and above.

###  3.9.4 Communications Interfaces

not applicable (n/a)

##  3.10 Licensing Requirements

* Github Student licence
* Unity license from Visual Studio Community (student account)
* YouTrack license from DHBW


##  3.11 Legal, Copyright, and Other Notices

to be determined


##  3.12 Applicable Standards

to be determined

# 4. Supporting Information

For more Information contact us on our Blog: [https://logicgame775066249.wordpress.com/](https://logicgame775066249.wordpress.com/)

We appreciate every comment.