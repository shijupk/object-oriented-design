namespace BlackJackCardGame.Abstractions;

/// <summary>
/// These enums define the possible suits and ranks for the cards:
/// </summary>
public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}
/// <summary>
/// These enums define the possible suits and ranks for the cards:
/// </summary>
public enum Rank
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

/// <summary>
/// The interfaces define the contract for each component:
/// </summary>
public interface ICard
{
    Suit Suit { get; }
    Rank Rank { get; }
}

public interface IDeck
{
    ICard DealCard();
    void Shuffle();
}

public interface IHand
{
    void AddCard(ICard card);
    int CalculateTotal();
    bool IsBusted();
    bool HasBlackjack();
}

public interface IPlayer
{
    IHand Hand { get; }
    void PlayTurn(IGame game);
}

public interface IGame
{
    void Start();
    void PlayRound();
    void End();
}