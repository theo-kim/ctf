# CSAW Qualifiers 2019

## Beleaf

### Challenge Text
> tree sounds are best listened to by https://binary.ninja/demo or ghidra

### Provided Files

* beleaf (UNIX executable)

### Tooling

I used Ghidra for the decompilation and Binary Ninja in order to get a C-like array dump of the globals (to use in my Python script)

### Solving the Challenge

Solving the challenge starts with running the file, which asked for a flag and, upon entering a random string, prints "Incorrect." I determined that the program must take some plain text input, compare it to some encoded global value to determine if it matches or not. 

Upon openning the file in Ghidra and looking through the decompiled code at `main`. First I learn that the program fails if the input is less than 0x21 characters. Therefore, I determined that the flag must be 0x21 characters long. Next, I found that the program basically checks an array of integers and compares each character (casted as an int) to those integers. If true, it returns the index of that integer in the global. The next step is that the program compares the returned index to another globals array. If the two values do not match, the program fails.

Using Binja, I copied the two globals into a variable in python and created a script simulating the reverse of `beleaf`. Running it yielded the flag (that script is included in this folder, labelled `solve.py`).

### Solution
**flag{we_beleaf_in_your_re_future}**

### Comments

This was a pretty easy challenge, just a simple lookup challenge that required a script to reverse the algorithm and lookup. The code was ofuscated or anything, and was pretty easy to figure out.

### Challenge Keywords

`reversing`, `programming`

### Things I Learned

I learned how to use the `struct` module for Python to convert encoded byte strings to little-endian integers.
