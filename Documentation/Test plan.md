
# Test plan

## 1.	Introduction
### 1.1	Purpose
The purpose of the Iteration Test Plan is to gather all of the information necessary to plan and control the test effort for a given iteration. 
It describes the approach of testing the software.
This Test Plan supports the following objectives:
-	Identifies the items that should be targeted by the tests.
-	Identifies the motivation for and ideas behind the test areas to be covered.
-	Outlines the testing approach that will be used.
-	Identifies the required resources and provides an estimate of the test efforts.

### 1.2	Scope
This document describes the unit tests and their results.

### 1.3	Intended Audience
This document is mainly meant for internal use.

### 1.4	Document Terminology and Acronyms
- **SRS**	Software Requirements Specification
- **n/a**	not applicable
- **tbd**	to be determined
- **AAI**	Authentication and Authorization Infrastructure

### 1.5	 References
- [GitHub](https://github.com/tim-far/LogicGame)
- [Blog](https://logicgame775066249.wordpress.com/)
- [Overall Use case diagram](https://github.com/tim-far/LogicGame/blob/master/Documentation/Overall%20UseCase%20Semester%204.png)
- [Software Requirements Specification](https://github.com/tim-far/LogicGame/blob/master/Documentation/Software%20Requirements%20Specification.md)
- [Software Architecture Document](https://github.com/tim-far/LogicGame/blob/master/Documentation/Software%20Architecture%20Document.md)


## 2.	Evaluation Mission and Test Motivation
### 2.1	Background
By testing our project, we make sure that all changes to the source code do not break the functionality. Also by integrating the test process in our deployment process, we make sure that only working versions of our project getting deployed. 
### 2.2	Evaluation Mission
Our motivation in implementing tests came at an early stage to recognize the errors and to ensure the functionality and thus the outstanding quality of the software.
### 2.3	Test Motivators
Our testing is motivated by 
- quality risks 
- technical risks, 
- use cases 
- functional requirements

## 3.	Target Test Items
The listing below identifies those test items that have been identified as targets for testing. This list represents what items will be tested. 

Items for Testing:
- buttons in UC draw level selector
- element output in UC play level
- number and position of element loaded from file in UC load level

## 4.	Outline of Planned Tests
### 4.1	Outline of Test Inclusions
All of the tests are unit tests. 
### 4.2	Outline of Other Candidates for Potential Inclusion
Stress testing the application, function tests of the buttons are potential test cases but these are not in scope of our testing process yet.

## 5.	Test Approach
### 5.1	Testing Techniques and Types
#### 5.1.1	Function and Database Integrity Testing

n/a

#### 5.1.2	Unit Testing
|| |
|---|---|
|Technique Objective  	| Exercise functionality of model functions. Test for right data entry and right data output. |
|Technique 		|  Execute JUnit Test functions in UserTest.java |
|Oracles 		|  Each test expect the right value given in the assertequals function |
|Required Tools 	|  JUnit Test |
|Success Criteria	|    Testcoverage > 50%      |
|Special Considerations	|     -          |

#### 5.1.3	Business Cycle Testing
n/a

#### 5.1.4	User Interface Testing
n/a

#### 5.1.5	Performance Profiling 
n/a

#### 5.1.6	Load Testing
n/a

#### 5.1.7	Stress Testing
n/a
 
#### 5.1.8	Volume Testing
n/a

#### 5.1.9	Security and Access Control Testing
Unittests also cover access control. A given use case might only be performed by a given logged in user.

#### 5.1.10	Failover and Recovery Testing
n/a

#### 5.1.11	Configuration Testing
n/a

#### 5.1.12	Installation Testing


## 6.	Entry and Exit Criteria
### 6.1	Test Plan
#### 6.1.1	Test Plan Entry Criteria
Building a new version of the software will execute the test process.
#### 6.1.2	Test Plan Exit Criteria
When all tests pass without throwing an exception.

## 7.	Deliverables
### 7.1	Test Evaluation Summaries

### 7.2	Reporting on Test Coverage

### 7.3	Perceived Quality Reports
n/a
### 7.4	Incident Logs and Change Requests
n/a
### 7.5	Smoke Test Suite and Supporting Test Scripts
n/a
### 7.6	Additional Work Products
n/a
#### 7.6.1	Detailed Test Results

#### 7.6.2	Additional Automated Functional Test Scripts
n/a
#### 7.6.3	Test Guidelines
n/a
#### 7.6.4	Traceability Matrices
n/a
## 8.	Testing Workflow
At the moment tests are manually ran before deployment. The tests are built using unity. In unity you need to manually execute the test. If the test is successful the new build will be committed and pushed into github. 

## 9.	Environmental Needs

### 9.1	Base System Hardware
The following table sets forth the system resources for the test effort presented in this Test Plan.

| Resource | Quantity | Type |
|---|---|---|
| Workstation | 3 | Windows 10 with Unity 2018 |
| mobile Phone | 1 | Samsung Galaxy S9 with Android 9 |

### 9.2	Base Software Elements in the Test Environment
The following base software elements are required in the test environment for this Test Plan.

| Software Element Name | Version | Type and Other Notes |
|---|---|---|
| Windows | 10 | Operating System |
| Unity |  2018	| Game Engine |
| Android |  9 | Operating System |

### 9.3	Productivity and Support Tools
The following tools will be employed to support the test process for this Test Plan.

| Tool Category or Type | Tool Brand Name | Vendor or In-house | Version |
|---|---|---|---|
| Test Management | Unity | Unity | 2018 |
| Project Management | YouTrack | JetBrains |  |
| Filehosting | Github | Github | 	 |

## 10.	Responsibilities, Staffing, and Training Needs
### 10.1	People and Roles
This table shows the staffing assumptions for the test effort.

Human Resources


| Role | Minimum Resources Recommended (number of full-time roles allocated) |	Specific Responsibilities or Comments |
|---|---|---|
| Test Manager | 1 | Provides management oversight. <br> Responsibilities include: <br> planning and logistics <br> agree mission <br> identify motivators<br> acquire appropriate resources<br> present management reporting<br> advocate the interests of test<br>evaluate effectiveness of test effort |
| Test Designer | 1 | Defines the technical approach to the implementation of the test effort. <br> Responsibilities include:<br> define test approach<br> define test automation architecture<br> verify test techniques<br> define testability elements<br> structure test implementation|
| Tester | 1 |	Implements and executes the tests.<br> Responsibilities include:<br> implement tests and test suites<br> execute test suites<br> log results<br> analyze and recover from test failures<br> document incidents|
| Test System Administrator | 1 | Ensures test environment and assets are managed and maintained.<br> Responsibilities include:<br> 	administer test management system<br> install and support access to, and recovery of, test environment configurations and test labs | 
| Implementer | 3| Implements and unit tests the test classes and test packages.<br> Responsibilities include:<br> creates the test components required to support testability requirements as defined by the designer |

### 10.2	Staffing and Training Needs
n/a
## 11.	Iteration Milestones

| Milestone | Planned Start Date | Actual Start Date | Planned End Date | Actual End Date |
|---|---|---|---|---|
| Have Unit Tests | 08.05.2020 | 08.05.2020 | 08.05.2020 | 08.05.2020 |
| > 40% Test Coverage | 08.05.2020 | 08.05.2020 | 08.05.2020 | 08.05.2020 |
| Iteration ends |  | |  | |

## 12. Metrics

We also implemented two different metrics in our code. The first one was done with Codacy and the second one with CodeClimate. Since we were happy that our code is running, we didn't want to implement these Metrics in our actual code. So we created another branch for it on github.  [https://github.com/tim-far/LogicGame/tree/metrics](https://github.com/tim-far/LogicGame/tree/metrics)

In our blog we explain what we implemented and why we didn't implement other stuff. Go check that out too: 
[https://logicgame775066249.wordpress.com/2020/05/29/metrics/](https://logicgame775066249.wordpress.com/2020/05/29/metrics/)
You will find some screenshots of our implementations there as well.



