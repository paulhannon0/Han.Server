# VERB: POST
# PATH: /widgets

Feature: Create Widget

    Scenario: Request Successful

        Given a valid request body for the 'Create Widget' endpoint
        When the request is made
        Then the widget is created
        And the ID of the widget is returned in the Location response header
