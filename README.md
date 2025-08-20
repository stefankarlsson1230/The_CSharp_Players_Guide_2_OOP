# The C# Player's Guide - Part 2: Object Oriented Programming


## Chapter 15: Object-Oriented Concepts
- No assignments for this chapter.

Chapter 16: Output Parameters
    1. TryDivide – Safely divide with output result and success flag.
    2. Parse Height – Convert string to float via output.
    3. GetDate – Return day, month, year via out parameters.
    4. Swap – Swap two integers using out.
    5. GetStats – Output sum and average of 3 numbers.

Chapter 17: Tuples
    1. Return Stats – Return min, max, average from method.
    2. Split Name – Return (first, last) from full name.
    3. Rectangle Info – Return area and perimeter as tuple.
    4. Get System Info – Return OS, processor, and memory.
    5. Coordinate Finder – Return (x, y) from direction input.

Chapter 18: Classes
    1. Create Player – With name, level, and score.
    2. Create Book – Title, author, pages.
    3. Display Object Info – Print object data with method.
    4. Compare Two Books – Check which has more pages.
    5. Inventory List – Use class to hold multiple item objects.

Chapter 19: Fields
    1. Store Weapon Stats – Damage, range, cost.
    2. Create Multiple Objects – Create and compare players.
    3. Initialize via Constructor – Create object with data.
    4. Update Field – Change player’s level mid-game.
    5. Field Summary – Print summary of all fields.

Chapter 20: Properties
    1. Auto Property Player – Add Health, Mana, XP.
    2. Read-Only ID – Use get only for a unique ID.
    3. Validation – Set Age but block < 0.
    4. Property Method – Calculate IsAlive from Health.
    5. Display All Properties – Loop and print them.

Chapter 21: The Catacombs of the Class
    1. Create Point – With X and Y fields.
    2. Create Color – RGB class and ToHex() method.
    3. Create Card – Enum for suit, rank.
    4. Lockable Door – With Unlock() and password.
    5. Password Validator – Check password rules.

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

