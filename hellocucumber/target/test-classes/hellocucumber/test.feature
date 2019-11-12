Feature: Gmail Login

  Scenario: Login
    Given Chrome is running
    And The windows is maximized
    And The login testpage is open
    When I enter the username
    And  I enter the password
    And I press enter
    Then the text at the bottom of the page should say "WELCOME :)"