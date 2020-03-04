using System;

namespace PA3
{

    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();

        }

        static void Menu()
        {
            int gilTotal = 50;
            //start of game
            Console.WriteLine("Hello!\n" +
                "Welcome to Game Night!!!");
            Console.WriteLine("Gil Total: " + gilTotal);
            //user selects which game they want to play
            Console.WriteLine("Play select which game you would like to play.");
            Console.WriteLine("1." + "For Card Shark\n" +
                "2." + "For Shut The Box\n" + "3." + "To exit program");
            string selectGame = SelectedGame();
            //evaluates if the user selection is valid
            while (selectGame != "4")
            {
                if (selectGame == "1")
                {
                    Console.WriteLine("You have selected Card Shark!");
                    CardShark(ref gilTotal);
                }
                else if (selectGame == "2")
                {
                    Console.WriteLine("You have selected Shut The Box!");
                    ShutTheBox(ref gilTotal);
                }
                else if (selectGame == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Plese make a valid selection");
                }
                selectGame = SelectedGame();
            }

            Console.WriteLine("Before we start! Here are the official rules\n" +
                "");
        }

        static string SelectedGame()
        {
            string gameChoice = Console.ReadLine();

            return gameChoice;
        }
        //card shark game rules
        static void CardSharkRules()
        {
            Console.Clear();
            Console.WriteLine("These are the following rules of the Card Shark:\n" +
                "1.Enter a amount you a willing to wager.\n" +
                "2.A Row of ten cards are used to play Card Shark.\n" +
                "3.Once the game has officially starts, you will be shown a random card form the deck.\n" +
                "4.Once you have been shown the card you must guess whether the next card is higher or lower card.\n" +
                "5.Aces are consider the lowest card.\n" +
                "6.Each time you guess correctly you will advance to the next card until you reach the 10th and final card.\n" +
                "7.If you make it through all ten card your Gil will triple.\n" +
                "8.If you make it through seven cars but not all ten your Gil will double.\n" +
                "9.If you make it through five cars your Gil will break even and you will neither win nor lose gils.\n" +
                "10.If you fail to before reaching five cards you will lose all you gils.\n" +
                "11.You will be giving three chance to answer incorrectly.If you guess wrong three times then you will lose the amount you bet.\n" +
                "You have to the options to wager:\n" +
                "Car(Which give you the change the win the amount the bet).\n" +
                "Jelly(Which give you the chance to win double the amount you bet).\n" +
                "Washer(Which give you the chance to win triple the amount you bet).");

        }


        //Evaluates User win total
        static void Wins(ref int gilTotal, ref int gilRisk, ref int wins)
        {
            if (wins == 10)
            {
                gilTotal = (gilTotal + gilRisk) * 3;
                Console.WriteLine("You Won!!!");
                Console.WriteLine("Giltotal: " + gilTotal);
                UserOption(ref gilTotal);
            }
            else if (wins < 10 && wins > 7)
            {
                gilTotal = (gilTotal + gilRisk) * 2;
                Console.WriteLine("Giltotal: " + gilTotal);
                Console.WriteLine("Gil has Double ");
                UserOption(ref gilTotal);
            }

            else if (wins <= 7 && wins >= 5)
            {
                gilTotal = gilTotal + gilRisk;
                Console.WriteLine("Break Even");
                Console.WriteLine("Giltotal: " + gilTotal);

                UserOption(ref gilTotal);
            }
            else
            {
                gilTotal = gilTotal - gilRisk;
                Console.WriteLine("Sorry Less than 5");
                Console.WriteLine("Giltotal: " + gilTotal);
                UserOption(ref gilTotal);
            }

        }

        static void CardShark(ref int gilTotal)
        {

            int gilRisk = 0;

            int wins = 0;

            //const int JELLY = 2;
            //const int WASHER = 1;
            //const int CAR = 3;


            string[] cardPulled = new string[10];

            string[] secCardPulled = new string[10];


            Console.WriteLine("Before we start! Here are the official rules\n");
            CardSharkRules();
            Console.WriteLine("Gil Total: " + gilTotal);
            //Collects the user's risk ammount
            Console.Write("Enter amount you are willing to risk: ");
            gilRisk = int.Parse(Console.ReadLine());
            if (gilTotal < gilRisk)
            {
                Console.WriteLine("Wage is more the gil amount");
                Console.WriteLine("Press enter to input the appropriate gil ammount to wage");
                Console.Write("Enter amount you are willing to risk: ");
                gilRisk = int.Parse(Console.ReadLine());
                //Displays gil total after risk is entered
                gilTotal = gilTotal - gilRisk;
            }
            else
            {

                gilTotal = gilTotal - gilRisk;
            }
            int wrongGuess = 0;

            Console.WriteLine("Your current gil total is " + gilTotal);
            Console.WriteLine("Let's Begin!");



            string[] deck = Deck();



            while (wins <= 10 || wrongGuess == 1)
            {

                for (int i = 0; i < 10; i++)
                {



                    Random r = new Random();

                    int firstRando = r.Next(1, 52);
                    int Rando = r.Next(1, 52);
                    cardPulled[i] = deck[Rando];
                    secCardPulled[i] = deck[firstRando];

                    Console.WriteLine("Guess whether the next card is Higher or Lower.");
                    Console.WriteLine("Enter Higher or Lower as your choice");
                    string userGuess = Console.ReadLine();


                    int firstCard = 0;
                    int secCard = 0;
                    switch (cardPulled[i][0])
                    {
                        case 'A':
                            firstCard = 1;
                            break;
                        case '2':
                            firstCard = 2;
                            break;
                        case '3':
                            firstCard = 3;
                            break;
                        case '4':
                            firstCard = 4;
                            break;
                        case '5':
                            firstCard = 5;
                            break;
                        case '6':
                            firstCard = 6;
                            break;
                        case '7':
                            firstCard = 7;
                            break;
                        case '8':
                            firstCard = 8;
                            break;
                        case '9':
                            firstCard = 9;
                            break;
                        case '1':
                            firstCard = 10;
                            break;
                        case 'J':
                            firstCard = 11;
                            break;
                        case 'Q':
                            firstCard = 12;
                            break;
                        case 'K':
                            firstCard = 13;
                            break;
                    }


                    switch (secCardPulled[i][0])
                    {
                        case 'A':
                            secCard = 1;
                            break;
                        case '2':
                            secCard = 2;
                            break;
                        case '3':
                            secCard = 3;
                            break;
                        case '4':
                            secCard = 4;
                            break;
                        case '5':
                            secCard = 5;
                            break;
                        case '6':
                            secCard = 6;
                            break;
                        case '7':
                            secCard = 7;
                            break;
                        case '8':
                            secCard = 8;
                            break;
                        case '9':
                            secCard = 9;
                            break;
                        case '1':
                            secCard = 10;
                            break;
                        case 'J':
                            secCard = 11;
                            break;
                        case 'Q':
                            secCard = 12;
                            break;
                        case 'K':
                            secCard = 13;
                            break;

                    }


                    if (userGuess.ToLower() == "higher" && firstCard < secCard)
                    {
                        wins++;
                        Console.WriteLine("You are Correct");
                        Console.WriteLine(firstCard);
                        Console.WriteLine(secCard);
                        Console.WriteLine("win:" + wins);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();

                    }
                    else if (userGuess.ToLower() == "lower" && firstCard > secCard)
                    {
                        wins++;
                        Console.WriteLine("You are Correct");
                        Console.WriteLine(firstCard);
                        Console.WriteLine(secCard);
                        Console.WriteLine("Wins:" + wins);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();

                    }
                    else if (firstCard == secCard)
                    {
                        Console.WriteLine("Equal Value");
                        Console.WriteLine("Press enter to pull a new card");
                        Console.ReadLine();
                    }

                    else if (wrongGuess == 1)
                    {

                        wrongGuess++;
                        Console.WriteLine(firstCard);
                        Console.WriteLine(secCard);
                        Console.WriteLine("Win:" + wins);
                        Console.WriteLine("Would You like to play again");
                        Console.WriteLine("Wrong Guess! Sorry You Lose!");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Wins(ref gilTotal, ref gilRisk, ref wins);

                    }
                    else if (gilTotal < 0)
                    {
                        EndGame();
                    }
                    else
                    {
                        Wins(ref gilTotal, ref gilRisk, ref wins);

                    }

                }


            }


        }
        //ends game when you runs out of gil and returns to menu options
        static void EndGame()
        {
            Console.WriteLine("You have no gil left to wage");
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
            Menu();
        }
        static string UserOption(ref int gilTotal)
        {
            string choicePicked = "";
            Console.WriteLine(gilTotal);
            Console.WriteLine("1. Return to Menu\n" +
                "2. Play Card Shark\n" +
                "3. Play Shut The Box");

            choicePicked = Console.ReadLine();

            if (choicePicked == "1")
            {
                Console.WriteLine("Return to Menu");
                Menu();

            }
            else if (choicePicked == "2")
            {
                Console.WriteLine("Play Card Shark");
                CardShark(ref gilTotal);

            }

            else if (choicePicked == "3")
            {
                Console.WriteLine("Play Shut The Box");
                ShutTheBox(ref gilTotal);
            }
            else
            {
                Console.WriteLine("Select an value option");
            }
            return UserOption(ref gilTotal);
        }
        static string[] Deck()
        {
            string[] suits = { "Diamonds", "Hearts", "Spades", "Clubs" };
            string[] cards = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            string[] deck = new string[52];
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck[count] = cards[j] + " of " + suits[i];
                    count++;
                }
            }
            return deck;
        }
        //Shut the box game rules
        static void ShutTheBoxRules()
        {
            Console.Clear();
            Console.WriteLine("These are the following rules of the Shut The Box:\n" +
                "1.Enter a amount you a willing to wager.\n" +
                "2.Shut the Box is a game played with two dice and 12 /l/  ≥ tiles numbered 1-12\n" +
                "3.The object of the game is to turn over all of the 12 tiles. To begin the game, all 12 tiles are turned up\n" +
                "4.At each turn, the player rolls the two dice\n" +
                "5.You have the option of turning over the tile representing the sum of the dice, or turning over one or both of the tiles corresponding to the individual dice values.\n" +
                "If you cannot do neither you lose and then the game will be over.");
        }

        //shut the box game
        static void ShutTheBox(ref int gilTotal)
        {


            {
                Console.WriteLine("Giltotal: " + gilTotal);
                Console.WriteLine("Enter the Gil amount you would like to wage ");
                int gilRisk = int.Parse(Console.ReadLine());
                if (gilRisk <= gilTotal)
                {
                    gilTotal = gilTotal - gilRisk;
                    Console.WriteLine("Current Gil:  " + gilTotal);
                    string[] tiles = TilesValues();
                    bool guessCorrect = true;

                    int totalTiles = 12;


                    Random rdm = new Random();
                    int firstDice = rdm.Next(1, 6);
                    int secondDice = rdm.Next(1, 6);
                    int bothDice = firstDice + secondDice;
                    while (guessCorrect && totalTiles <= 12)
                    {
                        Console.WriteLine(firstDice);
                        Console.WriteLine(secondDice);
                        Console.WriteLine("Choose the corresponding number (1/2/3/4)");
                        Console.WriteLine("(1) to flip the Tile corresponding to the number of Dice 1. ");
                        Console.WriteLine("(2) to flip the Tile corresponding to the number of Dice 2. ");
                        Console.WriteLine("(3) to flip the Tile corresponding to the sum of the number of both dices. ");
                        string userSelection = Console.ReadLine();
                        while (userSelection != "4")
                        {
                            if (userSelection == "1")
                            {
                                Console.WriteLine("(1)Dice 1: " + firstDice);
                                totalTiles--;
                                TilesTotal(ref gilTotal, ref gilRisk, ref totalTiles);
                            }
                            else if (userSelection == "2")
                            {
                                Console.WriteLine("(2)Dice 2: " + secondDice);
                                totalTiles--;
                                TilesTotal(ref gilTotal, ref gilRisk, ref totalTiles);
                            }
                            else if (userSelection == "3")
                            {
                                Console.WriteLine("(3)The Sum of Both Dices: " + bothDice);
                                totalTiles--;
                                TilesTotal(ref gilTotal, ref gilRisk, ref totalTiles);
                            }
                            else
                            {
                                Console.WriteLine("please make a valid selection");
                            }


                        }
                    }
                    Console.WriteLine("Game over");
                    Menu();
                }
                static void TilesTotal(ref int gilTotal, ref int gilRisk, ref int totalTiles)
                {
                    if (totalTiles <= 2)
                    {
                        gilRisk *= 2;
                        gilTotal += gilRisk;

                    }
                    else if (totalTiles >= 3 && totalTiles <= 6)
                    {
                        gilTotal += gilRisk;
                    }

                    else
                    {
                        Console.WriteLine("You do not have enough Gils");
                    }

                }

                static int[] Dice()
                {
                    int[] pairOfDice = { 1, 2 };
                    int[] diceSide = { 1, 2, 3, 4, 5, 6 };

                    int[] dice = new int[12];
                    int count = 0;



                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            dice[count] = pairOfDice[i] + diceSide[j];
                        }
                    }

                    return Dice();

                }
                static string[] TilesValues()
                {
                    string[] valuesTiles = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
                    string[] tileTotal = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
                    string[] tiles = new string[12];
                    return tiles;
                }




            }
        }

    }
}
