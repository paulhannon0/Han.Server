# VERB: POST
# PATH: /widgets

Feature: Create Widget

    Scenario: Request Successful

        Given a valid request body for the 'Create Widget' endpoint
        When the request is made
        Then (201) Created is returned
