using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Adir Edri

/*
 
Question – Binary file

During the Corona period, many people watched a lot of movies at home and wanted to organize the information in their VOD library in a convenient way. 
A file is given that contains the following data about watching series in the VOD library of "Ronit":
  • Series name: unique name, up to 9 characters. (eg: Grey's Anatomy)
  • Episode number in the series - a whole number. (eg: 3)
  • Episode length - in minutes, whole number. (eg: 40 minutes)
  • ID. Renter to watch - 9 characters.
  • Rental cost for an episode in the series - actual number. (for example: NIS 19.90)

A program must be written to handle the following modules for renting the series:
  • Adding a new rental of an episode in the series - the user will enter a ID number. Renter to watch, name of series and episode in the series; If the episode in the series was previously rented by the lessor and exists in the file, a notification will be given to the user; Otherwise,
    an addition will be made to the end of the file, of the appropriate episode in the series including the rental cost for the episode 19.90, the length of the episode 40 minutes.
  • Search for episodes of a series for the lessor - the user will enter the ID number. lessor and the name of the series; All the episodes of the series rented to him must be searched and this number must be presented with an appropriate message.
    If no data is found, an appropriate message must be displayed.
  • Canceling a series - the user will enter a series name; All episodes of the series must be deleted from the file. 
    A notification must be given if there is no record or records in the file for the search data.
  • Production of a report according to T.Z. Tenant to view - the user will enter a T.Z. landlord. 
    All the episodes in all the series that the user rented must be shown (the order is not important). A message must be given if there is none.
  • Production of a payment report according to the current rental status - the user will enter a T.Z. landlord. 
    A payment report must be presented in accordance with all the episodes of the series that the tenant rented, while referring to the rental cost of an episode in the series. 
    A message must be given if there is none.

*/

namespace fiki33
{
    class Program    // Question 1 – Binary file
    {
        public static void AddPerek(string id, string name, int perek)   // Adding a new rental 
        {
            string id1 = "", name1 = "";   
            int perek1 = 0, len = 0;
            double price = 0;
            FileStream fs = new FileStream("C:/Users/adire/BinaryFile.bin", FileMode.Open, FileAccess.Read);    // Declaring a binary file exists for reading
            BinaryReader br = new BinaryReader(fs);     //  Binary file reader statement on the file we have opened for reading
            while (br.BaseStream.Position != br.BaseStream.Length)    
            {
                name1 = br.ReadString();     //  Import variables from the file to the following variables in order
                perek1 = br.ReadInt32();
                len = br.ReadInt32();
                id1 = br.ReadString();
                price = br.ReadDouble();

                if (id == id1 && name == name1 && perek == perek1) //  Data equality check
                {
                    Console.WriteLine("This Perek was rented");   
                    return;   
                }
            }
            br.Close();   //  We will continue if the episode has not been rented
            fs.Close();
            fs = new FileStream("C:/Users/adire/BinaryFile.bin", FileMode.Append, FileAccess.Write);   // Open binary file as write 
            BinaryWriter bw = new BinaryWriter(fs);   
            bw.Write(name);    // Update
            bw.Write(perek);
            bw.Write(40);
            bw.Write(id);
            bw.Write(19.90);
            Console.WriteLine("add successfully");      
            bw.Close();    
            fs.Close();

        }
        public static void SearchPerek(string id, string name)    // Chapter search function
        {
            string id1 = "", name1 = "";         
            int perek1 = 0, len = 0, counter=0;
            double price = 0;
            FileStream fs = new FileStream("C:/Users/adire/BinaryFile.bin", FileMode.Open, FileAccess.Read);    
            BinaryReader br = new BinaryReader(fs);     
            while (br.BaseStream.Position != br.BaseStream.Length)    
            {
                name1 = br.ReadString();       
                perek1 = br.ReadInt32();
                len = br.ReadInt32();
                id1 = br.ReadString();
                price = br.ReadDouble();

                if (id == id1 && name == name1)    
                {
                    Console.WriteLine("you rented episode {0} ", perek1);   
                    counter++;  
                }
            }
            if (counter == 0)    
            {
                Console.WriteLine("there is not a episodes that got rented from this user");   
                return;    
            }
            Console.WriteLine("in total you rented {0} episodes", counter);    

            br.Close();   
            fs.Close();

        }

