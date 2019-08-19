# Flare-on CTF 2019

## 1 - Memecat Battlestation

### Challenge text:

Welcome to the Sixth Flare-On Challenge! 

This is a simple game. Reverse engineer it to figure out what "weapon codes" you need to enter to defeat each of the two enemies and the victory screen will reveal the flag. Enter the flag here on this site to score and move on to the next level.

* This challenge is written in .NET. If you don't already have a favorite .NET reverse engineering tool I recommend dnSpy

** If you already solved the full version of this game at our booth at BlackHat  or the subsequent release on twitter, congratulations, enter the flag from the victory screen now to bypass this level.

### Provided Files:

- MemeCatBattlestation.exe (Windows Executable)
- Message.txt

### Tooling:

As I have never done .NET reversing, I used their recommended application, dnSpy (as an aside, the application is beautiful). O also used Microsoft Excel to do some of the math.

### Solving the challenge:

First things first, I openned the executable within dnSpy. Right off the bat, I found that there are 2 "stages" that require their own battlecode (their classes are labelled `Stage1Form` and `Stage2Form` respectively).

Starting with Stage1Form, I found the click handler for the Fire Button (labelled `FireButton_Click`). The weapons code check is hardcoded in plain text and checks if the weapons code is "RAINBOW." Testing this out in the application, I find that it works. Ok, one down, one to go.

Stage2Form is similar, however, in this implementation of FireButton_Click, the entered code is passed to the function `isValidWeaponCode` which in turn, performs a series of bitwise XOR operations on the individual characters in the entered string with 'A' (0x41). The resulting string is then checked with this operation:

```c#
return array.SequenceEqual(new char[]
{
	'\u0003',
	' ',
	'&',
	'$',
	'-',
	'\u001e',
	'\u0002',
	' ',
	'/',
	'/',
	'.',
	'/'
});
```

A check with the C# docs says that SequenceEqual returns the following:

> `true` if the two source sequences are of equal length and their corresponding elements are equal according to the default equality comparer for their type; otherwise, `false`.

So the input string needs to be 12 characters long and be euqal to the above array after XORed with 0x41. I then converted the target array to  hexadecimal representations of the characters (to make them readable for the math):

'''
{ 0x0003, 0x0020, 0x0026, 0x0024, 0x002D, 0x001E, 0x0002, 0x0020, 0x002F, 0x002F, 0x002E, 0x002F }
'''

Since XOR is reflexive, XORing these values by 0x41 will yield the original value, so after running it through Excel I got :

```
{ 0x42, 0x61, 0x67, 0x65, 0x6C, 0x5F, 0x43, 0x61, 0x6E, 0x6E, 0x6F, 0x6E } = 'Bagel_Cannon'

```

### The solution:

Entering the above two codes led me to the flag:

**Kitteh_save_galixy@flare-on.com**

### Comments:

A very memey challenge! It was actually pretty easy and I enjoyed getting a taste of .NET programming. A good start to the Flare-on CTF

### Challenge Keywords:

`reversing` `.NET`
