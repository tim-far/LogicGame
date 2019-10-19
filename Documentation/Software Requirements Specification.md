\&lt;Project Name\&gt;

Software Requirements Specification

For \&lt;Subsystem or Feature\&gt;



Version \&lt;0.9\&gt;

Revision History

| **Date** | **Version** | **Description** | **Author** |
| --- | --- | --- | --- |
| 17.10.2019 | 0.9 | First Implementation of SRS | Team LogicGame |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |

Table of Contents

|         Introduction        |
| --- |
|         Purpose        |
|         Scope        |
|         Definitions, Acronyms, and Abbreviations        |
|         References        |
|         Overview        |
|         Overall Description        |
|         Specific Requirements        |
|         Functionality        |
| 3.1.1        Simulation of the function of logical gates        |
| 3.1.2        Mastering levels to progress        |
|         Usability        |
|         Reliability        |
|         Performance        |
|         Supportability        |
|         Design Constraints        |
|         On-line User Documentation and Help System Requirements        |
|         Purchased Components        |
|         Interfaces        |
| 3.9.1        User Interfaces        |
| 3.9.2        Hardware Interfaces        |
| 3.9.3        Software Interfaces        |
| 3.9.4        Communications Interfaces        |
|         Licensing Requirements        |
|         Legal, Copyright, and Other Notices        |
|         Applicable Standards        |
|         Supporting Information        |
| Software Requirements Specification |

1. 1.Introduction

1.
  1. 1.1Purpose

This Software Requirements Specification was created to collect and organize the requirements for the LogicGame Android App. It includes a thorough description of the expected functionality for the project, as well as the nonfunctional requirements. These are crucial for the purposes of establishing the understanding between the suppliers of the software and the customers, as well as minimizing the risks connected to the misinterpreting customer&#39;s expectations. The document will furthermore provide the basis for costs-estimation and later validation of the results achieved.

1.
  1. 1.2Scope

This SRS applies to the entire LogicGame project. The LogicGame is a free android game. In the game you will have to give power to the logical gates inlets of the circuit. The gates have different logic functions behind them. There are for examples OR, AND and NAND gates. If you give power to the wrong inlet of the gates or even give power to the wrong gates, the light bulb won&#39;t lit. The goal is to make the light bulb lit. So you will have to understand how the different gates work and use that knowledge to solve the levels.

1.
  1. 1.3Definitions, Acronyms, and Abbreviations

| **Abbrevation** |   |
| --- | --- |
| SRS | Software Requirements Specification |
| UC | Use Case |
| n/a | not applicable |
| tbd | to be determined |
| MTTR | Mean Time To Repair |
| FAQ | Frequently asked Questions |
| Definition |   |
| Software Requirements Specification | a document, which captures the complete software requirements for the system, or a portion of the system. |
| Use Case | a list of actions or event steps, typically defining the interactions between a role (known in the Unified Modeling Language as an actor) and a system, to achieve a goal. |
| Mean Time to Repair | How long is the system allowed to be out of operation after it has failed? |

1.
  1. 1.4References

| **Title** | **Date** |
| --- | --- |
| [LogicGame Blog](https://logicgame775066249.wordpress.com/) | 17.10.2019 |
| [YouTrack](https://logicgame.myjetbrains.com/youtrack/dashboard?id=c5f49a91-56ed-41ee-a5d4-c1443ead1f98) | 17.10.2019 |
| [Github](https://github.com/tim-far/LogicGame) | 17.10.2019 |

1.
  1. 1.5Overview

The following chapters are about our vision and perspective, the software requirements, the demands we have and the technical realization of this project.

1. 2.Overall Description

1.
  1. 2.1Vision

The goal of this project is making it easy to understand how logic circuits work. The player should learn very fast about the different types of gates such as OR, XOR et cetera. It&#39;s supposed to be educational gaming and therefor it could be used in schools. We would see the project as a complete success if it would motivate children and help them learn about logic circuits and gates.

1.
  1. 2.2Use Case Diagram

to be determined

1. 3.Specific Requirements

1.
  1. 3.1Functionality

1.
  1.
    1. 3.1.1Simulation of the function of logical gates

The LogicGame simulates the function of logical gates like OR, AND, NOR or NAND gates. The purpose of this game is to improve the players knowledge about logic circuits.

1.
  1.
    1. 3.1.2Mastering levels to progress

The LogicGame includes serveral levels which can be solved by the player. The further the player progresses the more difficult the level gets.



1.
  1. 3.2Usability

We plan on designing the user interface as intuitive and self-explanatory as possible to make the user feel as comfortable as possible playing the game. Help documents will not be necessary.

3.2.1 No training time needed

Our goal is that a user installs the android application, opens it, gets a small introduction screen and is able to use all features without any explanation or help.

3.2.1 Familiar feeling

Developing an android game with Unity makes the player have familiar experiences with the controls as in other games of the same genre.

1.
  1. 3.3Reliability

The availability of our game is at 100% as we are not using a server-client architecture. The game is installed local on the phone&#39;s storage. After the installation there is no connection to the internet needed.

If a bug is discovered, we will fix it and load the new version of the game into the app store. People who already have the game on their phone will receive an update from the app store. Sometimes the game will require an update due to new android versions. Depending on how successful the game is, we will continuously adjust it to the new android version.

1.
  1. 3.4Performance

The game should be running in real time without any delays. Playing a game that&#39;s &quot;laggy&quot; isn&#39;t fun. There might be old phones though, which have issues with the performance since their hardware is too slow. The average android phone should be able to run the game without any performance issues, since we keep the graphics simple and there are no fast moving objects in the game. In order to have a good gaming experience the phone should be able to run the game with at least 30 frames per second.

1.
  1. 3.5Supportability

The game is created with Unity, which should make it easy to adjust it to new Android versions. In the Android app store, it&#39;s possible to report bugs. Once we receive those, we will fix the bug and upload the new version of the game into the app store. We will talk more about standards once we know what standards we are using.

1.
  1. 3.6Design Constraints

to be determined

1.
  1. 3.7On-line User Documentation and Help System Requirements

not applicable (n/a)

1.
  1. 3.8Purchased Components

not applicable (n/a)

1.
  1. 3.9Interfaces

1.
  1.
    1. 3.9.1User Interfaces

- **Game start screen** showing the name of the game and a logo while launching the game
- **Level select screen** showing all available levels which can be selected to play them
- **Current Level** showing the current level that is played

1.
  1.
    1. 3.9.2Hardware Interfaces

to be determined

1.
  1.
    1. 3.9.3Software Interfaces

LogicGame should be running on all android devices with Android version 6.0 and above.

1.
  1.
    1. 3.9.4Communications Interfaces

not applicable (n/a)

1.
  1. 3.10Licensing Requirements

to be determined

1.
  1. 3.11Legal, Copyright, and Other Notices

to be determined

1.
  1. 3.12Applicable Standards

to be determined

1. 4.Supporting Information

For more Information contact us on our Blog: [https://logicgame775066249.wordpress.com/](https://logicgame775066249.wordpress.com/)

We appreciate every comment.