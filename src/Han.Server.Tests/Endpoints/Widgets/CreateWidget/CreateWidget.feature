# VERB: POST
# PATH: /widgets

Feature: Create Widget

    Scenario: Request Successful

        Given a valid request body for the 'Create Widget' endpoint
        When the request is made
        Then (201) Created is returned

    Scenario: Request Failure - Invalid Name body parameter

        Given a request body for the 'Create Widget' endpoint containing an invalid Name parameter
        When the request is made
        Then (400) Bad Request is returned
