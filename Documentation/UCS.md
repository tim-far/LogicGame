 Artifacts >  Requirements Artifact Set >  Use-Case Model... >  Use Case >  rup_ucspec.htm

<Project LogicGame>

Use Case Specification: <Use-Case Name>

 

Version <1.0>

## Revision History

| Date       | Version | Description                 | Author         |
|------------|---------|-----------------------------|----------------|
| 24.10.2019 | 1.0     | first implementation of UCS | Team LogicGame |
|            |         |                             |                |
|            |         |                             |                |
|            |         |                             |                |
 

 

 

 

 

 

 

 


Table of Contents

1.          Use-Case Name 

1.1      Brief Description     

2.          Flow of Events

2.1      Basic Flow     

2.2      Alternative Flows     

2.2.1       < First Alternative Flow >      

2.2.2       < Second Alternative Flow >      

3.          Special Requirements

3.1      < First Special Requirement >     

4.          Preconditions    

4.1      < Precondition One >     

5.          Postconditions    

5.1      < Postcondition One >     

6.          Extension Points

6.1      <Name of Extension Point>     


Use-Case Specification: <Use-Case Name>

1.                  Use-Case Name
[The following template is provided for a Use-Case Specification, which contains the textual properties of the use case.  This document is used with a requirements management tool, such as Rational RequisitePro, for specifying and marking the requirements within the use-case properties.

The use-case diagrams can be developed in a visual modeling tool, such as Rational Rose.  A use-case report (with all properties) may be generated with Rational SoDA.  For more information, see the tool mentors in the Rational Unified Process.]

1.1               Brief Description

User pushes the button to update the inputs of the gates. 

2.                  Flow of Events
2.1               Basic Flow
* the user clicks on the switch
* in consequence all connections outgoing from that switch will be updated and set to the value of the switch
* including the inputs of the connected gates
* each gate will compute the output based on its input signals
* the level controller is going to check whether the level is solved or not
* If it is not solved the user interface is going to draw the connection lines in a different color
* if it is solved the user can click the next level button which will load the next level or leave the level to the main menu

![](holimoli.jpg)

2.2               Alternative Flows

n/a

3.                  Special Requirements

n/a
 

4.                  Preconditions


4.1               Level selector
 
A level has to be selected. 
Take a look at the level selector Use Case Specification to get more information. 

5.                  Postconditions


5.1             Save progress
 
If the level has been solved the progress has to be saved. Otherwise the user will have to play the same level again. A new level is only unlocked after the old one has been solved. 

6.                  Extension Points

n/a
 