using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Targil2

// Adir Edri

/*
Question – text file


In a text file there are x strings, where before each string there is an integer of type int indicating its size, and then a sequence of this length of characters representing the string itself. 
Each string consists of uppercase and lowercase letters only. Each string is on a separate line. For example, if x is 4 the file logically could look like this:

6aBCdeD
8aaBTRyAC
4aaAA
2AB

That is, there are 4 strings in the file, the first is 6 letters long and is "aBCdeD", the second is 8 letters long and is "aaBTRyAC" and so on. Assume that the number is no more than two digits.
Write a program that will read from the file and build a new text file that contains only the lowercase letters that appear in each of the original strings. 
At the beginning of the line will be displayed a number describing the amount of characters that are lowercase letters in the string. 
If there are no lowercase letters in the string, the character 0 will be displayed. Example of output on the example file:

3ade
3aay
2aa
0


*/


{
    class Program
    {
        static void Main(string[] args)
        {
            try      
            {

                FileStream fs = new FileStream("C:/Users/adire/OneDrive/Desktop/TextFile.txt", FileMode.Create, FileAccess.Write);   
                FileStream fs1 = new FileStream("C:/Users/adire/OneDrive/Desktop/TextFile1.txt", FileMode.Create, FileAccess.Write);    
                StreamWriter sw = new StreamWriter(fs);       
                StreamWriter sw1 = new StreamWriter(fs1);
                sw.Write("6");                            
                sw.WriteLine("aBCdeD");
                sw.Write("8");
                sw.WriteLine("aaBTRyAC");
                sw.Write("4");
                sw.WriteLine("aaAA");
                sw.Write("2");
                sw.WriteLine("AB");
                sw.Close();   
                fs = new FileStream("C:/Users/adire/OneDrive/Desktop/TextFile.txt", FileMode.Open, FileAccess.Read);    
                StreamReader sr = new StreamReader(fs);   
                string text = "", text1;    
                int count;
                text = sr.ReadLine();   

                while (text != null)     
                {
                    text1 = "";    
                    count = 0;
                    
                    for (int i = 0; i < text.Length; i++)          
                    {
                        if (text[i] >= 'a' && text[i] <= 'z') 
                        {
                            text1 += text[i];  
                            count++;    
                        }
                    }
                    sw1.Write(count);      
                    sw1.WriteLine(text1);
                    text = sr.ReadLine();     
                }
               sr.Close();     
               sw1.Close();
            }
            catch (FileNotFoundException e)     
            {
                Console.Out.WriteLine("File not found");   
            }
        }
    }
}
