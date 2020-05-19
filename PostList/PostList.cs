using System;
using System.Collections.Generic;

namespace PostList
{
    class PostList
    {
        static void Main(string[] args)
        {
            // Skapar en tom stränglista för inlägg
            var postList = new List<string[]>();

            // Skriv rubrik till loggboken
            Console.WriteLine("Välkommen till Loggboken\n\r");

            bool showMenu = true;
            // Visa menyn så länge showMenu inte är false dvs "Exit"
            while (showMenu)
            {
                //Visa menyn
                ShowMenu();
                // Menyval
                switch (Console.ReadLine())
                {
                    case "1":
                        // Skapa en postvektor med tre element, den tredje är datum och tid
                        string[]post = new string[3];
                        // Lägg till posttitel
                        Console.WriteLine("Skriv en inläggstitel:");
                        post[0] = Console.ReadLine();
                        
                        // Lägg till posttext
                        Console.WriteLine("Skriv inläggstext");
                        post[1] = Console.ReadLine();

                        // Spara datumtid för inlägget
                        post[2] = DateTime.Now.ToString();

                        // Lägg till posten i postlistan
                        postList.Add(post);
                        break;
                    case "2":
                        //Kolla om listan är tom, skriv att den är tom annars loppa genom och skriv ut inläggen
                        if(postList.Count == 0)
                        {
                            Console.WriteLine("\n\rBefintliga inlägg: Finns inga inlägg\n\r");
                        }
                        else
                        {
                            Console.WriteLine("\n\rBefintliga inlägg:\n\r");
                            foreach (string[] postObject in postList)
                            {
                                PrintPost(postObject);
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Sök inlägg");
                        // Sökordet
                        string keyWord = Console.ReadLine();
                        Console.WriteLine("\n\rSökresultat:\n\r");
                        // Loopa genom alla inlägg och jämför med sökordet
                        foreach (string[] postObject in postList)
                        {
                            // Konvertera text till småbokstäver för att kunna söka
                            keyWord = keyWord.ToLower();
                            if (postObject[0].ToLower().Contains(keyWord) || postObject[1].ToLower().Contains(keyWord) || postObject[2].ToLower().Contains(keyWord)) 
                            {
                                PrintPost(postObject);
                            }
                        }
                        break;
                    case "4":
                        // Töm inläggslistan
                        postList.Clear();
                        Console.WriteLine("\n\rInläggslistan tömd\n\r");
                        break;
                    case "5":
                        showMenu = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Write a menu list for the postlist
        /// </summary>
        private static void ShowMenu()
        {
            Console.WriteLine("\nMenyn:");
            Console.WriteLine("1) Skriv nytt inlägg");
            Console.WriteLine("2) Visa inlägg");
            Console.WriteLine("3) Sök inlägg");
            Console.WriteLine("4) ta bort alla inlägg");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nVälj ett alternativ: ");
        }


        /// <summary>
        /// Print the post to the console
        /// </summary>
        /// <param name="post">string array</param>
        private static void PrintPost(string[] post)
        {
            Console.WriteLine("Inlägg:\n\r{0}\n\r{1}\n\r{2}\n\r", post[0], post[1], post[2]);
        }
    }
}
       