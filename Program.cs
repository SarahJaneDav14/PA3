//main

int coins = 5;
int menu=Menu();
int points = 0;
while(menu != 7 && points != 15 && coins >=0 )
{
    Navigation(menu, ref coins, ref points);
    menu = Menu();
}

if (coins == 0)
{
    System.Console.WriteLine("You are out of coins. Please play a game to get more.");
    Menu();
}

if (points == 15)
{
    System.Console.WriteLine("Congrats! You won! You're now the best gambler!");
}

System.Console.WriteLine("Thank you! Hope you had fun playing! We loved having you!");

//end main


static int Menu()
{
    System.Console.WriteLine(@"
    =====================================
    || Select 1 to play 'Old Man's War'||
    ||                                 ||
    || Select 2 to fish at the lake    ||
    ||                                 ||
    || Select 3 to play Jeopardy       ||
    ||                                 ||
    || Select 4 to view coin count     ||
    ||                                 ||
    || Select 5 to view point count    ||
    ||                                 ||
    || Select 6 to see user manual     ||
    ||                                 ||
    || Select 7 to Exit the game       ||
    =====================================
    ");
    return int.Parse(Console.ReadLine());
}

static void Navigation(int menu, ref int coins, ref int points)
{
    switch(menu)
    {
        case 1:
            OldMansWar(ref coins);
            break;
        case 2:
            Fishing(ref coins, ref points);
            break;
        case 3:
            Jeopardy(ref coins);
            break;
        case 4:
            ViewCoinCount(ref coins);
            break;
         case 5:
            ViewPointCount(ref points);
            break;
        case 6:
            UserManual();
            break;
        default:
            return;
            break;
    }
}

static void OldMansWar(ref int coins)
{
    OldMansWarRules();
    //Pause();
    int bet = HowManyCoinsAvailableToBet(ref coins);
    string status = GetAndCompareCards();
    if (status == "wins")
    {
        coins = coins + bet;
    }else
    if (status == "lose")
    {
        coins = coins - bet;
    }
    else 
    {
        coins = coins;
    }
    System.Console.WriteLine($"You now have {coins} coins");
    Pause();

}

static int HowManyCoinsAvailableToBet(ref int coins)
{
    System.Console.WriteLine($"How many coins would you like to bet? You have {coins} coins available to bet!");
    int bet = int.Parse(Console.ReadLine());
    while (bet > coins)
    {
        InvalidInput();
        System.Console.WriteLine($"How many coins would you like to bet? You have {coins} coins available to bet!");
        bet = int.Parse(Console.ReadLine());
    }
    return bet;
}

static void OldMansWarRules()
{
    System.Console.WriteLine(@"
    ==============================================
    || First you will place your bet with coins ||
    ||                                          ||
    || Then you and the old man will be given a ||                           
    || card                                     ||
    ||                                          ||
    || The person with the higher ranking card  ||                          
    || will win                                 ||
    ||                                          ||
    || If the user wins then their bet will be  ||                          
    || doubled                                  ||
    ||                                          ||
    || If the old man wins the user loses the   ||                          
    || amount they betted                       ||      
    ==============================================
    ");
}

static string GetAndCompareCards()
{
    Random rnd1 = new Random();
    int num = rnd1.Next(12);

    Random rnd2 = new Random();
    int suite = rnd2.Next(4);

    Random rnd3 = new Random();
    int num2 = rnd3.Next(12);

    Random rnd4 = new Random();
    int suite2 = rnd4.Next(4);

    string card1 = GetCardValue(num, suite, "User");
    string card2 = GetCardValue(num2, suite2, "Old Man");
    string status = WinnerPicker(num, suite, num2, suite2);
    System.Console.WriteLine(card1);
    System.Console.WriteLine(card2);
    return status;
}

static string GetCardValue(int num, int suite, string who)
{
    string realSuit;
    switch(num)
    {
        case 0:
            realSuit = GetSuit(suite);
            return $"{who} card is a 2 of {realSuit}";
            break;
        case 1:
            realSuit = GetSuit(suite);
            return $"{who} card is a 3 of {realSuit}";
            break;
        case 2:
            realSuit = GetSuit(suite);
            return $"{who} card is a 4 of {realSuit}";
            break;
        case 3:
            realSuit = GetSuit(suite);
            return $"{who} card is a 5 of {realSuit}";
            break;
        case 4:
            realSuit = GetSuit(suite);
            return $"{who} card is a 6 of {realSuit}";
            break;
        case 5:
            realSuit = GetSuit(suite);
            return $"{who} card is a 7 of {realSuit}";
            break;       
        case 6:
            realSuit = GetSuit(suite);
            return $"{who} card is a 8 of {realSuit}";
            break; 
        case 7:
            realSuit = GetSuit(suite);
            return $"{who} card is a 9 of {realSuit}";
            break;
        case 8:
            realSuit = GetSuit(suite);
            return $"{who} card is a 10 of {realSuit}";
            break;
        case 9:
            realSuit = GetSuit(suite);
            return $"{who} card is a Jack of {realSuit}";
            break;
        case 10:
            realSuit = GetSuit(suite);
            return $"{who} card is a Queen of {realSuit}";
            break;
        case 11:
            realSuit = GetSuit(suite);
            return $"{who} card is a King of {realSuit}";
            break;
        case 12:
            realSuit = GetSuit(suite);
            return $"{who} card is a Ace of {realSuit}";
            break;
        default:
            InvalidInput();
            return "";
            break;
    }

}

static string GetSuit(int suite)
{
    switch(suite)
    {
        case 0:
            return "Hearts";
            break;
        case 1:
            return "Spades";
            break;
        case 2:
            return "Clubs";
            break;
        case 3:
            return "Diamonds";
            break;
        default:
            return "";
            break;
    }
}

static string GetTrumpSuit(int trumpSuite)
{
    switch(trumpSuite)
    {
        case 0:
            return "Hearts";
            break;
        case 1:
            return "Spades";
            break;
        case 2:
            return "Clubs";
            break;
        case 3:
            return "Diamonds";
            break;
        default:
            return "";
            break;
    }
}

static string WinnerPicker(int num, int suite, int num2, int suite2)
{
    string status = "";
    Random rnd = new Random();
    int trumpSuite = rnd.Next(4);
    string winningSuit = GetTrumpSuit(trumpSuite);
    System.Console.WriteLine($"The trump suit is {winningSuit}");
    if ((suite == trumpSuite && suite2 == trumpSuite)||(suite != trumpSuite && suite2 != trumpSuite))
    {
        if (num>num2)
        {
            System.Console.WriteLine("User Wins");
            status = "wins";
        } else 
        if(num2>num)
        {
            System.Console.WriteLine("Old Man Wins!");
            status = "lose";
        }else 
        if (num == num2)
        {
            System.Console.WriteLine("Tie. No one wins.");
            status = "ties";
        }

    }else 
    if (suite == trumpSuite)
    {
        System.Console.WriteLine("User wins");
        status = "wins";
    }else
    if (suite2 == trumpSuite)
    {
        System.Console.WriteLine("Old Man Wins");
        status = "lose";
    }
    else
    {
        System.Console.WriteLine("Something is wrong");
    }
    return status;

}

static void Fishing(ref int coins, ref int points)
{
    int chosenBait = BuyBaitMenu( ref coins);
    if (chosenBait == 4)
    {
        return;
    }
    string answer = BuyingBaitLogic(ref coins, chosenBait);
    string fish = FishPicker();
    if (answer != "You have too little money. Try again")
    {
        System.Console.WriteLine($" You've caught a {fish}, but hold on it might swim away.");
    }else 
    {
        System.Console.WriteLine("You have too little money. Try again");
        Pause();
        return;
    }
    string passOrFail = BaitToFish(chosenBait, fish, ref points);
    System.Console.WriteLine($"You now have {points} points! You now need {15-points} points to win.");
    Pause();
    return;
    
}

static string FishPicker()
{
    Random rnd = new Random();
    int fishing = rnd.Next(1,11);
    string fish = "";

    if( fishing >= 9)
    {
        fish= "bass";
    }else 
    if (fishing >= 6)
    {
        fish = "shark";
    }else
    if(fishing >= 1)
    {
        fish = "bass";
    }
    else
    {
        System.Console.WriteLine("something is wrong");
    }
    return fish;
}

static int BuyBaitMenu (ref int coins)
{
    System.Console.WriteLine($@"
    =================================================
    ||What kind kind of bait would you like to buy?||
    ||You have {coins} coins                       ||
    ||                                             ||
    ||Select 1 to buy Normal Bait (3 coins)        ||
    ||    Only for bass                            ||
    ||                                             ||
    ||Select 2 to buy Special Bait (5 coins)       ||
    ||    Only for sharks                          ||
    ||                                             ||
    ||Select 3 to buy Super Bait (7 coins)         ||
    ||    Only for whales                          ||
    ||                                             ||
    ||Select 4 to go back Main Menu                ||
    =================================================
    ");
    int bait = int.Parse(Console.ReadLine());
    while (bait <1 && bait >4)
    {
        InvalidInput();
        System.Console.WriteLine("Please select either 1, 2, or 3 to buy bait");
        bait = int.Parse(Console.ReadLine());
    }
    return bait;
}

static string BuyingBaitLogic(ref int coins, int chosenBait)
{
    string moneyAnswer = "";
    if (chosenBait == 1)
    {
        if (coins < 3)
        {
            moneyAnswer = "You have too little money. Try again";
        }
        else
        {
            coins -= 3;
        }
    }
    else if (chosenBait == 2)
    {
        if (coins < 5)
        {
            moneyAnswer = "You have too little money. Try again";
        }
        else
        {
            coins -= 5;
        }
    }
    else if (chosenBait == 3)
    {
        if (coins < 7)
        {
            moneyAnswer = "You have too little money. Try again";
        }
        else
        {
            coins -= 7;
        }
    } else if (chosenBait == 4)
    {
        Pause();
    }
    else 
    {
        InvalidInput();
    }
    return moneyAnswer;
}

static string BaitToFish(int chosenBait, string fish, ref int points)
{
    string passOrFail = "";
    if(chosenBait == 1)
    {
        if(fish == "bass")
        {
            passOrFail = "Pass";
            points += 4;
        } else
        {
            passOrFail = "Fail";
            System.Console.WriteLine("The fish has swam away. Please try again");
        }
    }

if(chosenBait == 2)
    {
        if(fish == "shark")
        {
            passOrFail = "Pass";
            points += 6;
        } else
        {
            passOrFail = "Fail";
            System.Console.WriteLine("The fish has swam away. Please try again");
        }
    }

if(chosenBait == 3)
    {
        if(fish == "whale")
        {
            passOrFail = "Pass";
            points += 10;
        } else
        {
            passOrFail = "Fail";
            System.Console.WriteLine("The fish has swam away. Please try again");
        }
    }

    return passOrFail;
}

static void ViewCoinCount(ref int coins)
{
    System.Console.WriteLine($"You have {coins} coins available to bet and buy.");
}

static void InvalidInput()
{
    System.Console.WriteLine("Invalid input. Please try again.");
}

static void Pause()
{
    System.Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

//all extras

static void ViewPointCount(ref int points)
{
    System.Console.WriteLine($"You currently have {points} points");
}

static void UserManual()
{
    System.Console.WriteLine(@"
    ======================================================
    || The object of this game is to win money so that  ||
    || you can buy bait to go fish and then win points. ||
    || There are two ways to win money. The first is by ||
    || playing Old Man's War. To play Old Man's War you ||
    || must bet coins then you and the old man will be  ||
    || given a card. The user withhighest card will win,||
    || but there is a twist. Before the cards are drawn ||
    || a trump suit is picked and the user with the     ||
    || trump suit will be the automatic winner of the   ||
    || game. If you win you will gain double the amount ||
    || of money you bet. If you lose you will lose the  ||
    || amount of money you bet. The second way to win   ||
    || money is my playing Jeopardy. For Jeopardy you   ||
    || will choose a category and the amount of coins   ||
    || you would like to play. The amount of coins      ||
    || corresponds to the difficulty of the questions.  ||
    || For the Fishing Game you be given the option to  ||
    || buy bait that will correspond to a specific fish ||
    || to catch. The fish that you will catch will be   ||
    || randomized and if the wrong bait is used then    ||
    || the fish will swim away. If you catch the right  ||
    || fish you will gain the corresponding points.     ||
    || Once you reach 15 point you will have won the    ||
    || game.                                            ||
    ======================================================
    ");
}

static void Jeopardy(ref int coins)
{
    DisplayJeopardyRules();
    string categoryChoice = DisplayJeopardyMenu();
    JeopardyNavigation(categoryChoice, ref coins);
}

static void DisplayJeopardyRules()
{
    System.Console.WriteLine(@"
    To collect more money you will have to play Jepardy but the categories will be about me or my interests.
    I don't like betting so this is an easy why to gain coins so that way you can just fish.");
    Pause();
}

static string DisplayJeopardyMenu()
{
    System.Console.WriteLine(@"
    =================================================================
    ||PERSONAL FACTS || ROMAN CULTURE || ETYMOLOGY || CROSS STITCH ||
    ||=============================================================||
    ||   1 coin      ||    1 coin     ||  1 coin   ||    1 coin    ||
    ||=============================================================||
    ||   2 coins     ||    2 coins    ||  2 coins  ||    2 coins   ||
    ||=============================================================||
    ||   3 coins     ||    3 coins    ||  3 coins  ||    3 coins   ||
    ||=============================================================||
    ||   4 coins     ||    4 coins    ||  4 coins  ||    4 coins   ||
    ||=============================================================||
    ||   5 coins     ||    5 coins    ||  5 coins  ||    5 coins   ||
    ||=============================================================||
 ");
 System.Console.WriteLine("Please select the category you'd like to play");
 return Console.ReadLine().ToUpper();
}

static void JeopardyNavigation(string categoryChoice, ref int coins)
{
    switch(categoryChoice)
    {
        case "PERSONAL FACTS":
            PersonalFacts(ref coins);
            break;
        case "ROMAN CULTURE":
            RomanCulture(ref coins);
            break;
        case "ETYMOLOGY":
            Etymology(ref coins);
            break;
        case "CROSS STITCH":
            CrossStitch(ref coins);
            break;
        default:
            return;
            break;
    }
}

static void PersonalFacts(ref int coins)
{
    System.Console.WriteLine(@"
    You've chosen Personal Facts
    Select which coin category you'd like to play.
    The amount of money will correspond to the difficulty of the question. 
    Select either 1, 2, 3, 4, or 5");
    int pfChoice = int.Parse(Console.ReadLine());
    DispayPersonalFactQuestion(pfChoice, ref coins);
}

static void DispayPersonalFactQuestion(int pfChoice, ref int coins)
{
    string answer;
    bool isRight = false; 
    if (pfChoice == 1)
    {
        System.Console.WriteLine("How many sisters do I have?");
        answer = Console.ReadLine();
        isRight = (answer == "2");
        if (isRight == true)
        {
            coins += 1;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (pfChoice == 2)
    {
        System.Console.WriteLine("How old am I?");  
        answer = Console.ReadLine(); 
        isRight = (answer == "20");
        if (isRight == true)
        {
            coins += 2;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (pfChoice == 3)
    {
        System.Console.WriteLine("What sorority am I in? Give the full name.");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "ALPHA DELTA PI");
        if (isRight == true)
        {
            coins += 3;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (pfChoice == 4)
    {
        System.Console.WriteLine("What's my favorite color?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "YELLOW");
        if (isRight == true)
        {
            coins += 4;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (pfChoice == 5)
    {
        System.Console.WriteLine("Name every single pet I've ever had in order. Be sure to add commas inbetween the names.");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "HARRIET, SIMON, GEORGE, LUCY, ELI, TABBY");
        if (isRight == true)
        {
            coins += 5;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else
    {
        InvalidInput();
    }
}

static void RomanCulture(ref int coins)
{
    System.Console.WriteLine(@"
    You've chosen Roman Culture
    Select which coin category you'd like to play.
    The amount of money will correspond to the difficulty of the question. 
    Select either 1, 2, 3, 4, or 5");
    int rcChoice = int.Parse(Console.ReadLine());
    DisplayRomanCultureQuestion(rcChoice, ref coins);
}

static void DisplayRomanCultureQuestion(int rcChoice, ref int coins)
{
    string answer;
    bool isRight = false; 
    if (rcChoice == 1)
    {
        System.Console.WriteLine("What is the necklace that young boys in Rome would wear called?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "BULLA");
        if (isRight == true)
        {
            coins += 1;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (rcChoice == 2)
    {
        System.Console.WriteLine("What is the cloak/scarf women in Rome would wear called?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "PALLA");
        if (isRight == true)
        {
            coins += 2;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (rcChoice == 3)
    {
        System.Console.WriteLine("What was a Roman dinning room called?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "TRICLINIUM");
        if (isRight == true)
        {
            coins += 3;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (rcChoice == 4)
    {
        System.Console.WriteLine("What was the Roman version of Valentines's Day called? Hint: It is Febuary 15th.");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "LUPERCALIA");
        if (isRight == true)
        {
            coins += 4;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (rcChoice == 5)
    {
        System.Console.WriteLine("What was the name of the the most annoying character in my Latin textbook, Ecce Romani?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "SEXTUS");
        if (isRight == true)
        {
            coins += 5;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else
    {
        InvalidInput();
    }
}

static void Etymology(ref int coins)
{
    System.Console.WriteLine(@"
    You've chosen Etymology
    Select which coin category you'd like to play.
    The amount of money will correspond to the difficulty of the question. 
    Select either 1, 2, 3, 4, or 5");
    int eChoice = int.Parse(Console.ReadLine());
    DisplayEtymologyQuestion(eChoice, ref coins);
}

static void DisplayEtymologyQuestion(int eChoice, ref int coins)
{
    string answer;
    bool isRight = false; 
    if (eChoice == 1)
    {
        System.Console.WriteLine("What language does the word piano come from?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "ITALIAN");
        if (isRight == true)
        {
            coins += 1;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (eChoice == 2)
    {
        System.Console.WriteLine("The word salary comes from the Latin word salarium. What common substance is this word related to?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "SALT");
        if (isRight == true)
        {
            coins += 2;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (eChoice == 3)
    {
        System.Console.WriteLine("The word robot first appeared in a play in 1920. Which language does it come from?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "CZECH");
        if (isRight == true)
        {
            coins += 3;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (eChoice == 4)
    {
        System.Console.WriteLine("The word quarantine comes from the Italian quaranta giorni, meaning how many days?");
        answer = Console.ReadLine();
        isRight = (answer == "40");
        if (isRight == true)
        {
            coins += 4;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (eChoice == 5)
    {
        System.Console.WriteLine("The word disaster has roots in both Greek and Latin, combining 'dis-' (bad) with a word referring to what?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "STARS");
        if (isRight == true)
        {
            coins += 5;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else
    {
        InvalidInput();
    }
}

static void CrossStitch(ref int coins)
{
    System.Console.WriteLine(@"
    You've chosen Cross Stitch
    Select which coin category you'd like to play.
    The amount of money will correspond to the difficulty of the question. 
    Select either 1, 2, 3, 4, or 5");
    int csChoice = int.Parse(Console.ReadLine());
    DisplayCrossStitchQuestion(csChoice, ref coins);
}

static void DisplayCrossStitchQuestion(int csChoice, ref int coins)
{
    string answer;
    bool isRight = false; 
    if (csChoice == 1)
    {
        System.Console.WriteLine("What shape does a basic cross stitch create?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "X");
        if (isRight == true)
        {
            coins += 1;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (csChoice == 2)
    {
        System.Console.WriteLine("Which type of fabric is most commonly used for cross stitch?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "AIDA CLOTH");
        if (isRight == true)
        {
            coins += 2;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (csChoice == 3)
    {
        System.Console.WriteLine("In cross stitch patterns, what does a symbol or color in a grid square usually represent?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "THREAD COLOR");
        if (isRight == true)
        {
            coins += 3;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (csChoice == 4)
    {
        System.Console.WriteLine("Which historical purpose did cross stitch samplers often serve?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "DEMONSTRATE SKILL");
        if (isRight == true)
        {
            coins += 4;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
    else if (csChoice == 5)
    {
        System.Console.WriteLine("If a pattern calls for “2 over 2” stitching on linen, what does that mean?");
        answer = Console.ReadLine().ToUpper();
        isRight = (answer == "TWO STRANDS");
        if (isRight == true)
        {
            coins += 5;
            System.Console.WriteLine($"Correct! You now have {coins} coins!");
        }
        else
        {
            coins = coins;
            System.Console.WriteLine("Wrong.");
        }
    }
}
