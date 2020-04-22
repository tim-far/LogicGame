# Software Architecture Document  



## Introduction 

### Purpose 

This document provides a comprehensive architectural overview of the system, using a number of different architectural views to depict different aspects of the system. It is intended to capture and convey the significant architectural decisions which have been made on the system. 

### Scope 

This document describes the technical architecture of the LogicGame project, including the classes and use cases. 

### Definitions, Acronyms, and Abbreviations 

| Abbrevation | Description                       |
|-------------|-----------------------------------|
| API         | Application programming interface |
| SRS       |	Software requirements specification |
| UC	|Use case |
| VCS|	Version control system |
|n/a	|not applicable |
| tbd |	to be determined|
| API         | Application programming interface |



### References 

| Title                         | link                                     |
|-------------------------------|------------------------------------------|
| SRS                           | https://github.com/tim-far/LogicGame/blob/master/Documentation/Software%20Requirements%20Specification.md |
| UCS draw level selector              | https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20draw%20level%20selector.md |
| UCS draw level		| https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20draw%20level.md	|
| UCS load level		| https://github.com/tim-far/LogicGame/blob/master/Documentation/UCS%20load%20level.md  |
| mock up play level            | https://github.com/tim-far/LogicGame/blob/master/Documentation/mock%20up%20play%20level.jpg |
| mock up select level          | https://github.com/tim-far/LogicGame/blob/master/Documentation/mock%20up%20select%20level.jpg |
| mock up draw level            | https://github.com/tim-far/LogicGame/blob/master/Documentation/mock%20up%20play%20level.jpg	|

### Overview 

This document contains the goals and constraints as well as the logical, deployment and implementation.

## Architectural Representation  

Every object is a separate entity and therefore no typical architecture is represented by Unity. The used architecture is the component architecture. The architecture with the most similarities for one entity would be MVC. The code represents the controller and the in-game objects can be compared to the view in MVC.

## Architectural Goals and Constraints  

The final goal for this game project would be having multiple levels that can be selected and played. We want to have an overview where you can select the level.   
Every level is supposed to be different. The higher the level the more difficult it should be. 

## Use-Case View  

1[](Use%20Case.png)

### Use-Case Realizations 

n/a

 
## Logical View  

### Overview 

![](component%20architecture.png)



### Architecturally Significant Design Packages 

![](Class%20Diagram.PNG)

## Deployment View  

tbd

## Implementation View
 n/a
