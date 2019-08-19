# Flare-on CTF 2019

## 2 - Overlong

### Challenge text:

The secret of this next challenge is cleverly hidden. However, with the right approach, finding the solution will not take an <b>overlong</b> amount of time.

### Provided Files:

- Overlong.exe (Windows Executable)
- Message.txt

### Tooling:

To disassemble the binary, I used Binary Ninja and Ghidra (because Binja assembly view is easier to read, but Ghidra has a good decompiler). 

### Solving the challenge:

I first ran the program. Upon runnning the executable, an alert window appears with the text "I never broke the encoding." Clicking OK ends the program.

Upon openning the assembly in Ghidra and Binja, I decided to work backwards and determine what the desired output of the program was. The last function to be called is the Windows OS Kernal function "MessageBoxA" which opens the afforementioned alert box. The docs list the function as accepting for arguments:

```c++
int MessageBox(
    HWND hWnd,
    LPCTSTR lpText,
    LPCTSTR lpCaption,
    UINT uType
)
```

> `hWnd` refers to the parent window (pass NULL if the dialog is the root window), `lpText` is the message to be displayed, `lpCaption` is the dialog box title, and `uType` is the dialog window type (i.e. this controls the number of buttons and what each button does).

This function is passed the following values in the Overlong.exe:

```c++
MessageBoxA(NULL, buffer, "Output", 0);
```

Which creates a root window, with the text coming from a 128 byte local variable (`buffer`), a title of Output (a string literal) and with only a single button (OK).

The next step is identifying where this local varaiabel `buffer` is being populated. It seems as if a pointer to the variable is passed to a function (which I will refer to as `first_func`), which returns an index at which the buffer is NULL terminated. Based upon the first output, I realize that, by default, the function `first_func` will populate the buffer variable with the string "I never broke the encoding." Given that there is no means for the program to receive user input, the problem must be solvable with some sort of patch which will decode the flag and display it. Based upon the challenge hint, I figure that this is a pretty easy patch and will save me from handle decoding the flag.

`first_func` takes three arguments: the output buffer pointer (`buffer`), the and input array, and an integer that seems to serves as the length of the output buffer (unless the output function terminates in a NULL character). It returns the length of the string in `buffer`. Essentially, `first_func` continually passes the input array and buffer to a second function, `decode`. The decode function adds a single character to the ouput buffer and increments the input string by some integer.  

`decode` takes just the output buffer pointer and the input string pointer and returns a length. Decode performs four checks:

1. If the first input byte is 1111 0XXX (X could be 1 or 0), then `output[0] = ((in[2] & 0x3f) << 6) | in[3] & 0x3f` and return 4. (This case ignores the value of `in[1]`)

2. If the first input byte is 1110 XXXX, then `output[0] = ((in[1] & 0x3f) << 6) | in[2] & 0x3f` and return 3.

3. If the first input byte is 110X XXXX, then `output[0] = ((*in & 0x1f) << 6) | in[1] & 0x3f` and return 2.

4. All other cases, perform no decoding, `output[0] = input[0]`, return 1.

Now that I understood how the program worked, I just remade the program in python and ran it. I received the same output as running the Overlong.exe program ("I never broke the encoding"). Curious I had the program run and decode every bite (rather than incrementing the input buffer based upon the afforementioned aglorithm) (see `test.py` for that test) and I received the following output:

```
I never broke the encoding: I_a_M_t_h_e_e_n_C_o_D_i_n_g@flare-on.com
```

I think I found the flag!

### Solution:

**I_a_M_t_h_e_e_n_C_o_D_i_n_g@flare-on.com**

### Comments: 

A simple reversing challenge, I appreciated the little bit of crypto involved in it. A bit harder than the last one.

### Challenge Keywords:

`reversing` `code analysis`
