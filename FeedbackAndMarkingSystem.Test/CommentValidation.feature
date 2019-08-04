Feature: ValidateComment

Scenario Outline: Comment Type single Input validation
Given the assessor has specified <assignmentCode> for the assignment code
And they have specified <title> as the title
And they have specified <commentText> for the comment text
And they have selected <commentType> as the comment type
And they have entered <value> for Comment Type value 
When they click submit
Then the result is <result>
And the message is '<message>'
Examples: 
    | assignmentCode | title                | commentText            | commentType | value | result | message                                                |
    | ABC-123456     | Sample title 123 !@# | Sample comment 123 !@# | Adjustment  | 4     | true   |                                                        |
    | ABC-12345      | Sample title 123 !@# | Sample comment 123 !@# | Adjustment  | 4     | false  | Assignment Code must be 10 characters                  |
    | ABC-1234567    | Sample title 123 !@# | Sample comment 123 !@# | Adjustment  | 4     | false  | Assignment Code must be 10 characters                  |
    |                | Sample title 123 !@# | Sample comment 123 !@# | Adjustment  | 4     | false  | Assignment Code is mandatory and must be 10 characters |
    | ABC-123456     |                      | Sample comment 123 !@# | Adjustment  | 4     | false  | Title field is mandatory                               |
    | ABC-123456     | Sample title 123 !@# | Sample comment 123 !@# | Adjustment  | 4     | true   |                                                        |
    | ABC-123456     | Sample title 123 !@# |                        | Adjustment  | 4     | false  | Comment Text field is mandatory                        |
    | ABC-123456     | Sample title 123 !@# | Sample comment 123 !@# |             | 0     | false  | Comment type field is mandatory                        |
	
Scenario Outline: Grade Band comment type Input validation
Given the assessor has specified ABC-123456 for the assignment code
And they have specified Sample title 123 !@# as the title
And they have specified Sample comment 123 !@# for the comment text
And they have selected Grade Band as the comment type
And they have entered <valueLower> for the Grade Band lower value 
And they have entered <valueUpper> for the Grade Band upper value 
When they click submit
Then the result is <result>
And the message is '<message>'
Examples: 
    | valueLower | valueUpper | result | message                                                |
    | -1         | 0          | false  | Lower Grade band value must be >= 0                    |
    | -1         | 1          | false  | Lower Grade band value must be >= 0                    |
    | -1         | 2          | false  | Lower Grade band value must be >= 0                    |
    | -1         | 50         | false  | Lower Grade band value must be >= 0                    |
    | -1         | 99         | false  | Lower Grade band value must be >= 0                    |
    | -1         | 100        | false  | Lower Grade band value must be >= 0                    |
    | -1         | 101        | false  | Lower Grade band value must be >= 0                    |
    | 0          | 0          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 0          | 1          | true   |                                                        |
    | 0          | 2          | true   |                                                        |
    | 0          | 50         | true   |                                                        |
    | 0          | 99         | true   |                                                        |
    | 0          | 100        | true   |                                                        |
    | 0          | 101        | false  | Upper Grade band value must be <=100                   |
    | 1          | 0          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 1          | 1          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 1          | 2          | true   |                                                        |
    | 1          | 50         | true   |                                                        |
    | 1          | 99         | true   |                                                        |
    | 1          | 100        | true   |                                                        |
    | 1          | 101        | false  | Upper Grade band value must be <=100                   |
    | 50         | 0          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 50         | 1          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 50         | 2          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 50         | 50         | false  | Upper Grade Band value must be > the Lower Grade value |
    | 50         | 99         | true   |                                                        |
    | 50         | 100        | true   |                                                        |
    | 50         | 101        | false  | Upper Grade band value must be <=100                   |
    | 98         | 0          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 98         | 1          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 98         | 2          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 98         | 50         | false  | Upper Grade Band value must be > the Lower Grade value |
    | 98         | 99         | true   |                                                        |
    | 98         | 100        | true   |                                                        |
    | 98         | 101        | false  | Upper Grade band value must be <=100                   |
    | 99         | 0          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 99         | 1          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 99         | 2          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 99         | 50         | false  | Upper Grade Band value must be > the Lower Grade value |
    | 99         | 99         | false  | Upper Grade Band value must be > the Lower Grade value |
    | 99         | 100        | true   |                                                        |
    | 99         | 101        | false  | Upper Grade band value must be <=100                   |
    | 100        | 0          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 100        | 1          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 100        | 2          | false  | Upper Grade Band value must be > the Lower Grade value |
    | 100        | 50         | false  | Upper Grade Band value must be > the Lower Grade value |
    | 100        | 99         | false  | Upper Grade Band value must be > the Lower Grade value |
    | 100        | 100        | false  | Upper Grade Band value must be > the Lower Grade value |
    | 100        | 101        | false  | Upper Grade band value must be <=100                   |

	
