# PokerCodeExercise
Requirements  :
Input to the system will consist of a string of 10 cards, the first 5 cards will represent the left hand and the remaining 5 cards will represent the right hand.  
For example, given the input of:  2H 5D JC AS 5H 4H QS 9S JD KH
Would translate to the left hand having:  2H 5D JC AS 5H 
1.	2 of Hearts
2.	5 of Diamonds
3.	Jack of Clubs
4.	Ace of Spades
5.	5 of Hearts
And the Right hand having:  4H QS 9S JD KH
1.	4 of Hearts
2.	Queen of Spades
3.	9 of Spades
4.	Jack of Diamonds
5.	King of Hearts
The application will read the input of hands and determine the winner or draw by outputting one of the following:
1.	Left Hand Wins
2.	Right Hand Wins
3.	Draw
Acceptance Criteria
1.	Determining the Winner
Given:  Left and Right hands represented by System Cards as the input to the system
Then:  The system should output the correct winner according to the Tie Breaker Rules table

2.	Determining a draw
Given:  Left and Right hands represented by System Cards as the input to the system
When:  Both hands result in a draw
Then:  The system should output “Draw”
Calculates the winner in poker using a subset of poker rules

Building
Load the file PokerGameConsoleApp.sln in Visual Studio, 
and build the PokerGameConsoleApp​ project.

Running
Run the PokerGameConsoleApp project, 
and at the command line enter the 
hands in the following format:
  

Tools Used :

VS2017 and ASP.Net 4.7.1 framework have been used to implement PokerHand Code Exercise.
Model: Card.
Common : CardDataValidations, PokerConstants.
Enums are used for Suit, Ranks and HandTypes.
Business logic created for game analysis of two hands.
Console App created to process a game.

Unit Tests
Unit tests are available in the PokerGameConsoleApp project,
and can be run through the test explorer.

Unit Tests are for analysing the winners 
for LeftHand,RightHand or whether it is a draw.

Validation tests are for the folowing:
Invalid Inputs,
Invalid Length,
Duplicate Cards,
Invalid Rank 
and Invalid Suit

