
# Test plan

## 1.	Introduction
### 1.1	Purpose
The purpose of the Iteration Test Plan is to gather all of the information necessary to plan and control the test effort for a given iteration. 
It describes the approach to testing the software.
This Test Plan for vnv supports the following objectives:
-	Identifies the items that should be targeted by the tests.
-	Identifies the motivation for and ideas behind the test areas to be covered.
-	Outlines the testing approach that will be used.
-	Identifies the required resources and provides an estimate of the test efforts.

### 1.2	Scope
This document describes the used tests, as they are unittests and functionality testing.

### 1.3	Intended Audience
This document is meant for internal use primarily.

### 1.4	Document Terminology and Acronyms
- **SRS**	Software Requirements Specification
- **vnv**	verleihen, Dienstleistungen, verschenken
- **n/a**	not applicable
- **tbd**	to be determined
- **AAI**	Authentication and Authorization Infrastructure

### 1.5	 References
- [GitHub](https://github.com/WMerk/VnVProject)
- [Blog](https://vnvproject.wordpress.com/)
- [Overall Use case diagram](https://github.com/WMerk/VnVProject/blob/master/doc/use%20cases/SRS.png)
- [Software Requirements Specification](SRS.MD)
- [Software Architecture Document](SAD.MD)
- [Function points](https://github.com/WMerk/vnvDoc/blob/master/doc/FP.pdf)
- [UC Delete friend](UC_DeleteFriend.MD)
- [UC Accept friend requests](UC_AcceptFriendRequest.MD)
- [UC List received friend requests](UC_ListReceivedFriendRequests.MD)
- [UC List sent friend requests](UC_ListSentFriendRequests.MD)
- [UC Add friend](UC_AddFriend.MD)
- [UC ChangePassword](UC_ChangePassword.MD)
- [UC Create new request](UC_CreateNewRequest.MD)
- [UC Create new offer](UC_CreateNewOffer.MD)
- [UC List requests](UC_ListRequests.MD)
- [UC List offers](UC_ListOffers.MD)
- [UC Search for offers or requests](UC_SearchOffersRequests.MD)
- [UC Edit status of offer / request](UC_EditStatus.MD)
- [UC DeleteAccount](UC_DeleteAccount.MD)
- [UC EditProfile](UC_EditProfile.MD)
- [UC Login](UC_Login.MD)
- [UC Register](UC_Register.MD)
- [UC Register/Login with Google](UC_RegisterLoginGoogle.MD)

## 2.	Evaluation Mission and Test Motivation
### 2.1	Background
By testing our project, we make sure that all changes to the sourcecode do not break the functionality. Also by integrating the test process in our deployment process, we make sure that only working versions of our project getting deployed. So the web application is always available.
### 2.2	Evaluation Mission
Our motivation in implementing tests came at an early stage to recognize the need for errors and to ensure the functionality and thus the outstanding quality of the software.
### 2.3	Test Motivators
Our testing is motivated by 
- quality risks 
- technical risks, 
- use cases 
- functional requirements

## 3.	Target Test Items
The listing below identifies those test items (software, hardware, and supporting product elements) that have been identified as targets for testing. This list represents what items will be tested. 

Items for Testing:
- java backend
- web frontend
- database operations

## 4.	Outline of Planned Tests
### 4.1	Outline of Test Inclusions
Unit testing the Java backend, functional testing of the Web frondend and Database Integrity Testing
### 4.2	Outline of Other Candidates for Potential Inclusion
Stress testing the application, unit testing the frontend or profile testing the java backend might be potential test cases but these are not in scope of our testing process yet.

## 5.	Test Approach
### 5.1	Testing Techniques and Types
#### 5.1.1	Function and Database Integrity Testing
|| |
|---|---|
|Technique Objective  	| Exercise target-of-test functionality, including navigation, data entry, processing, and retrieval to observe and log target behavior. |
|Technique 		|  Execute each use-case scenario’s individual use-case flows or functions and features, using valid and invalid data, to verify that: the expected results occur when valid data is used; the appropriate error or warning messages are displayed when invalid data is used; each business rule is properly applied. Selenium can simulate all user interactions like clicks, swipes and more. |
|Oracles 		|  user enter valid data, for example a valid username and a valid password   |
|Required Tools 	| Selenium + Cucumber	 |
|Success Criteria	|    successful senarios         |
|Special Considerations	|     -          |

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
An installation test was successfully done by [Mathinator](https://vnvproject.wordpress.com/2017/06/12/continuous-integration/).

## 6.	Entry and Exit Criteria
### 6.1	Test Plan
#### 6.1.1	Test Plan Entry Criteria
Building a new version of the software will execute the testprocess.
#### 6.1.2	Test Plan Exit Criteria
When all tests pass without throwing an exception .

## 7.	Deliverables
### 7.1	Test Evaluation Summaries
https://sonarcloud.io/component_measures/domain/Coverage?id=de.dhbw.ka.vnv%3Avnvproject
### 7.2	Reporting on Test Coverage
https://sonarcloud.io/component_measures/metric/coverage/tree?id=de.dhbw.ka.vnv%3Avnvproject
### 7.3	Perceived Quality Reports
n/a
### 7.4	Incident Logs and Change Requests
n/a
### 7.5	Smoke Test Suite and Supporting Test Scripts
n/a
### 7.6	Additional Work Products
n/a
#### 7.6.1	Detailed Test Results
When executing functiontests cucumber will atomaticly generate a [HTML test report](https://cdn.rawgit.com/WMerk/vnv/master/src/test/features/Reports/cucumber-htmlreport/index.html).
for Unittest testreports see section 7.2.
#### 7.6.2	Additional Automated Functional Test Scripts
n/a
#### 7.6.3	Test Guidelines
n/a
#### 7.6.4	Traceability Matrices
n/a
## 8.	Testing Workflow
At the moment tests are automatically ran before deployment on the server. The application is build using maven. Building the application with maven install will run all (feature tests and) unittest and only build if the tests complete. This can be triggered by a commit to github.

## 9.	Environmental Needs
[This section presents the non-human resources required for the Test Plan.]
### 9.1	Base System Hardware
The following table sets forth the system resources for the test effort presented in this Test Plan.

| Resource | Quantity | Name and Type |
|---|---|---|
| Integration Server | 1 | Debian Server |
| Server Name |  	| dhbw-projekt.data.kit.edu |
| Development Server	| 1 | <Server>	|
| Server Name |  | localhost |
| Database | 2 | <Name>	|
| Docker builds Server | 1 | Debian Server |
| Server Name |  	| dhbw-projekt.data.kit.edu |

### 9.2	Base Software Elements in the Test Environment
The following base software elements are required in the test environment for this Test Plan.

| Software Element Name | Version | Type and Other Notes |
|---|---|---|
| Windows | 10 | Operating System |
| Chrome |  58	| Internet Browser |
| Chromedriver |  11 | Application |

### 9.3	Productivity and Support Tools
The following tools will be employed to support the test process for this Test Plan.

| Tool Category or Type | Tool Brand Name | Vendor or In-house | Version |
|---|---|---|---|
| Test Management | Intellij | JetBrains | 17.2 |
| Project Management | YouTrack | JetBrains |  |
| DBMS tools |	 | 	 | 	 |
| Image builder | Docker | Docker | 	 |
| Image hoster | Docker Hub | Docker | 	 |

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
| Database Administrator, Database Manager | 1 | Ensures test data (database) environment and assets are managed and maintained.<br> Responsibilities include:<br> support the administration of test data and test beds (database). |
| Implementer | 3| Implements and unit tests the test classes and test packages.<br> Responsibilities include:<br> creates the test components required to support testability requirements as defined by the designer |

### 10.2	Staffing and Training Needs
n/a
## 11.	Iteration Milestones

| Milestone | Planned Start Date | Actual Start Date | Planned End Date | Actual End Date |
|---|---|---|---|---|
| Have Unit Tests | 01.11.2016 | 03.11.2016 | 14.11.2016 | 14.11.2016 |
| Have Integration Tests | 01.11.2016 | 010.11.2016 | 14.11.2016 | 14.11.2016 |
| > 20% Test Coverage | 14.11.2016 | 14.11.2016 | 20.11.2016 | 20.11.2016 |
| Tests integrated in CI | 06.05.2017 | 06.05.2017 | 12.06.2017 | 12.06.2017 |
| Iteration ends |  | |  | |
		

		
		
		
		
[vnv]: https://raw.githubusercontent.com/WMerk/vnvDoc/master/logo/logo_wide_big.png "vnv logo"
