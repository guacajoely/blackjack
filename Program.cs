Console.WriteLine();
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine($"                     BLACKJACK                      ");
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine();

newHand();
static void newHand()
{
    List<Card> Cards = new List<Card>()
    {
        new Card("JOKER",0),
        new Card("ACE",11),
        new Card("TWO",2),
        new Card("THREE",3),
        new Card("FOUR",4),
        new Card("FIVE",5),
        new Card("SIX",6),
        new Card("SEVEN",7),
        new Card("EIGHT",8),
        new Card("NINE",9),
        new Card("TEN",10),
        new Card("JACK",10),
        new Card("QUEEN",10),
        new Card("KING",10)
    };
        List<Card> playerHand = new List<Card>()
    {
        Cards[new Random().Next(1, 13)],
        Cards[new Random().Next(1, 13)]
    };

        int playerScore = playerHand.Sum(x => x.Value);

        List<Card> dealerHand = new List<Card>()
    {
        Cards[new Random().Next(1, 13)],
        Cards[new Random().Next(1, 13)]
    };

    int dealerScore = dealerHand.Sum(x => x.Value);

    Console.WriteLine($"You've been dealt a {playerHand[0].Name} and a {playerHand[1].Name} totaling {playerScore}");
    Console.WriteLine($"The dealer is showing a {dealerHand[0].Name}");

    while (playerScore < 21)
    {
        Console.Write("Type 'H' to hit or 'S' to stay: ");
        string answer = Console.ReadLine().ToLower();

        if (answer == "h")
        {
            //generate new random card
            Card playersNewCard = Cards[new Random().Next(1, 13)];

            // add card to player's hand
            playerHand.Add(playersNewCard);

            //recalculate player's score
            playerScore = playerHand.Sum(x => x.Value);

            //inform user what card was dealt and their new current score
            Console.WriteLine($"You got dealt a {playersNewCard.Name} making your new total {playerScore}");
        }

        else if (answer == "s")
        {
            //inform user what the dealers hand is and remind them of their score
            Console.WriteLine($"The dealer is showing a {dealerHand[0].Name} and flips over a...{dealerHand[1].Name}");
            Console.WriteLine($"The dealer needs to beat your {playerScore}");

            while (dealerScore < playerScore)
            {
                //generate new random card
                Card dealersNewCard = Cards[new Random().Next(1, 13)];

                //add card to dealer's hand
                dealerHand.Add(dealersNewCard);

                //recalculate dealer's score
                dealerScore = dealerHand.Sum(x => x.Value);

                //inform user what card the dealer was dealt and their new current score is
                Console.WriteLine($"The dealer drew a {dealersNewCard.Name} making their new total {dealerScore}");

                if (dealerScore > 21)
                {
                    Console.WriteLine("THE DEALER BUSTED! YOU WIN!");
                    Replay();
                }
            }

            // LOSE CONDITION (DEALER WINS TIE)
            if (dealerScore >= playerScore)
            {
                Console.WriteLine("SORRY, YOU LOST.");
                Replay();
            }

            // WIN CONDITION
            else
            {
                Console.WriteLine("CONGRATULATIONS, YOU WON!");
                Replay();
            }
        }
    }

    //check if user busted
    if (playerScore > 21)
    {
        Console.WriteLine("SORRY, YOU BUSTED");
        Replay();
    }

    //check if user has 21
    else if (playerScore == 21)
    {
        Console.WriteLine("BLACKJACK! YOU WIN!");
        Replay();
    }
}
static void Replay()
{
    Console.WriteLine();
    Console.Write($"Play Again? (Y/N):");
    string answer = Console.ReadLine().ToLower();

    while (answer != "y" && answer != "n")
    {
        Console.Write($"Play Again? (Y/N):");
        answer = Console.ReadLine().ToLower();
    }

    if (answer == "y")
    {
        newHand();
    }
    else
    {
        Environment.Exit(0);
    }
};