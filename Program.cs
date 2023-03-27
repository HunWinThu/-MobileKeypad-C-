using System;

public class Keypad
{
    public static string OldPhonePad(string S)
    {
        string output = "";
        string[] numbers = {"", "&'(", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"};
        char[] str = S.ToCharArray();
        int i = 0;
        while (i < str.Length)
        {
            if (str[i] == ' ')
            {
                i++;
                continue;
            }

            if (str[i] == '#')
            {
                break;
            }

            int count = 0;
            while (i + 1 < str.Length && str[i] == str[i + 1])
            {
                if (count == 2 && ((str[i] >= '2' && str[i] <= '6' || (str[i] == '8') || (str[i + 1] == '*'))))
                {
                    break;
                }

                else if (count == 3 && (str[i] == '7' || str[i] == '9' || str[i+1] == '*'))
                {
                    break;
                }

                count++;
                i++;

                if (i == str.Length)
                {
                    break;
                }
            }
            
            if (str[i] == '7' || str[i] == '9')
            {
                output += (numbers[str[i] - 48][count % 4]);
            }
            
            else if (str[i] == '*')
            {
                int j = 1;
                while ((i + j < str.Length) && (str[i + j] == '*'))
                {
                    j++;
                }
                if (output.Length >= j)
                {
                    output = output.Substring(0, output.Length - j);
                }
                i += j - 1;
            }
            else
            {
                output += (numbers[str[i] - 48][count % 3]);
            }

            i++;
        }

        return output;
    }

    public static void Main(string[] args)
    {
        string str = "8 88777444666*664";
        string output = OldPhonePad(str);
        Console.WriteLine(output);
    }
}
