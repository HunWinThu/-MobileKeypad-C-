# -MobileKeypad-C#
Coding Challenge from Iron Software 


The Keypad class includes a static method named OldPhonePad that accepts a string S and returns a string. Using an old telephone keypad mapping, the OldPhonePad method converts a string of numbers and symbols into a string of characters.
//public static string OldPhonePad(string S)
	1.	Define a string output to store the final converted string.
	2.	Define an array of strings numbers that contains the character mapping for each number on the old phone keypad.
	3.	Convert the input string S to a character array str.
	4.	Initialize a counter variable i to 0.
	5.	Loop through each character in the str array using the i counter variable.
	6.	Check if the current character is a space. If yes, then skip to the next character.
	7.	Check if the current character is a pound (#) symbol. If yes, then exit the loop.
	8.	Initialize a counter variable count to 0.
	9.	Loop through the consecutive characters in the str array that are equal to the current character and increment the count variable. If the count variable reaches the maximum for the current number and there are more consecutive characters of the same type, then break the loop. This is because each number on the old phone keypad has a different maximum number of consecutive characters it can represent. For example, the number 2 can represent up to 3 consecutive characters (A, B, or C) whereas the number 7 can represent up to 4 consecutive characters (P, Q, R, or S).
	10.	If the current character is 7 or 9, then append the character corresponding to the current count value modulo 4 from the numbers array to the output string.
	11.	If the current character is an asterisk (*), then find the number of consecutive asterisks that follow it and remove that number of characters from the end of the output string.
	12.	If the current character is not 7, 9, or an asterisk, then append the character corresponding to the current count value modulo 3 from the numbers array to the output string.
	13.	Increment the i counter variable to move on to the next character in the str array.
	14.	Return the output string.
