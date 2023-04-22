using System;

public class Keypad
{
    private readonly string[] _numbers = {" ", "&'(", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"};

    private int _previousButton = -1;
    private int _letterIndex = 0;
    private DateTime _lastKeyPressTime = DateTime.MinValue;

    public string GetLettersForButton(int button)
    {
        if (button == _previousButton && DateTime.Now - _lastKeyPressTime < TimeSpan.FromSeconds(1))
        {
            // If the same button is pressed within one second of the previous press, increment the letter index.
            _letterIndex = (_letterIndex + 1) % _numbers[button].Length;
            /*if (button == 0) // if '*' button is pressed, remove the previous character
            {
                _letterIndex = (_letterIndex - 1 + _numbers[_previousButton].Length) % _numbers[_previousButton].Length;

                
            }*/
            Console.CursorLeft--;
            Console.Write(" ");
            Console.CursorLeft--;
        }
        else
        {
            // Otherwise, reset the letter index and remember the current button and time.
            _letterIndex = 0;
            _previousButton = button;
            _lastKeyPressTime = DateTime.Now;
        }

        // Return the letter at the current index for the given button.
        return _numbers[button][_letterIndex].ToString();
    }

    public static void Main(string[] args)
    {
        Keypad keypad = new Keypad();

        while (true)
        {
            // Read the next character from the console input.
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.KeyChar == '\r') // If Enter is pressed, exit the loop.
            {
                break;
            }
            else if (input.KeyChar >= '0' && input.KeyChar <= '9') // If a digit is pressed, output the corresponding letters.
            {
                int button = int.Parse(input.KeyChar.ToString());
                string letters = keypad.GetLettersForButton(button);
                Console.Write(letters);
            }
            else if (input.KeyChar == '*') // If the * button is pressed, remove the previous character.
            {
                string letters = keypad.GetLettersForButton(keypad._previousButton);
                Console.Write("\b \b"); // Move the cursor back and overwrite the previous character with a space.
                if (letters.Length > 1) // If the button has multiple letters, move back and overwrite with the new letter.
                {
                    Console.Write("\b");
                }
            }
        }
    }
}
