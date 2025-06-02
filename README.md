# CS162N Term Project - Magic: The Gathering Card Builder & Collection Tracker #
A terminal app built to visually frame cards for Magic: The Gathering as entered by the user.

### Requirements ###
- Add cards, one attribute at a time to a collection (deck)
- Display entire collection.
- Search existing collection.
- Remove existing cards.

### Out of Bounds ###
- No GUI
- Search functionality is explicit/exact currently, no fuzzy finding or loose matching currently.
- Each card built by user input, no API search for existing cards yet.
- Wrapping of card text/flavor text still in progress, cards can appear slightly misshapen during printout.
### Implementation Details ###
- Card class - represents a card object, created by user input
  - Properties
      - Name (for future updates, could also add alias for special cards)
      - ManaCost (for future updates, could also calculate ManaValue using ManaCost given)
      - TypeLine (for future updates, could be broken into supertypes, types, and subtypes)
      - RarityLine (for future updates, could be broken into set symbol and rarity)
      - Text
      - FlavorText
      - Artist
      - Optional:
        - For Creatures:
          - Power
          - Toughness
        - For Planeswalkers:
          - Loyalty
        - For Battles
          - Defense
  - Methods
    - GetName() - used during deck/collection ToString method
    - ToString() - overridden to output a terminal friendly ASCII output of the card's properties
    - MatchAttr(string cardAttr, string value) - returns true if a card has an attribute with a value that matches the args respectively, used during Deck.SearchCard() method
- Deck class
  - Properties
    - Cards - list of card objects, mostly straightforward
  - Methods
    - AddCard() - prompts the user for input to build a card object, then adds to collection
    - RemoveCard(Card card) - removes the provided card object from the collection
    - SearchCard() - prompts user for input to search for a card, then provides option to remove card
    - ToString() - overridden to output the names of each card in the List that contains the card objects