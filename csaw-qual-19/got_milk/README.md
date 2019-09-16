# CSAW Qualifiers 2019

## Got Milk

### Challenge Text
> GlobalOffsetTable milk? 
> `nc pwn.chal.csaw.io 1004`

### Provided Files

* got_milk (UNIX Executable)
* libmylib.so (UNIX shared library file)

### Tooling

I used **Ghidra** for the decompilation. I also used **pwn-tools** for the scripting.

### Solving the Challenge

So, first thing I did was run nc `pwn.chal.csaw.io 1004` to determine the behavior of the program. Its output was:

```
Simulating loss...

No flag for you!
Hey you! GOT milk?
<USER INPUT> 
Your answer: 

No flag for you!
```

So the hint explicitly says that it the solution involves a GOT attack. So, onto analyzing the two binaries. From the analysis, I got the following information:

* `libmylib.so` basically contains the function `lose()` which is called from the main program. It also contains the function `win()` that prints the flag. So the purpose is to change the GOT pointer from `lose()` to `win()`.
* The main program only has a single user input using an `fgets` in a finitely sized buffer. Not too much opportunity for a buffer overflow...
* There are a lot of wierd stack adjustments being made throughout `main()`.

So to be able to run a GOT attack, I need to find a "write-what-where" vulnerability in order to arbitrarily write a value to an address. Trying to overflow the buffer did not work. However, I realized that the `printf` is vulnerable! It actually just prints the inputted string rather than escaping it! So using this, I can write to an arbitrary address! Confirming this, I entered the string `%d` and got the following output:

```
Your answer: 100
```

HAHA! Now time to exploit.  So there are three steps to the exploit:

1. Print the address of `lose()` so that the location `win()` can be found and then overwritten on `lose()`
2. Modify the stack to return back to the start of `main()` so that the address of `win()` can be written
3. Overwrite `lose()` with `win()` and get it to print the flag

However, upon further analyzing the code, I realized that I cannot actually do the above strategy because there is no way to alter the stack. After struggling a bit trying to look into a possible stack pointer stored on the stack, I realized that the GOT entry for `lose()` always ENDED in the same byte (it was the first 3 bytes that continually changed). Therefore, I was able to alter the location by the constant offset between `lose()` and `win()` using a single format string injection. For reference, my solution is included in this folder (`solve.py`)

### Solution
**flag{baby_boi_dodooo_doo_doo_dooo}**

### Comments

A pretty trivial pwning challenge. Unfortunately, it was the last one I could attempt due to limited time during the weekend that CSAW '19 quals happenned (I should have cleared more time in my schedule), but I did learn a lot!

### Challenge Keywords

`reversing`, `pwning`, `printf`, `GOT`

### Things I Learned

How to exploit `printf` to achieve arbitrary address writing ((SOURCE)[http://www.cis.syr.edu/~wedu/Teaching/cis643/LectureNotes_New/Format_String.pdf])
