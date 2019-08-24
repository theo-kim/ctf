# Flare-on CTF 2019

## 5 - demo

### Challenge text:

Someone on the Flare team tried to impress us with their demoscene skills. It seems blank. See if you can figure it out or maybe we will have to fire them. No pressure.

### Provided Files:

- 4k.exe (Windows Executable)
- Message.txt

### Tooling:

Ghidra for the original (failed) decompilation. Binja proved invaluable as I was able to disassemble the binary dump from the unpacked exe. I also used x32dbg, a debugger for Windows x86 binaries, which includes Scyllia, a memory dumper. I also used WhatIsHang, a simple program that shows where a program hangs (so I could find the correct position in the call stack) and ApiMonitor to get the names of the DLL's being used by the binary. I also leveraged the following resources:  

- [Windows Executable File Format Reference](https://en.wikibooks.org/wiki/X86_Disassembly/Windows_Executable_Files)
- [Windows PE Format Reference from Microsoft](https://docs.microsoft.com/en-us/windows/win32/debug/pe-format#the-edata-section-image-only)
- [Windows API Reference](https://docs.microsoft.com/en-us/windows/win32/api/)
- [Dynamic Linking in Linux and Windows, Part 2 (Reji Thomas and Bhasker Reddy)](https://www.symantec.com/connect/articles/dynamic-linking-linux-and-windows-part-two)
- Twitter (I do admit to trying to look up the answers...)

### Solving the challenge:

So, first this is first, I openned the executable and all that appears is a window with a rotating 3D logo. The cursor is a spinner and the window title indicates that the program is Not Responding. Wonderful. So the hint indicates that there is something wrong with the program. 

So, next I openned the program in Ghidra and noticed that there is only a single function (`entry`). Ghidra is also complaining about some bad instructions. Navigating to them, there is a jump pointing to some non-existant code. (address `0x400104` when the last address is `0x4000fa`). 

Other observations of some funky portions of the code:

- Addresses `0x400078` to `0x400089` don't seem to contain any opcodes, just random bytes (mostly 0x00). They are jumped over by `0x400076`, so it does not affect the execution, still suspiscious.

- Addresses `0x400040` to `0x400053` contain some random bytes too, that aren't referenced later on in the code.

- At address `0x40008b` a string is being loaded (`LODSD`) from an invalid memory location that extends past the end of the program (the instruction at `0x400065` loads `0x400144` into `ESI`).

- Why is the executable called **4k.exe**? The file size is 4KB, is that why? Does it have to do with the length of the executable?

I originally had two hypotheses for solving this challenge: 

1. Correct the address pointers: I think that the program jump and dat addresses are incorrect and are intended to alter locations within the code, which will change the instructions and cause the program to continue. 

2. I need to expand the size of the executable such that the instructions which reference to later on in the code actually reach that execution point. 

The first option may not work as the instruction space is marked read only, so I tried the second option (just adding a bunch of NOP bytes to the end of the file). Based on the fact that the executable is called 4K and the file is 3.78 KB right now, I added 0.22 KB of NOPs (`0x90`) to the end of the file. That did absolutely nothing... BUT! Curious as to whether I indeed patched the file, I openned the executable in a hexdump editor and found that I was being lied to by Ghidra (on second thought I should have realized that earlier), that Ghidra was not decompiling the entire binary, but only a portion. After some research into Windows PEs, I found that the DOS and PE headers for `4k.exe` were malformed, so I tried correcting it in a hex editor (Binary Ninja), but failed to get any results. 

It was at this moment (Day 2 of attempting this task) that I turned to Twitter for help. Most of the comments were vague except for one:

> Check out https://files.scene.org/view/parties/2009/breakpoint09/in4k/rgba_tbc_elevated_2016.zip … and crinkler (2.1) --@bWFAC1iyUI5C6ei

I looked into the links and started learning about binary packing, a method of minimizing and obfuscating binaries by making the binary decompress itself during runtime. Specifically, crinkler (which seems to be the packer that this challenge uses as I tried identifying the packer using the program **PeID** and came up blank) act more like a linker and stores imports in the PE header (hence why the PE header was malformed). After doing more digging in the debugger, I was able to dump the memory of the binary after it unpacked itself by placing breakpoints on the called DLLs (specifically d3d9.dll, which is used for DirectX, the 3D graphics library). Furthermore, I was able to get the names of the functions that the program was importing via the debugger as crinkler checks each export name in the loaded DLLs to generate the import table.

From there I used Binja to disassemble and decompile (by hand) the unpacked, dumped binary file into its component API calls and arguments. Essentially, the program generates a mesh, rottates it until the `ESC` key is pressed. This process took up most of Day 4 as I had to locate the struct definitions to correlate file offsets beig called in the assembly with struct methods [this was one DLL file](https://github.com/tpn/winddk-8.1/blob/master/Include/um/d3d9helper.h) and [this was the other](https://github.com/ofTheo/videoInput/blob/master/videoInputSrcAndDemos/libs/DShow/Include/d3dx9mesh.h).

These lines in particular caught my attention:

```x86
0000121c  e887000000         call    createMesh
...
00001244  a350004300         mov     dword [0x430050], eax
00001249  e85a000000         call    createMesh
...
00001251  a354004300         mov     dword [0x430054], eax
```

In this function, two meshes are created, however, when you run `4k.exe`, only 1 mesh (the Flare-On logo) is shown rotating. Where is the other mesh? Is it the flag?
So, rather than change the complex linear algebra that follows to show the second mesh instead of the first, I just patched the binary in the debugger and switched the pointers `0x430050` and `0x430054` so that Mesh 1 was associated with Mesh 2's pointer and vice versa. I ran the program and viola! The flag appeared as a rotating mesh!

### Solution:

**moar_pouetry@flare-on.com**

### Comments:

Challenges 1 - 4 took me at most four hours each. Challenge 5 took me four days. But I am glad that I finally solved it! I learned SOOOO much from this challenge, specifically all about dynamic linking in Windows, binary packing, and DirectX. I also was able to flex some of my reversing skills and lookup skills (for the API for DirectX based upon addresses and offsets). The simplicity of the final solution was almost poetic!

### Challenge Keywords:

`reversing` `directx` `binary packing`