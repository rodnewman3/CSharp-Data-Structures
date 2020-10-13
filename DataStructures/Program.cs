using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // create fixed size array of length 20
            var students = new string[20];
            // setting first position in the array to "some string"
            students[0] = "John Smith";
            
            // looping through the array from position 0 to 20:
            for (int pos = 0; pos < students.Length; pos++) {
                students[pos] = "";
            }

            // why use fixed arrays?
            // 1) the content size is already predetermined (won't grow or shrink)
            // 2) items in the array need to be in order (order matters)
            // 3) more efficient than other collections

            // characteristics of fixed arrays:
            // 1) items are in order based off the position you add it to (pos 0 being the first item)
            // 2) does not grow/shrink as items are added
            // 3) positions in the array are null until you add something to them

            // why should you NOT use fixed arrays?
            // 1) items may grow or shrink in the array (you will have copy those manually)
            // 2) order of the items doesn't matter (if it doesn't matter, arrays are not needed)
            // 3) need to delete items in the middle of the array

            // searching an array
            foreach (var student in students) {
                if (student == "John Smith") {
                    // found the student we want
                    break;
                }
            }

            // arrays aren't great for what we want to do, lets try a set
            var studentSet = new HashSet<string>();

            studentSet.Add("John Smith");
            studentSet.Add("Jane Doe");
            studentSet.Add("Sam Spa");

            // why use a set?
            // 1) you don't care about ordering (use a list or fixed array for ordering)
            // 2) you know the names of the students ahead of time
            // (or have some way to look them up that doesn't depend on ordering)
            // 3) Collection needs to shrink or expand as items are added
            // 4) Every item needs to be unique (sets only hold unique items)

            // searching for a student in the set
            bool foundStudent = studentSet.Contains("Jane Doe");
            // student already exists in the set, so will not be added again
            studentSet.Add("Jane Doe");


            // ArrayLists (basically a fixed array that grows and shrinks automatically for you
            var studentArrayList = new List<string>();

            // why use a dynamic list?
            // 1) you care about ordering, but the items in the collection may grow or shrink
            // 2) you need to keep track of multiple items that may not be unique

            // why should you NOT use a dynamic list?
            // 1) if you need to find an element by a known value (like a student or employee id,
            // you would have to loop over every item and check to see if it matches the id)
            // 2) you have a known # of values (use a fixed array instead)
            // 3) your lookup value is numeric (

            // searching an array
            foreach (var student in studentArrayList)
            {
                if (student == "John Smith") {
                    // found the student we want
                    break;
                }
            }
            // this is equivalent to the foreach above:
            studentArrayList.Contains("John Smith");

            // adding non-unique values to the list is allowed
            studentArrayList.Add("John Smith");

            // if you want to add only unique values, you have to check if exists already
            if (!studentArrayList.Contains("John Smith")) {
                studentArrayList.Add("John Smith");
            }


            var studentLinkedList = new LinkedList<string>();
            studentLinkedList.AddLast("John");
            studentLinkedList.AddLast("Jane");

            // Comparing linked list to a regular list:
            //List(regular list):
            //[0], [1], [2], [4]
            // you can grab every element by the position/index (e.g. 0, 1, 2, 3)

            // LinkedList (another type of dynamic array, but you can only access items from the start/end of the list and then
            // getting the next item in the list from the previous
            // LinkedList:
            // ["john"]<->["jake"]<->["jane"]<->["joe"]->
            // delete is called on jane: 
            // the linked list point the next element to joe instead of jane and then jane will be deleted behind the scenes
            // ["john"]<->["jake"]<-->["joe"]->
            // Deleting an element does not require copying over to a new array behind the scenes.
            // instead, it will take the pointer from the previous element and attach it to the element after the one you want to remove

            // adding to a linked list:
            // lets add in someone named chris between john and jake:
            // ["john"]<->["jake"]<->["joe"]->
            // ["john"]<->["chris"]<->["jake"]<-->["joe"]->
            // Items cannot easily be accessed by their position/index
            // instead, you start at the first or last element and that element keeps a reference that points to the next element in the collection

            // Why use a linked list?
            // 1) you need to remove elements not at the end of the list
            
            // why should you NOT use a linked list?
            // 1) you need to find things by their index/position (linked list has to start from position 0 and loop until it finds the item.
            // it has to do this because linked list do not keep indexes/positions of items


            // Dictionaries (like a set, but stores a key to look up the value and not just the value)
            // dictionaries store items based on a unique value (some sort of id)
            // the value doesn't have to unique, but the key to look up the value does

            // why use a dictionary?
            // the id/key will be the student's id number
            var studentDictionary = new Dictionary<int, string>();
            studentDictionary.Add(134134, "John Smith");
            studentDictionary.Add(99999, "Jake Harrison");

            // what happens if we add a student with an existing key/id?
            // if you call add with an existing unique value, it will throw an exception saying it was already added
            try {
                studentDictionary.Add(99999, "Jane Doe");
            } catch (Exception e) {
                // can't add it, because the key 99999 already exists in the dictionary
            }

            // tryAdd will return false, because the key already exist in the dictionary
            studentDictionary.TryAdd(99999, "Jane Doe");
            // you can update the value for the key/id like this though, setting the student name to "jane doe"
            studentDictionary[99999] = "Jane Doe";

            // why use a dictionary?
            // 1) you have a set of data that can be looked up by some unique value for each item (e.g. student id, ssn, employee number)
            // 2) uniqueness of items matters (don't want duplicates)
            // 3) the items are not in a particular order


            // why would you not want to use dictionary?
            // 1) your items don't have a unique way to look them up
            // 2) ordering matters (dictionaries don't promise items are in a particular order)
            // 3) There do exist dictionaries that keep track of ordering (usually called an ordered dictionary)
            // 4) A sorted dictionary in C# is called a SortedDictionary

            var sortedDictionary = new SortedDictionary<int, string>();


            // Stack and queues
            // Queue:
            // What is a queue?
            // Answer: A queue is just a list where the first item in the list is the first item out of the list

            var checkoutLine = new Queue<string>();
            checkoutLine.Enqueue("John");
            checkoutLine.Enqueue("Jane");
            checkoutLine.Enqueue("Sam");

            checkoutLine.Dequeue();

            // why use a queue?
            // 1) first item in the queue will be the first item out of the queue (a line). This is also
            // referred to as first-in-first-out (FIFO)
            
            // why would not use a queue?
            // 1) you need to remove items not at the front of the queue sometimes

            // there's also priority queues. they do not follow first in first out. instead they queue items based off
            // of priority defined by the developer (e.g. prioritizing video streaming packets in a router over web browsing)
            // this allows items that just entered the queue to jump to the front of the line if they're important enough


            // Stacks:
            // stacks work like a stack of dishes. When you add dish to the top of the stack, the newly added dish will also
            // be the next item removed from the stack. This is also called last-in-first-out ordering (LIFO)

            // why use stacks and queues over a plain list?
            // 1) you want to create an undo/redo list of commands (add the last command to the queue, then also to the stack)


            var playingCards = new Stack<string>();
            playingCards.Push("Jack");
            playingCards.Push("Ace");
            playingCards.Push("King");

            // will remove king from the stack of cards
            playingCards.Pop();

            // finds the next card that will be removed from the playing card stack
            var nextCard = playingCards.Peek();
        }
    }
}
