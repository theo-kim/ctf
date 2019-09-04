# Flare-on CTF 2019

## 6 - bmphide

### Challenge text:

Tyler Dean hiked up Mt. Elbert (Colorado's tallest mountain) at 2am to capture this picture at the perfect time. Never skip leg day. We found this picture and executable on a thumb drive he left at the trail head. Can he be trusted?

### Provided Files:

- bmphide.exe (Windows Executable)
- image.bmp
- Message.txt

### Tooling:

dnSpy for reversing. Python for scripting (script is included in this folder for reference).

### Solving the challenge:

First I looked at the image, a really pretty image of the mountains. 

![image.bmp](https://github.com/theo-kim/ctf/flare-on-6/6%20-%20bmphide)

Then I openned the executable on the command line and got the following exception: 

```
Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.                           at BMPHIDE.Program.Main(String[] args)
```

The fact that the exception is so well formed and in an object oriented format, it must be written in .NET, so I openned it in dnSpy to disassemble the source. Inspecting the `Main()` function:

```c#
private static void Main(string[] args)
{
    Program.Init();
    Program.yy += 18;
    string filename = args[2];
    string fullPath = Path.GetFullPath(args[0]);
    string fullPath2 = Path.GetFullPath(args[1]);
    byte[] data = File.ReadAllBytes(fullPath2);
    Bitmap bitmap = new Bitmap(fullPath);
    byte[] data2 = Program.h(data);
    Program.i(bitmap, data2);
    bitmap.Save(filename);
}
```

I determined that the executable essentially encodes data in a text file (pointed to by `arg[1]`) and hides it in the image at the path specified in `arg[0]`, and names it the name string specified in `arg[2]`. I tried it out on a random picture with a random payload (`bmphide test.bmp testmessage.txt output.bmp`). The program also has 10 distinct functions which seem to contribute to the encoding process (labelled a -> j). So, my next step is to start understanding what each function does and piece them together to a greater understanding of the program as a whole (and try creating a decoding script to extract data from the image). To do this, I exported the source into a Visual Studio project so I could mess with the code and see its effects.

After analyzing the functions, I determined the following summary of the program:

- `Program.a(b, k)`: this function transforms the input using a key value and an XOR encoding
- `Program.b(b, k)`: this function compresses a byte
- `Program.c(b, k)`: **this function confuses me because it seems to just return 249 when the input is odd otherwise it return 255**
- `Program.d(b, k)`: this function compresses a byte 
- `Program.e(b, k)`: this function sets the ith bit of b to 0 if it is the same as k's ith bit, otherwise it sets it to 1
- `Program.f(idx)`: used by `Program.h()` to produce deterministic constants (for example: `Program.f(0)` always produces 117) 
- `Program.g(idx)`: produces a deterministic constant
- `Program.h()`: further prepares the payload to get it in the format to encode with the bitmap
- `Program.i()`: is actually performs the hiding of the data into the bitmap, see an explaination of how exactly it does this below:
- `Program.j()`: is used in `Program.i()` to produce deterministic constants (for example: `Program.j(103)` always produces 0 and `Program.j(231)` always produces 1)

So the program hides the data in the bitmap using the following algorithm:

```
Each bitmap pixel has three values: Red, Green, and Blue. The red pixel's last three bits contain the data byte's last three bits, the blue pixel's last three bits contain the next three bits (to the left, i.e. the next three most significant bits) and the blue pixel's last two buts contain the data byte's two most significant bits, so:

Red: RRRR R321
Green: GGGG G654
Blue: BBBB BB87

Data: 8765 4321
```

I realize now from my tinkering that the class `A`. At this point, I try encoding an image using my altered program (that I tinkered with in Visual Studio) and I find that the output of the tinkered code is different from the output of the original binary (what?!). After some digging, I realize that the calls to the `A` class from within `Program.Init()` seems to be actually modifying the Program class to create some unique behavior that my Visual Studio project cannot achieve as I commented out all the calls to the member functions of `A` because they were creating runtime errors. Apparently I need to debug and patch the original binary to do some more searching to replicate the changes that `A` makes to `Program`. 

Using dnSpy, I debugged the program, but I kept getting a Stack Overflow exception. I quickly identified the culprint, patched the binary to remove it, then confirmed that the output of the patched binary is the same as the output of the original binary... it was not! Apparently even removing a single function call (`Marshal.WriteIntPtr(intPtr, Marshal.GetFunctionPointerForDelegate<A.locateNativeCallingConvention>(A.handler));`) results in a different output. After reviewing the code in excrutiating detail, I found that the offending line essentially replace calls to the C# JIT (Just-In-Time Compiler, which after research discovered essentially optimizes the C# compiled byte code, and is enabled by default in the dnSpy debugger) with a resursive function that results in a `StackOverflowException`. Disabling the JIT compiler in the debugger removed the error and I could debug the original binary.

So, FINALLY, I am able to trace the execution of the original binary. I figured out quickly that the `VerifyMethods();` function in `Program.Init()` actually swaps the function pointers of three functions: f -> g, a -> b, and f -> g. Having previously commented them out, I missed this in my execution. I swapped the function calls in my exported, C# version, and was still getting a result inconsistent with the original binary. After some digging in the original assembly source, I figured out that the C# decompiler did not perfectly decompile two constants in `Program.g()` and s a result it was generating an incorrect constant. After fixing that... everything worked! The rest of the work was in reversing each of the function (b, d, g, and h) and then running the reversing program on the original image. Doing so yielded another bmp image (decoded.bmp) and so I ran it AGAIN and got another bmp with the flag! 

### Solution:

**d0nT_tRu$t_vEr1fy@flare-on.com**

### Comments:

The flag is important: DON'T TRUST FUNCTION NAMES!

### Challenge Keywords:

`reversing` `steganography` `programming` `.NET` `C#`

### Things I learned:

* **Constrained Execution Regions (CERs)** are a feature of .Net that is used to provide reliability guarantees for certain blocks of code that may execute under hostile circumstances. CERs provide a way to provide reliable backout for some semantic operation, to ensure that the effects of the operation are entirely committed or not committed at all. CERs work by defining regions of code where the .Net runtime will not throw the so-called "out-of-band" exceptions that can typically occur anywhere in code, even in a statement as simple as `i++` - [Source](https://antiduh.com/blog/node/). In other words, its like SQL Transactions that prevent code from being committed unless it succeeded 100%.