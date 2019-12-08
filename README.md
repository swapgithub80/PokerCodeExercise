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
2C 3H 4S 8C 9D 2H 3D 5S 9C AH : RightHand Wins.
2S 4S 4C 2D 4H 2H 3D 5S AH 9C :LeftHand Wins.
2S 3S 4S 6S 5S KS JS AS QS TS : RightHand Wins.
2H 3D 5S AH 9C 2C 3S 4D 6H 5C : RightHand Wins.
7H 7D 7C 7S KD 2S 3S 4S 6S 5S : RightHand Wins.
4H 8S 9C KD KH 2C 3H 4D 8C TD :LeftHand Wins.
7H 7D 7C 7S KD 2D 3H 5C 9S 2H :LeftHand Wins.



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

