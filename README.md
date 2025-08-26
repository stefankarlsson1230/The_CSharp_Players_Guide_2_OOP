# The C# Player's Guide - Part 2: Object Oriented Programming


## Chapter 15: Object-Oriented Concepts
- No assignments for this chapter.

## Chapter 16: Enumerations

### From The Book

- [x] Project 1 - Simul's Test
  - Simulate the locking mechanism of a chest.
  - Define an enumeration for the state of the chest.
  - Make a variable whose type is this new enumeration.
  - Write code to allow you to manipulate the chest with the lock, unlock, open, and close
commands, but ensure that you don’t transition between states that don’t support it.
  - Loop forever, asking for the next command.
  - The program below shows what using this might look like:
    ```
    The chest is locked. What do you want to do? unlock
    The chest is unlocked. What do you want to do? open
    The chest is open. What do you want to do? close
    The chest is unlocked. What do you want to do?
    ```
    ![The chests lock-states](images/lockStates.png)


## Chapter 17: Tuples

### From The Book
- [x] Project 1 - Simula's Soup
  - Define enumerations for the three variations on food: type (soup, stew, gumbo), main ingredient
(mushrooms, chicken, carrots, potatoes), and seasoning (spicy, salty, sweet).
  - Make a tuple variable to represent a soup composed of the three above enumeration types.
  - Let the user pick a type, main ingredient, and seasoning from the allowed choices and fill the tuple
with the results. Hint: You could give the user a menu to pick from or simply compare the user’s
text input against specific strings to determine which enumeration value represents their choice.
  - When done, display the contents of the soup tuple variable in a format like “Sweet Chicken Gumbo.”
Hint: You don’t need to convert the enumeration value back to a string. Simply displaying an
enumeration value with Write or WriteLine will display the name of the enumeration value.)

### From ChatGPT

- [x] Project 2 - Return Stats
  - Return min, max, average from method.
    
- [x] Project 3 - Split Name
  - Return (first, last) from full name.
    
- [x] Project 4 - Rectangle Info
  - Return area and perimeter as tuple.

- [x] Project 5 - Coordinate Finder
  - Return (x, y) from direction input.

  
## Chapter 18: Classes

### From The Book
- [x] Project 1 - Vin Fletcher’s Arrows
  - Each arrow has three parts: the arrowhead (steel, wood, or obsidian), the shaft (a length between 60 and
100 cm long), and the fletching (plastic, turkey feathers, or goose feathers).
  - His costs are as follows: 
    - For arrowheads, steel costs 10 gold, wood costs 3 gold, and obsidian costs 5 gold.
    - For fletching, plastic costs 10 gold, turkey feathers cost 5 gold, and goose feathers cost 3 gold. 
    - For the shaft, the price depends on the length: 0.05 gold per centimeter.
  - Objectives:
    - Define a new Arrow class with fields for arrowhead type, fletching type, and length. (Hint:
arrowhead types and fletching types might be good enumerations.)
    - Allow a user to pick the arrowhead, fletching type, and length and then create a new Arrow instance.
    - Add a GetCost method that returns its cost as a float based on the numbers above, and use this
to display the arrow’s cost.

### From ChatGPT
- [x] Project 2
  - Create Player – With name, level, and score.
  - Create Book – Title, author, pages.
  - Display Object Info – Print object data with method.
  - Compare Two Books – Check which has more pages.
  - Inventory List – Use class to hold multiple item objects.

  
## Chapter 19: Information Hiding

### From The Book
- [x] Project 1 - Vin’s Trouble
  - Modify your Arrow class to have private instead of public fields.
  - Add in getter methods for each of the fields that you have.


## Chapter 20: Properties

### From The Book
- [x] Project 1 - The Properties of Arrows
  - Modify your Arrow class to use properties instead of GetX and SetX methods.
  - Ensure the whole program can still run.

### From ChatGPT
- [x] Project 2
  - Auto Property Player – Add Health, Mana, XP.
  - Read-Only ID – Use get only for a unique ID.
  - Validation – Set Age but block < 0.
  - Property Method – Calculate IsAlive from Health.
  - Display All Properties – Loop and print them.


## Chapter 21: Static