        public static void DeletePerek(string name)     // Chapter delete function
        {
            string id1 = "", name1 = "";   
            int perek1 = 0, len = 0;
            double price = 0;
            bool flag = false;  
            FileStream fs = new FileStream("C:/Users/adire/BinaryFile.bin", FileMode.Open, FileAccess.Read);        
            BinaryReader br = new BinaryReader(fs);                                                                 
            FileStream fs1 = new FileStream("C:/Users/adire/BinaryFile1.bin", FileMode.Create, FileAccess.Write);   
            BinaryWriter bw = new BinaryWriter(fs1);                                                                
            while (br.BaseStream.Position != br.BaseStream.Length)                
            {
                name1 = br.ReadString();       
                perek1 = br.ReadInt32();
                len = br.ReadInt32();
                id1 = br.ReadString();
                price = br.ReadDouble();
                if (name1 != name)   
                {
                    bw.Write(name1);    
                    bw.Write(perek1);
                    bw.Write(len);
                    bw.Write(id1);
                    bw.Write(price);
                }  
                else          
                    flag = true;      
            }
            br.Close();    
            fs.Close();
            bw.Close();
            fs1.Close();
            if (flag)   
            {
                File.Delete("C:/Users/adire/BinaryFile.bin");   
                File.Move("C:/Users/adire/BinaryFile1.bin", "C:/Users/adire/BinaryFile.bin");  
            }
            else
                Console.WriteLine("this show doesnt exist");    
        }


        public static void SearchID(string id)    // Search function by ID
        {
            string id1 = "", name1 = "";    
            int perek1 = 0, len = 0, counter = 0;
            double price = 0;
            FileStream fs = new FileStream("C:/Users/adire/BinaryFile.bin", FileMode.Open, FileAccess.Read);    
            BinaryReader br = new BinaryReader(fs);    
            while (br.BaseStream.Position != br.BaseStream.Length)    
            {
                name1 = br.ReadString();   
                perek1 = br.ReadInt32();
                len = br.ReadInt32();
                id1 = br.ReadString();
                price = br.ReadDouble();
                if (id == id1)    
                {
                    Console.WriteLine("you rented episode: {0} in show {1}" , perek1 , name1);    
                    counter++;      
                }
            }
            if (counter == 0)    
            {
                Console.WriteLine("there is not a episodes that got rented from this user");  
                return;    
            }
            Console.WriteLine("in total you rented {0} episodes", counter);  
            br.Close();   
            fs.Close();
        }

        public static void Payment(string id)    //   Payment calculation function
        {
            string id1 = "", name1 = "";    
            int perek1 = 0, len = 0;
            double price = 0, counter = 0;
            bool flag = false;
            FileStream fs = new FileStream("C:/Users/adire/BinaryFile.bin", FileMode.Open, FileAccess.Read);    
            BinaryReader br = new BinaryReader(fs);   
            while (br.BaseStream.Position != br.BaseStream.Length)   
            {
                name1 = br.ReadString();    
                perek1 = br.ReadInt32();
                len = br.ReadInt32();
                id1 = br.ReadString();
                price = br.ReadDouble();
                if (id == id1)     
                {
                    counter += price;     
                    flag = true;   
                }
            }
            if (flag == false)   
            {
                Console.WriteLine("there is not a episodes that got rented from this user");   
                return;   
            }
            Console.WriteLine("in total price is {0}", counter);   

            br.Close();    
            fs.Close();

        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("C:/Users/adire/BinaryFile.bin", FileMode.Create, FileAccess.Write);       // Opening a new file for writing
            BinaryWriter bw = new BinaryWriter(fs);   // Defining a binary writer variable
            // 1                                 
            bw.Write("Dragon");                          //   Writing 10 records in the binary file
            bw.Write(6);
            bw.Write(20);
            bw.Write("208456725");
            bw.Write(19.90);

            // 2
            bw.Write("Pokemon");
            bw.Write(7);
            bw.Write(50);
            bw.Write("458136975");
            bw.Write(10.90);

            // 3
            bw.Write("One Piece");
            bw.Write(81);
            bw.Write(21);
            bw.Write("208745932");
            bw.Write(52.80);

            // 4
            bw.Write("Rick");
            bw.Write(24);
            bw.Write(15);
            bw.Write("159357482");
            bw.Write(15.90);

            // 5
            bw.Write("Suits");
            bw.Write(44);
            bw.Write(25);
            bw.Write("957486315");
            bw.Write(12.50);

            // 6
            bw.Write("Friends");
            bw.Write(142);
            bw.Write(30);
            bw.Write("457812963");
            bw.Write(80.50);

            // 7
            bw.Write("Limit");
            bw.Write(12);
            bw.Write(50);
            bw.Write("456454784");
            bw.Write(14.40);

            // 8
            bw.Write("The End");
            bw.Write(29);
            bw.Write(45);
            bw.Write("206945821");
            bw.Write(115.00);

            // 9
            bw.Write("Survivor");
            bw.Write(19);
            bw.Write(90);
            bw.Write("318459752");
            bw.Write(9.50);

            // 10
            bw.Write("FIKI");
            bw.Write(54);
            bw.Write(60);
            bw.Write("318459752");
            bw.Write(52.50);

            bw.Close();      // Closing the file and the writer
            fs.Close();

        }
    }
}
