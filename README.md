# CS162N Term Project - Magic: The Gathering Card Builder & Collection Tracker #
A terminal app built to visually frame cards for Magic: The Gathering as entered by the user.

### Requirements ###
- Add cards, built with user input (one attribute at a time), to a collection.
- Display entire collection.
- Search existing collection.
- Remove existing cards.

### Out of Bounds ###
- No GUI
- Search functionality is explicit/exact currently, no fuzzy finding or loose matching currently.
- Each card built by user input, no API search for existing cards yet.
- Wrapping of card text/flavor text still in progress, cards can appear slightly misshapen during printout.
### Implementation Details ###
- Card class - represents a card object, created by user input *implements IBattle, ICreature, and IPlaneswalker interfaces*
  - Properties
      - Name (for future updates, could also add alias for special cards)
      - ManaCost (for future updates, could also calculate ManaValue using ManaCost given)
      - TypeLine (for future updates, could be broken into supertypes, types, and subtypes)
      - RarityLine (for future updates, could be broken into set symbol and rarity)
      - Text
      - FlavorText
      - Artist
      - MaxWidth - int value, sets the width for the card frame/printout that gets generated
      - Optional:
        - For Creatures:
          - Power
          - Toughness
        - For Planeswalkers:
          - Loyalty
        - For Battles
          - Defense
        - For Double-Faced Cards
          - CardBack object representing the transformed (flipped over) back of the card
  - Methods
    - GetName() - used during deck/collection ToString method
    - ToString() - overridden to output a terminal friendly ASCII output of the card's properties
    - MatchAttr(string cardAttr, string value) - returns true if a card has an attribute with a value that matches the args respectively, used during Deck.SearchCard() method
     
- CardBack class - object representing the back of a card object, also created with user input - *inherits from Card class*
  - Properties
    - Name (for future updates, could also add alias for special cards)
    - ColorIdentity
    - TypeLine (for future updates, could be broken into supertypes, types, and subtypes)
    - RarityLine (for future updates, could be broken into set symbol and rarity)
    - Text
    - FlavorText
    - Artist
    - For Creatures:
      - Power
      - Toughness
    - For Planeswalkers:
      - Loyalty
    - For Battles
      - Defense
    - For Double-Faced Cards:
      - CardBack object representing the transformed (flipped over) back of the card
       
- Deck class
  - Properties
    - Cards - list of card objects, mostly straightforward
  - Methods
    - BuildCard() - prompts the user for input to build a Card object, then adds to collection
    - BuildBack() - prompts the user for input to build a CardBack object, then adds to pending Card as a property
    - CheckSpecialCases() - uses an existing card object, prompts user for special 
      -   card cases to update certain properties of the card or cardBack
    - AddCard() - Adds an existing card object to the Deck object's Cards list
    - RemoveCard(Card card) - removes the provided card object from the collection
    - SearchCard() - prompts user for input to search for a card, then provides option to remove card
    - ToString() - overridden to output the names of each card in the List that contains the card objects

- Interfaces
  - IBattle
    - methods:
      - GetDefense()
      - SetDefense()
      - GetBack()
      - SetBack()
  - ICreature
    - methods:
      - GetPower()
      - SetPower()
      - GetToughness()
      - SetToughness()
  - IPlaneswalker
    - methods:
      - GetLoyalty()
      - SetLoyalty()