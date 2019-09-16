# CSAW Qualifiers 2019

## Baby_Boi

### Challenge Text
> Welcome to pwn.
> ` nc pwn.chal.csaw.io 1005`

### Provided Files

* baby_boi (UNIX Executable)
* libc-2.27.so (UNIX shared library file)
* baby_boi.c (C Source code)

### Tooling

I used **Ghidra** for the decompilation. I also used **pwn-tools** for the scripting.

### Solving the Challenge

So, first thing I did was run nc `pwn.chal.csaw.io 1005` to determine the behavior of the program. Its output was:

```
Hello!
Here I am: 0x7f99494a8e80
```

The program then pauses for user input.

Obviously, the output is a memory location, and the input will require the utilization of that output and a buffer overflow vulnerability in order to gain access to a shell. Given that one of the provided files was `libc`, I assume that that I will have to jump into `libc` in order to pop a shell. Next, I looked at the source code (which was pretty simple). Some observations:

* The output is the address of `printf` (not in the GOT but its dynamically loaded memory location)
* The buffer overflow vulnerability is `gets` (overflowing a 32-bit buffer)
* The program explicitly does not set any buffers for the various standard streams using `setvbuff`

Next comes an anlaysis of the binary using Ghidra. However, I already predict that I am going to have to use a ROP attack into a shell pop in `libc` (probably the one in `system`). The binary analysis shows that there is only one local allocated (the 32-bit buffer) and so a ROP attack would be the only way to take advantage of the vulnerability to allow for arbitary code execution. To test this hypothesis, I create a simple python script using pwntools to insert a payload of "AAAAAAAA", which would crash the code with a segmentation fault. That worked (it generated a SEGFAULT), so the next step is to try to take advantage of the ROP. 

I tried to insert the address of `printf` which is returned by the process to see what happens. That resulted in a SEGFAULT, so I used GDB to confirm that everything was working right. Turns out, I totally forgot that my local machine is not running the same version of libc. So, I next just found a code segment which runs `execv("/bin/sh")` in libc using Ghidra. I then used the local libc copy to get the libc base (`libc_base = address_from_binary - printf_offset`) and then jumped to the desired offset in libc (`target = libc_base + 0x4f322`) on the remote server, which yielded a shell (see `solve.py` for the full solution). Using the shell, I ran `cat flag.txt` and got the flag.

### Solution
**flag{baby_boi_dodooo_doo_doo_dooo}**

### Comments

Another easy ROP pwning challenge utilizing libc.

### Challenge Keywords

`reversing`, `pwning`, `ROP`

### Things I Learned

I learned how to use Ghidra to find all the instances in which a specific string is used.