### From The Book
- [x] Project 1 - Arrow Factories
  - Vin Fletcher sometimes makes custom-ordered arrows, but these are rare. Most of the time, he sells one
of the following standard arrows:
    - The Elite Arrow, made from a steel arrowhead, plastic fletching, and a 95 cm shaft.
    - The Beginner Arrow, made from a wood arrowhead, goose feathers, and a 75 cm shaft.
    - The Marksman Arrow, made from a steel arrowhead, goose feathers, and a 65 cm shaft.
  - You can make static methods to make these specific variations of arrows easy.
  - Objectives:
    - Modify your Arrow class one final time to include static methods of the form public static
Arrow CreateEliteArrow() { ... } for each of the three above arrow types.
    - Modify the program to allow users to choose one of these pre-defined types or a custom arrow. If
they select one of the predefined styles, produce an Arrow instance using one of the new static
methods. If they choose to make a custom arrow, use your earlier code to get their custom data
about the desired arrow.



Chapter 22: Null References
    1. Null Name Check – Warn if name is null.
    2. Default Description – Use null-coalescing.
    3. Safe Access – Avoid null when calling .ToString().
    4. Inventory with Null – Represent empty slots.
    5. Null-Safe Print – Print message only if not null.

Chapter 23: Object-Oriented Design
    1. Create 3 Classes – For a game (e.g., Player, Item, Enemy).
    2. UML Draft – Draw diagram before coding.
    3. Use Case Simulation – Simulate basic interaction.
    4. Constructor Design – Pass data between classes.
    5. Refactor Duplicate Code – Apply DRY principles.

Chapter 24: Catacombs Continued
    1. Point Methods – Add Distance() and Translate() to Point.
    2. Color Methods – Add RGB to grayscale converter.
    3. Card Game – Simulate one card draw.
    4. Door with Lock State – Add IsLocked logic.
    5. Password System – Store and check multiple passwords.

Chapter 25: Inheritance
    1. Shape Hierarchy – Base Shape, derived Circle and Rectangle.
    2. Animals – Animal base class with Speak() override.
    3. RPG NPCs – NPC base, Merchant and Guard subclasses.
    4. Constructor Chaining – Pass data to base class.
    5. ToString Override – Return description in child classes.

Chapter 26: Polymorphism
    1. Abstract Base – Use Attack() as abstract method.
    2. Virtual Spell – Override CastSpell() in children.
    3. Interface Weapon – Use IWeapon interface.
    4. Strategy Pattern – Pass in delegate for move strategy.
    5. Type Array – Store base class but call derived behaviors.

Chapter 27: Interfaces
    1. ILogger – Multiple classes implement Log() differently.
    2. ISaveable – Add Save() and Load() methods.
    3. IDrawable – Render shapes using shared interface.
    4. Inventory System – Use interface to add/remove items.
    5. Composite Interface – Implement multiple interfaces in one object.

Chapter 28: Structs
    1. Vector2 – Struct with X and Y, and Length() method.
    2. Point Immutable – Read-only struct.
    3. Struct Copy Behavior – Copy and show difference.
    4. Timer Struct – Store time intervals.
    5. Rectangle Struct – Add Width, Height, Area.

Chapter 29: Records
    1. Contact Record – With Name, Phone.
    2. Equality Test – Compare two records.
    3. With Expression – Clone record and change one field.
    4. Positional Record – Use compact syntax.
    5. Data Model – Store data in immutable records.

Chapter 30: Generics
    1. Pair<T1, T2> – Hold two values of any type.
    2. Generic Stack – Push and pop any type.
    3. Swap<T> – Swap two values.
    4. Constraints – Add where T : IComparable.
    5. Repository<T> – Simulate data repository.

Chapter 31: Fountain of Objects
    1. Grid Builder – Create grid of rooms.
    2. Movement System – Move through grid.
    3. Add Obstacles – Add pits, monsters, fountains.
    4. Goal Condition – Activate fountain and exit safely.
    5. Track State – Save location, HP, and status.

Chapter 32: Useful Types
    1. Dice Roller – Use Random class.
    2. Date Difference – Use DateTime to count days.
    3. Stopwatch – Time an operation with TimeSpan.
    4. GUID Generator – Generate a unique ID.
    5. List Inventory – Add/remove items from a List<string>.

