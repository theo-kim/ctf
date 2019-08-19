# Flare-on CTF 2019

## 3 - Flarebear

### Challenge text:

We at Flare have created our own Tamagotchi pet, the flarebear. He is very fussy. Keep him alive and happy and he will give you the flag.

### Provided Files:

- flarebear.apk (Android Package)
- Message.txt

### Tooling:

To disassemble the Android package I used apktool. To run the package I used Android Virtual Device and ADB. I have never actually worked with Smali (assembly-ish version of Java) and Android reversing before, but I found the following resources useful:

- [Dalvik opcodes reference](http://pallergabor.uw.hu/androidblog/dalvik_opcodes.html)
- [Android API documentation](https://developer.android.com/reference/android)
- [Reversing Android apps with apktool](https://ibotpeaches.github.io/Apktool/documentation/)

### Solving the challenge:

First, I ran the application in the AVD and played around with it. Basically, the flow of the program is:

1. Open the app for the first time
2. Create a new Flare Bear
3. Name the Flare Bear
4. Take care of the Flare Bear (either feed it, play with it, or clean it up). If you try to clean it up when there is no poop (indicated by poop pictures placed randomly over the Flare Bear sprite), a toast appears to inform you that there is no poop. The Flare Bear will also change its sprite to crying or smiling depending on its current mood.

Based upon the challenge instructions, I think there must be some sort of sequence of actions (play, feed, clean) that will lead to the flag. Playing around with the app for a while did not yield the flag, so I must need to look in the source code to determine that target set of actions. 

I then used apktool to disassemble the Android Package file into its component source code and resources (`$ apktool d -o flarebear-source flarebear.apk`). Again, I did not have any experience reversing Android applications, so it took a while to orient myself within the file directories and also to learn to read smali (which apparently is the middle ground between Dalvik and Java, more readable than the Dalvik byte codes but still assembly-ish). Surprisingly, it is not that hard! 

After some searching, I realized that there are no real actions available in the main menu page, credit page, or new Falre Bear page that will yield the flag, and everything is located in the `FlareBearActivity`. I went line-by-line from the `onCreate()` method to determine how the application worked and what conditions would yield the flag (or if any patches could be made to the file to make my job easier). I learned the following:

- The FlareBear has three main states: **sad**, **happy**, and **ecstatic**
    * The FlareBear starts **happy** and will stay happy until an action is performed, therefore, there is no passive effects on the FlareBear's state and everythign is entirely determined by the actions
- These states are determined by the values of the three Flare Bear properties: **mass**, **happiness**, and **cleanliness**
    * The FlareBear is **happy** when the ratio of feeding to playing that have been performed on the FlareBear is greater than or equal to 2.0 andx less than or equal 2.5 (i.e. playing with the FlareBear twice and feeding once)
    * The FlareBear is **ecstatic** when the FlareBear is both **happy** and its state is `{ mass = 72, happiness = 30, and cleanliness = 0}`
    * Otherwise, the FlareBear is **sad**
- The three interactions (**play**, **feed**, and **cleanup**) each have different effects on these three properties:
    * **play** : decreases the **mass** by **2**, increases **happiness** by **4**, and decreases **cleanliness** by **1**
    * **feed** : increases the **mass** by **10**, increases **happiness** by **2**, and decreases **cleanliness** by **1**
    * **clean** : does not affect the **mass**, decreases **happiness** by **1**, and increases **cleanliness** by **6**
- The FlareBear can also poop. Feeding the FlareBear will increment the **poo** property by 0.34 and cleaning the FlareBear will remove 1.0 from the **poo** property but only if **poo** is greater than 1.0. The poo sprite will only appear on the screen if it is a whole number (i.e. 1.34 poo will appear as a single poo and 2.1 poo will appear as 2 poo).

I also found a function called `danceWithFlag()` which does a complex cryptological function that I assume generates the flag. To invoke this function, the FlareBear needs to be ecstatic.

Testing these findings out, I do verify the happiness state, however, I cannot easily invoke the ecstatic state as the math to achieve the correct combination sequences of actions is hard to determine off the top of my head. So I decide to create a quick python program to generate the correct sequence (`solve.py`) to achieve the goal state. I utilize a graph based, heuristic search to test how the individual actions affect the game state. Running the program yielded the following sequence:

```
Solution found: ['feed', 'feed', 'feed', 'feed', 'feed', 'feed', 'feed', 'clean', 'play', 'play', 'feed', 'play', 'play', 'clean']
Final state: [72, 30, 0]
Final mood: ecstatic
```

Performing that challenge made the bear start dancing with the flag!

### Solution:

**th4t_was_be4rly_a_chall3nge@flare-on.com**

### Comments:

This was a really fun challenge, especially as I have never done Android reversing, which turned out to be very fun and a good practice for my Android dev skills too. The app was very cute and well developed. The source was well enough obfuscated that it made finding the answer difficult, but not too crazy.

### Challenge Keywords:

`android`, `reversing`, `programming`