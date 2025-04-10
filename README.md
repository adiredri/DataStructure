# Data Structures - Core Exercises in C#

This repository presents a collection of essential data structures and algorithmic implementations in **C#**, developed as part of an undergraduate computer science course.  
It includes structured examples of linear and hierarchical data structures, recursion, and file handling.

The goal is to practice both theoretical understanding and hands-on coding of foundational topics like linked lists, binary trees, queues, stacks, recursion, and file operations.

---

## Topics Covered

### [Stack and Queue](./StackandQueue)

Implements both **stack** (`Stack.cs`) and **queue** (`Queue.cs`) data structures using arrays, with full method sets: push, pop, enqueue, dequeue, peek, and checks for empty/full.  
Includes a demo runner: `StackandQueueProgram.cs`

---

### [Linked List (Nodes)](./LinkedList(Nodes))

Builds a singly linked list using a custom `Node.cs` class and `List.cs`.  
Supports basic operations like insert, delete, find, count, and iteration.  
Runner file: `ListsProgram.cs`

---

### [Binary Trees](./BinaryTree)

Implements a basic binary tree in C#, including node insertion, traversal (inorder, preorder, postorder), and search logic.  
Core files: `Tree.cs`, `BinaryTreeProgram.cs`

---

### [Recursions](./Recursions.cs)

Contains a variety of recursive algorithmic problems:
- Number reversal
- Sorted array check
- Count character occurrences in a string
- Sum balance detection in arrays
- Range matching based on conditions
- Deep array comparisons

---

### [Binary File Handling](./BinaryFile.cs)

A simulation of a **VOD rental system**, built using binary file I/O.

Features include:
- Adding a new rental record (with duplicate prevention)
- Searching episodes by renter or show name
- Deleting all episodes of a given show
- Generating reports by renter and payment summaries

---

### [Text File Processing](./TextFile.cs)

Reads a formatted text file that stores string lengths and content.  
Filters each line to retain only lowercase letters and creates a new file indicating their count and content.  
Good practice of stream reading/writing and string manipulation.

---

## Advanced Topics

---

## [EX1 - Hex Game with Union-Find](./EX1_HexGame)

This project implements the classic **Hex board game** (for two players) using an efficient Union-Find (Disjoint Set Union) structure.

### Highlights:
- Dynamic board size from 3×3 up to 8×8
- Two virtual nodes to detect win conditions
- Union-Find with both path compression and union by rank
- Text-based board display and simple input interface

The main idea is to track the connected components of each player and detect when a player connects the target edges (top-bottom or left-right) using the disjoint-set forest.

Implementation: [`HexGame.py`](./EX1_HexGame/HexGame.py)

---

## [EX2 - Email Filtering with Probabilistic Data Structures](./EX2_EmailFiltering)

This project simulates a spam-filtering system using various data structures and evaluates their performance in terms of accuracy and efficiency.

### Includes:
- `MailFilter1`- Simple Bloom Filter  
- `MailFilter2` - Counting Bloom Filter with element removal support  
- `MailFilter3` - Skip List + Bloom Filter hybrid for high-accuracy filtering

### Core Data Structures :
- [`bloom_filter.py`](./EX2_EmailFiltering/bloom_filter.py)
- [`counting_bloom_filter.py`](./EX2_EmailFiltering/counting_bloom_filter.py)
- [`skip_list.py`](./EX2_EmailFiltering/skip_list.py)
- [`utils.py`](./EX2_EmailFiltering/utils.py) – hashing, randomness, utilities

`main.py` runs the full benchmark and prints false positive rates, insert/remove accuracy, and performance differences between filters.

---

## Authors

- [Adir Edri](https://github.com/adiredri)  
- [Ofir Almog](https://github.com/Ofigu)
